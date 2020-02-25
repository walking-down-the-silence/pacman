using System;
using Xunit;

namespace PacMan.Core.Physics.Tests.CollisionDetection
{
    public class AxisAlignedBoundingBoxTests
    {
        [Fact]
        public void Combine_WithNullParameters_ShouldThrowArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => AxisAlignedBoundingBoxExtentions.Combine(null, null));
        }

        [Fact]
        public void Combine_WithTwoBoxes3By3_ShouldCombineIntoSingle6By6()
        {
            // Arrange
            var box1 = new AxisAlignedBoundingBox(new Vector2D(1, 1), new Vector2D(4, 4));
            var box2 = new AxisAlignedBoundingBox(new Vector2D(4, 4), new Vector2D(7, 7));

            // Act
            var actual = AxisAlignedBoundingBoxExtentions.Combine(box1, box2);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(36, actual.Volume);
            Assert.Equal(1, actual.LeftBottom.X);
            Assert.Equal(1, actual.LeftBottom.Y);
            Assert.Equal(7, actual.RightTop.X);
            Assert.Equal(7, actual.RightTop.Y);
        }
    }
}
