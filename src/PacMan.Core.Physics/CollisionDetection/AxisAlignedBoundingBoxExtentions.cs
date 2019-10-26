namespace PacMan
{
    public static class AxisAlignedBoundingBoxExtentions
    {
        public static bool Overlap(this AxisAlignedBoundingBox left, AxisAlignedBoundingBox right)
        {
            var d1x = left.LeftBottom.X - right.RightTop.X;
            var d1y = left.LeftBottom.Y - right.RightTop.Y;
            var d2x = left.LeftBottom.X - right.RightTop.X;
            var d2y = left.LeftBottom.Y - right.RightTop.Y;

            return !(d1x > 0 || d1y > 0) && !(d2x > 0 || d2y > 0);
        }
    }
}
