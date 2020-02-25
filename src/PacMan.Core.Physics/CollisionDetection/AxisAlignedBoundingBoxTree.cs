using System;

namespace PacMan.Core.DataStructures.Trees
{
    public class AxisAlignedBoundingBoxTree
    {
        private AxisAlignedBoundingBoxTree(TreeNode root) => Root = root;

        public TreeNode Root { get; }

        public AxisAlignedBoundingBoxTree FromValue(AxisAlignedBoundingBox value)
        {
            return new AxisAlignedBoundingBoxTree(new TreeNode(value));
        }

        public AxisAlignedBoundingBoxTree Insert(AxisAlignedBoundingBox value)
        {
            return new AxisAlignedBoundingBoxTree(InternalInsert(Root, value));
        }

        private TreeNode InternalInsert(TreeNode node, AxisAlignedBoundingBox value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }
            else if (node.Left != null && node.Right != null)
            {
                var rightBox = Combine(value, node.Right.Value);
                var leftBox = Combine(value, node.Left.Value);
                return rightBox.Volume < leftBox.Volume
                    ? InternalInsert(node.Right, value)
                    : InternalInsert(node.Left, value);
            }
            else
            {
                var left = new TreeNode(node.Value);
                var right = new TreeNode(value);
                var boundingBox = Combine(left.Value, right.Value);
                return new TreeNode(boundingBox, left, right);
            }
        }

        private AxisAlignedBoundingBox Combine(AxisAlignedBoundingBox first, AxisAlignedBoundingBox second)
        {
            int left = Math.Min(first.LeftBottom.X, second.LeftBottom.X);
            int bottom = Math.Min(first.LeftBottom.Y, second.LeftBottom.Y);
            int right = Math.Max(first.RightTop.X, second.RightTop.X);
            int top = Math.Max(first.RightTop.Y, second.RightTop.Y);
            return new AxisAlignedBoundingBox(new Vector2D(left, bottom), new Vector2D(right, top));
        }
    }
}
