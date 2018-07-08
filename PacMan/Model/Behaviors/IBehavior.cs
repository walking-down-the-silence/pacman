namespace PacMan
{
    public interface IBehavior<in TContext>
    {
        void Execute(TContext context);
    }
}
