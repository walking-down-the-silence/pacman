namespace PacMan
{
    public interface IHandler<in TEvent>
    {
        void Handle(TEvent value);
    }
}
