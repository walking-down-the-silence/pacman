using PacMan.Core.DataStructures.Trees;
using System;
using System.Linq;
using Xunit;

namespace PacMan.Core.Physics.Tests
{
    public class AxisAlignedBoundingBoxTreeTests
    {
        [Fact]
        public void FromValue_WithNullValue_ShouldThrowArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => AxisAlignedBoundingBoxTree.FromValue(null));
        }

        [Fact]
        public void FromValue_WithEmptyBox_ShouldReturnAnInstance()
        {
            // Arrange, Act
            var tree = AxisAlignedBoundingBoxTree.FromValue(AxisAlignedBoundingBox.Empty);

            // Assert
            Assert.NotNull(tree);
            Assert.NotNull(tree.Root);
        }

        [Fact]
        public void Insert_WithNewBox_ShouldUpdateTheTree()
        {
            // Arrange
            var root = new AxisAlignedBoundingBox(new Vector2D(1, 1), new Vector2D(4, 4));
            var tree = AxisAlignedBoundingBoxTree.FromValue(root);
            var box2 = new AxisAlignedBoundingBox(new Vector2D(6, 6), new Vector2D(9, 9));
            var box3 = new AxisAlignedBoundingBox(new Vector2D(7, 7), new Vector2D(10, 10));

            // Act
            var actual = tree.Insert(box2).Insert(box3);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Root);
            Assert.NotNull(actual.Root.Value);
            Assert.Equal(9, actual.Root.Value.Size.X);
            Assert.Equal(9, actual.Root.Value.Size.Y);
            Assert.NotNull(actual.Root.Left);
            Assert.Null(actual.Root.Left.Left);
            Assert.Null(actual.Root.Left.Right);
            Assert.NotNull(actual.Root.Right);
            Assert.NotNull(actual.Root.Right.Left);
            Assert.NotNull(actual.Root.Right.Right);
        }


        [Fact]
        public void Find_WithNewBox_ShouldFindSIngleOverlappingBox()
        {
            // Arrange
            var root = new AxisAlignedBoundingBox(new Vector2D(1, 1), new Vector2D(4, 4));
            var tree = AxisAlignedBoundingBoxTree.FromValue(root);
            var box2 = new AxisAlignedBoundingBox(new Vector2D(6, 6), new Vector2D(9, 9));
            var box3 = new AxisAlignedBoundingBox(new Vector2D(7, 7), new Vector2D(10, 10));

            // Act
            var updated = tree.Insert(box2);
            var actual = updated.Find(box3);

            // Assert
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.Single());
            Assert.Equal(box2, actual.Single());
        }
    }
}
