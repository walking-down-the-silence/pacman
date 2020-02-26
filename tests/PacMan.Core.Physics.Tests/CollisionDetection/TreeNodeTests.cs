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
            Assert.Throws<ArgumentNullException>(() => new TreeNode<string>((string)null, null));
        }

        [Fact]
        public void Ctor_WithNullBranches_ShouldThrowArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new TreeNode<string>((TreeNode<string>)null, (TreeNode<string>)null));
        }
    }
}
