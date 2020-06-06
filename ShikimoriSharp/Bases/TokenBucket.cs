using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ShikimoriSharp.Bases
{
    public class TokenBucket
    {
        private readonly SemaphoreSlim _sem;

        private readonly Timer _timer;

        public TokenBucket(string name, int maxTokens, double refreshTime)
        {
            Name = name;
            MaxTokens = maxTokens;
            RefreshTime = refreshTime;

            _timer = new Timer(refreshTime);
            _timer.Elapsed += Refresh;
            _timer.AutoReset = true;
            _sem = new SemaphoreSlim(0, maxTokens);
            _sem.Release(maxTokens);
        }

        public string Name { get; }
        public int MaxTokens { get; }
        public double RefreshTime { get; }

        private void Refresh(object sender, ElapsedEventArgs args)
        {
            _sem.Release(MaxTokens);
        }

        public async Task TokenRequest()
        {
            if (!_timer.Enabled)
                _timer.Start();
            await _sem.WaitAsync();
        }
    }
}