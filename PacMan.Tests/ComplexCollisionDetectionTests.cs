using Xunit;

namespace PacMan.Tests
{
    public class ComplexCollisionDetectionTests
    {
        [Fact]
        public void Overlap_OnTwoSprites_ShouldReturnTrue()
        {
            // Arrange
            var colorsOne = Color.Red.ToBitmap(new[,]
                {
                    { true, true,  true,  true  },
                    { true, false, false, false },
                    { true, false, false, false },
                    { true, false, false, false }
                });
            var colorTwo = Color.White.ToBitmap(new[,]
                {
                    { false, true, false },
                    { true,  true, true  },
                    { false, true, false }
                });
            ISprite left = new GenericSprite(new Offset(3, 2), colorsOne);
            ISprite right = new GenericSprite(new Offset(1, 4), colorTwo);
            AxisAlignedBoundingBoxOverlapCheck collisionDetection = new AxisAlignedBoundingBoxOverlapCheck();

            // Act
            bool overlaps = collisionDetection.Overlap(left, right);

            // Assert
            Assert.True(overlaps);
        }
    }
}
