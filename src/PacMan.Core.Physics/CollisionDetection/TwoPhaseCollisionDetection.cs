using PacMan.Core.DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PacMan
{
    /// <summary>
    /// Runs a broad phase of collision detection
    /// and narrow the objects that are potentially colliding
    /// run a narrow phase of collision detection
    /// and execute the logic for detecting objects
    /// </summary>
    public class TwoPhaseCollisionDetection : ICollisionDetection
    {
        private readonly IOverlappingStrategy _narrowPhase = new PixelPerfectOverlapCheck();

        public IDictionary<ISprite, ICollection<ISprite>> DetectCollisions(ICollection<ISprite> sprites)
        {
            var wrappers = sprites.Select(sprite => new SpriteWrapper(sprite)).ToList();
            var seed = AxisAlignedBoundingBoxTree<SpriteWrapper>.Empty;
            var tree = ConstructTreeRecursively(seed, wrappers.GetEnumerator());
            return wrappers.ToDictionary(key => key.Sprite, value => InternalDetectCollisions(tree, value));
        }

        public ICollection<ISprite> DetectCollisions(ISprite target, ICollection<ISprite> sprites)
        {
            var wrappers = sprites.Select(sprite => new SpriteWrapper(sprite)).ToList();
            var seed = AxisAlignedBoundingBoxTree<SpriteWrapper>.Empty;
            var tree = ConstructTreeRecursively(seed, wrappers.GetEnumerator());
            return InternalDetectCollisions(tree, new SpriteWrapper(target));
        }

        private ICollection<ISprite> InternalDetectCollisions(AxisAlignedBoundingBoxTree<SpriteWrapper> tree, SpriteWrapper target) =>
            tree.Find(target)
                .Where(collision => _narrowPhase.Overlap(target.Sprite, collision.Sprite))
                .Select(wrapper => wrapper.Sprite)
                .ToList();

        private AxisAlignedBoundingBoxTree<TValue> ConstructTreeRecursively<TValue>(AxisAlignedBoundingBoxTree<TValue> tree, IEnumerator<TValue> actors)
            where TValue : class, IAxisAlignedBoundingBoxContainer =>
            actors.MoveNext() ? ConstructTreeRecursively(tree.Insert(actors.Current), actors) : tree;

        private class SpriteWrapper : IAxisAlignedBoundingBoxContainer
        {
            public SpriteWrapper(ISprite sprite)
            {
                Sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
                Box = Sprite.ToBoundingBox();
            }

            public ISprite Sprite { get; }

            public AxisAlignedBoundingBox Box { get; }
        }
    }
}
