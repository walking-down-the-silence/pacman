using System;

namespace PacMan.Core.DataStructures.Trees
{
    public class AxisAlignedBoundingBoxTree
    {
        private AxisAlignedBoundingBoxTree(TreeNode root) => Root = root;

        public TreeNode Root { get; }

        public static AxisAlignedBoundingBoxTree FromValue(AxisAlignedBoundingBox value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new AxisAlignedBoundingBoxTree(new TreeNode(value));
        }

        public AxisAlignedBoundingBoxTree Insert(AxisAlignedBoundingBox value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
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
                var rightBox = AxisAlignedBoundingBox.Combine(value, node.Right.Value);
                var leftBox = AxisAlignedBoundingBox.Combine(value, node.Left.Value);
                return rightBox.Volume < leftBox.Volume
                    ? new TreeNode(node.Left, InternalInsert(node.Right, value))
                    : new TreeNode(InternalInsert(node.Left, value), node.Right);
            }
            else
            {
                var left = new TreeNode(node.Value);
                var right = new TreeNode(value);
                return new TreeNode(left, right);
            }
        }
    }
}
