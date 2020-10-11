using System;
using System.Collections.Generic;
using System.Linq;

namespace PacMan.Core.DataStructures.Trees
{
    public sealed record AxisAlignedBoundingBoxTree<TValue>(TreeNode<TValue> Root) where TValue : class, IAxisAlignedBoundingBoxContainer
    {
        public static AxisAlignedBoundingBoxTree<TValue> Empty => new AxisAlignedBoundingBoxTree<TValue>((TreeNode<TValue>)null);

        public static AxisAlignedBoundingBoxTree<TValue> FromValue(TValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new AxisAlignedBoundingBoxTree<TValue>(new TreeNode<TValue>(value, value.Box));
        }

        public ICollection<TValue> Find(TValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return InternalFind(Root, value.Box).ToList();
        }

        public AxisAlignedBoundingBoxTree<TValue> Insert(TValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new AxisAlignedBoundingBoxTree<TValue>(InternalInsert(Root, value));
        }

        private IEnumerable<TValue> InternalFind(TreeNode<TValue> node, AxisAlignedBoundingBox box)
        {
            if (node != null && node.Box.Overlap(box))
            {
                if (node.IsLeaf)
                {
                    yield return node.Value;
                }
                else
                {
                    foreach (var value in InternalFind(node.Left, box)) yield return value;
                    foreach (var value in InternalFind(node.Right, box)) yield return value;
                }
            }
        }

        private TreeNode<TValue> InternalInsert(TreeNode<TValue> node, TValue value)
        {
            if (node == null)
            {
                return new TreeNode<TValue>(value, value.Box);
            }
            else if (node.Left != null && node.Right != null)
            {
                var rightBox = value.Box.Combine(node.Right.Box);
                var leftBox = value.Box.Combine(node.Left.Box);
                return rightBox.Volume < leftBox.Volume
                    ? new TreeNode<TValue>(node.Left, InternalInsert(node.Right, value))
                    : new TreeNode<TValue>(InternalInsert(node.Left, value), node.Right);
            }
            else
            {
                var left = node;
                var right = new TreeNode<TValue>(value, value.Box);
                return new TreeNode<TValue>(left, right);
            }
        }
    }
}
