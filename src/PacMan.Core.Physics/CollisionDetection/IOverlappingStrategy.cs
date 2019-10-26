namespace PacMan
{
    public interface IOverlappingStrategy
    {
        bool Overlap(ISprite left, ISprite right);
    }
}
