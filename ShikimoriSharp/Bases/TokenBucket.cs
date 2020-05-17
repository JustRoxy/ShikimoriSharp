using System;
using System.Threading.Tasks;

namespace ShikimoriSharp.Bases
{
    /// <summary>
    ///     https://github.com/samjcs/EasyDotNetTokenBucket
    /// </summary>
    public class TokenBucket
    {
        public delegate void TokenBucketLog(string status, string message);

        private static readonly object SyncRoot = new object();

        public TokenBucket(int maxCapacity, int interval)
        {
            MaxCapacity = maxCapacity;
            Interval = TimeSpan.FromMilliseconds((long) interval * 1000).Ticks;
            CurrentTokens = 0;
            NextRefill = DateTime.UtcNow.Ticks + interval;
        }

        protected long MaxCapacity { get; set; }
        protected long Interval { get; set; }
        protected long CurrentTokens { get; set; }
        protected long NextRefill { get; set; }

        public event TokenBucketLog OnNewLog;

        public async Task<bool> GetToken()
        {
            UpdateTime();

            if (!ShouldThrottle()) return true;
            UpdateTime();
            await Task.Delay((int) NextRefill - (int) DateTime.UtcNow.Ticks);
            return true;
        }

        private void UpdateTime()
        {
            lock (SyncRoot)
            {
                var currentTime = DateTime.UtcNow.Ticks;
                if (NextRefill >= currentTime) return;

                OnNewLog?.Invoke("Reset", "Interval Reached Resetting Time");
                NextRefill = currentTime + Interval;
                CurrentTokens = 0;
            }
        }

        private bool ShouldThrottle()
        {
            lock (SyncRoot)
            {
                UpdateTime();
                if (CurrentTokens < MaxCapacity && CurrentTokens >= 0)
                {
                    CurrentTokens++;
                    OnNewLog?.Invoke("Capacity", $"Bucket Capacity at: {CurrentTokens} of {MaxCapacity}");
                    return false;
                }

                OnNewLog?.Invoke("Full", "Bucket Full");
                return true;
            }
        }
    }
}