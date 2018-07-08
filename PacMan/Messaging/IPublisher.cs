namespace PacMan
{
    public interface IPublisher
    {
        void Publish<TEvent>(TEvent value);
    }
}
