using PacMan.Core.DataStructures.Trees;
using System;
using Xunit;

namespace PacMan.Core.Physics.Tests.CollisionDetection
{
    public class TreeNodeTests
    {
        [Fact]
        public void Ctor_WithNullValue_ShouldThrowArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new TreeNode(null));
        }

        [Fact]
        public void Ctor_WithNullBranches_ShouldThrowArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new TreeNode(null, null));
        }
    }
}
