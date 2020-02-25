using System;

namespace PacMan.Core.DataStructures.Trees
{
    public class TreeNode
    {
        public TreeNode(AxisAlignedBoundingBox value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public TreeNode(AxisAlignedBoundingBox value, TreeNode left, TreeNode right)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public AxisAlignedBoundingBox Value { get; }

        public TreeNode Left { get; }

        public TreeNode Right { get; }
    }
}
