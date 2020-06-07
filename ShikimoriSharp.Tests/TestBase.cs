using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShikimoriSharp.Bases;


namespace ShikimoriSharp.Tests
{
    internal class NUnitLogger<T> : ILogger<T>, IDisposable
    {
        private static Action<string> Output => x => Console.WriteLine($"[{DateTime.UtcNow:h:mm:ss:fff}] {x}");


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Output(formatter(state, exception));
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => this;

        public void Dispose() {}
    }

    
    
    public abstract class TestBase
    {
        protected readonly ShikimoriClient Client;
        protected readonly long UserId;
        protected AccessToken Token;
        protected TestBase()
        {
            var scope = Environment.GetEnvironmentVariable("scope");
            var access = Environment.GetEnvironmentVariable("access_token");
            var refresh = Environment.GetEnvironmentVariable("refresh_token");
            var name = Environment.GetEnvironmentVariable("name");
            var clientId = Environment.GetEnvironmentVariable("client_id");
            var clientSecret = Environment.GetEnvironmentVariable("client_secret");
            UserId = Convert.ToInt64(Environment.GetEnvironmentVariable("userId"));
            Token = new AccessToken
            {
                Access_Token = access,
                RefreshToken = refresh,
                Scope = scope
            };
            var logger = new NUnitLogger<TestBase>();
            Client = new ShikimoriClient(logger, new ClientSettings(name, clientId, clientSecret));
        }

        protected bool IsInScope(string scope)
        {
            return !(Token.Scope is null) && Token.Scope.Split(" ").Any(it => it == scope);
        }
    }
}