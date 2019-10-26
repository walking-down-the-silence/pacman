namespace PacMan
{
    public class AxisAlignedBoundingBoxOverlapCheck : IOverlappingStrategy
    {
        public bool Overlap(ISprite left, ISprite right)
        {
            return left.ToBoundingBox().Overlap(right.ToBoundingBox());
        }
    }
}
