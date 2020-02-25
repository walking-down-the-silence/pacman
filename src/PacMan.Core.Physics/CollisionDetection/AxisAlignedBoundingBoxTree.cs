using System;
using System.Collections.Generic;
using System.Linq;

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

        public ICollection<AxisAlignedBoundingBox> Find(AxisAlignedBoundingBox box)
        {
            if (box == null) throw new ArgumentNullException(nameof(box));
            return InternalFind(Root, box).ToList();
        }

        public AxisAlignedBoundingBoxTree Insert(AxisAlignedBoundingBox box)
        {
            if (box == null) throw new ArgumentNullException(nameof(box));
            return new AxisAlignedBoundingBoxTree(InternalInsert(Root, box));
        }

        private IEnumerable<AxisAlignedBoundingBox> InternalFind(TreeNode node, AxisAlignedBoundingBox box)
        {
            if (node.Value.Overlap(box))
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

        private TreeNode InternalInsert(TreeNode node, AxisAlignedBoundingBox box)
        {
            if (node == null)
            {
                return new TreeNode(box);
            }
            else if (node.Left != null && node.Right != null)
            {
                var rightBox = box.Combine(node.Right.Value);
                var leftBox = box.Combine(node.Left.Value);
                return rightBox.Volume < leftBox.Volume
                    ? new TreeNode(node.Left, InternalInsert(node.Right, box))
                    : new TreeNode(InternalInsert(node.Left, box), node.Right);
            }
            else
            {
                var left = new TreeNode(node.Value);
                var right = new TreeNode(box);
                return new TreeNode(left, right);
            }
        }
    }
}
