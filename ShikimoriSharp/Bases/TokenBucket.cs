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

        public TokenBucket(string name, int maxTokens, int refreshTime)
        {
            Name = name;
            MaxTokens = maxTokens;
            RefreshTime = refreshTime;

            _timer = new Timer(refreshTime);
            _timer.Elapsed += Refresh;
            _sem = new SemaphoreSlim(0, maxTokens);
            _sem.Release(maxTokens);
        }

        public string Name { get; }
        public int MaxTokens { get; }
        public double RefreshTime { get; }

        private void Refresh(object sender, ElapsedEventArgs args)
        {
            if (_sem.CurrentCount == MaxTokens - 1)
                _timer.Stop();

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