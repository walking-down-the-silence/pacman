using System.Threading;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IGameEngine<in TContext>
    {
        CancellationTokenSource TokenSource { get; }

        Task Run(TContext context, CancellationToken token);
    }
}
