using System.Threading;
using System.Threading.Tasks;

namespace PacMan
{
    public abstract class GameEngineBase<TContext> : IGameEngine<TContext>
    {
        public CancellationTokenSource TokenSource { get; protected set; } = new CancellationTokenSource();

        public virtual Task Run(TContext context, CancellationToken token)
        {
            TokenSource = CancellationTokenSource.CreateLinkedTokenSource(TokenSource.Token, token);
            return Task.WhenAll(
                PhysicsLoop(context, TokenSource.Token),
                InputLoop(context, TokenSource.Token),
                RenderLoop(context, TokenSource.Token));
        }

        protected async Task PhysicsLoop(TContext context, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                int delay = 1000 / 200;
                await Task.Delay(delay, token);
                await PhysicsStep(context, token);
            }
        }

        protected async Task RenderLoop(TContext context, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                int delay = 1000 / 30;
                await Task.Delay(delay, token);
                await RenderStep(context, token);
            }
        }

        protected async Task InputLoop(TContext context, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await InputHandle(context, token);
            }
        }

        protected virtual Task PhysicsStep(TContext context, CancellationToken token) => Task.CompletedTask;

        protected virtual Task RenderStep(TContext context, CancellationToken token) => Task.CompletedTask;

        protected virtual Task InputHandle(TContext context, CancellationToken token) => Task.CompletedTask;
    }
}
