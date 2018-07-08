using Xunit;

namespace PacMan.Tests
{
    public class SpriteDifferenceRendererTests
    {
        [Fact]
        public void RenderBitmap_UsingSprite_ShouldFillColors()
        {
            // Arrange
            var colorMap = new Color[7, 7];
            var frame = Color.White.ToBitmap(new[,]
                {
                    { true,  true, false },
                    { false, true, false },
                    { false, true, true  }
                });
            var sprite = new GenericSprite(new Offset(4, 2), frame);
            var expected = Color.White.ToBitmap(new[,]
            {
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, true,  true,  false },
                { false, false, false, false, false, true,  false },
                { false, false, false, false, false, true,  true  },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false }
            });

            // Act
            ColorExtentions.RenderBitmap(colorMap, sprite);

            // Arrange
            Assert.Equal(expected, colorMap);
        }
    }
}
