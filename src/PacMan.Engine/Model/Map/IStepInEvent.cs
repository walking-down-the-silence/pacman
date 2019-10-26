namespace PacMan
{
    public interface IStepInEvent<in TContext>
    {
        void Effect(TContext context);
    }
}
