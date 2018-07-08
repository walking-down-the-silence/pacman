namespace PacMan
{
    public interface IMovementStrategy<in TContext>
    {
        Offset Execute(TContext context);
    }
}
