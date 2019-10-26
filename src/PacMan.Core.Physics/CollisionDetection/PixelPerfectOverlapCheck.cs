using System;

namespace PacMan
{
    public class PixelPerfectOverlapCheck : IOverlappingStrategy
    {
        public bool Overlap(ISprite left, ISprite right)
        {
            var leftShifted = left.Position.Shift(left.Size.Width, left.Size.Height);
            var rightShifted = right.Position.Shift(right.Size.Width, right.Size.Height);

            var minX = Math.Min(left.Position.Left, right.Position.Left);
            var minY = Math.Min(left.Position.Top, right.Position.Top);

            var maxX = Math.Max(leftShifted.Left, rightShifted.Left);
            var maxY = Math.Max(leftShifted.Top, rightShifted.Top);

            var height = maxY - minY;
            var width = maxX - minX;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int leftY = y + minY - left.Position.Top;
                    int leftX = x + minX - left.Position.Left;
                    int rightY = y + minY - right.Position.Top;
                    int rightX = x + minX - right.Position.Left;

                    if (leftY >= 0
                        && leftY < left.Size.Height
                        && leftX >= 0
                        && leftX < left.Size.Width
                        && rightY >= 0
                        && rightY < right.Size.Height
                        && rightX >= 0
                        && rightX < right.Size.Width)
                    {
                        if (left[leftY, leftX] != Color.None
                            && right[rightY, rightX] != Color.None)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
