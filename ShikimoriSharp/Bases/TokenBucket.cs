using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace ShikimoriSharp.Bases
{
    public class TokenBucket
    {
        public TokenBucket(string name, int maxConnections, int refreshTime)
        {
            Name = name;
            MaxConnections = maxConnections;
            RefreshTime = refreshTime;

            _timer = new System.Timers.Timer(refreshTime);
            _timer.Elapsed += Refresh;
            _sem = new SemaphoreSlim(0, maxConnections);
            _sem.Release(maxConnections);
            _timer.Start();
        }

        public string Name { get; }
        public int MaxConnections { get; }
        public double RefreshTime { get; }
        private readonly System.Timers.Timer _timer;
        private readonly SemaphoreSlim _sem;
        private void Refresh(object sender, ElapsedEventArgs args)
        {
            _sem.Release(MaxConnections);
        }
        public async Task TokenRequest()
        {
            await _sem.WaitAsync();
        }
    }
}