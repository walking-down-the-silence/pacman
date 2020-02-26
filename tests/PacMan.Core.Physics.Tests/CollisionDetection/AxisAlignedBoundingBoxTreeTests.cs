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
            Assert.Throws<ArgumentNullException>(() => AxisAlignedBoundingBoxTree<BoxWrapper>.FromValue(null));
        }

        [Fact]
        public void FromValue_WithEmptyBox_ShouldReturnAnInstance()
        {
            // Arrange, Act
            var tree = AxisAlignedBoundingBoxTree<BoxWrapper>.FromValue(new BoxWrapper(AxisAlignedBoundingBox.Empty));

            // Assert
            Assert.NotNull(tree);
            Assert.NotNull(tree.Root);
        }

        [Fact]
        public void Insert_WithNewBox_ShouldUpdateTheTree()
        {
            // Arrange
            var tree = AxisAlignedBoundingBoxTree<BoxWrapper>.Empty;
            var box1 = new AxisAlignedBoundingBox(new Vector2D(1, 1), new Vector2D(4, 4));
            var box2 = new AxisAlignedBoundingBox(new Vector2D(6, 6), new Vector2D(9, 9));
            var box3 = new AxisAlignedBoundingBox(new Vector2D(7, 7), new Vector2D(10, 10));

            // Act
            var actual = tree
                .Insert(new BoxWrapper(box1))
                .Insert(new BoxWrapper(box2))
                .Insert(new BoxWrapper(box3));

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Root);
            Assert.NotNull(actual.Root.Box);
            Assert.Equal(9, actual.Root.Box.Size.X);
            Assert.Equal(9, actual.Root.Box.Size.Y);
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
            var tree = AxisAlignedBoundingBoxTree<BoxWrapper>.Empty;
            var box1 = new AxisAlignedBoundingBox(new Vector2D(1, 1), new Vector2D(4, 4));
            var box2 = new AxisAlignedBoundingBox(new Vector2D(6, 6), new Vector2D(9, 9));
            var box3 = new AxisAlignedBoundingBox(new Vector2D(7, 7), new Vector2D(10, 10));

            // Act
            var updated = tree.Insert(new BoxWrapper(box1)).Insert(new BoxWrapper(box2));
            var actual = updated.Find(new BoxWrapper(box3));

            // Assert
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.Single());
            Assert.Equal(box2, actual.Single().Box);
        }

        private class BoxWrapper : IAxisAlignedBoundingBoxContainer
        {
            public BoxWrapper(AxisAlignedBoundingBox box) => Box = box;

            public AxisAlignedBoundingBox Box { get; }
        }
    }
}
