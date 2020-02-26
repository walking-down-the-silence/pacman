using System.Collections.Generic;
using Xunit;

namespace PacMan.Core.Physics.Tests.CollisionDetection
{
    public class TwoPhaseCollisionDetectionTests
    {
        [Fact]
        public void DetectCollisions_OnSpriteArray_ShouldFindCollision()
        {
            // Arrange
            Color[,] colors = new Color[3, 3]
            {
                { Color.Black, Color.Black, Color.Black },
                { Color.Black, Color.Black, Color.Black },
                { Color.Black, Color.Black, Color.Black }
            };
            ICollection<ISprite> actors = new[]
            {
                new GenericSprite(Offset.Default, colors),
                new GenericSprite(Offset.Default, colors),
                new GenericSprite(Offset.Default, colors)
            };
            TwoPhaseCollisionDetection strategy = new TwoPhaseCollisionDetection();

            // Act
            var collisions = strategy.DetectCollisions(actors);

            // Assert
            Assert.NotEmpty(collisions);
        }
    }
}
