namespace PacMan
{
    public sealed class AxisAlignedBoundingBoxOverlapCheck : IOverlappingStrategy
    {
        public bool Overlap(ISprite left, ISprite right) => left.ToBoundingBox().Overlap(right.ToBoundingBox());
    }
}
