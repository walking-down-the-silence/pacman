using System;

namespace PacMan.Core.DataStructures.Trees
{
    public record TreeNode<TValue> where TValue : class
    {
        public TreeNode(TValue value, AxisAlignedBoundingBox box)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Box = box ?? throw new ArgumentNullException(nameof(box));
        }

        public TreeNode(TreeNode<TValue> left, TreeNode<TValue> right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
            Box = AxisAlignedBoundingBoxExtentions.Combine(left.Box, right.Box);
        }

        public TValue Value { get; }

        public AxisAlignedBoundingBox Box { get; }

        public TreeNode<TValue> Left { get; }

        public TreeNode<TValue> Right { get; }

        public bool IsLeaf => Value != null && Box != null && Left == null && Right == null;
    }
}
