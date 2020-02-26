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
        public IDictionary<ISprite, ICollection<ISprite>> DetectCollisions(ICollection<ISprite> sprites)
        {
            var narrowPhase = new PixelPerfectOverlapCheck();
            var wrappers = sprites.Select(sprite => new SpriteWrapper(sprite)).ToList();
            var seed = AxisAlignedBoundingBoxTree<SpriteWrapper>.Empty;
            var tree = ConstructTreeRecursively(seed, wrappers.GetEnumerator());
            return wrappers.ToDictionary(key => key.Sprite, wrapper =>
                    {
                        ICollection<ISprite> collisions = tree
                            .Find(wrapper)
                            .Where(collision => narrowPhase.Overlap(wrapper.Sprite, collision.Sprite))
                            .Select(x => x.Sprite)
                            .ToList();

                        return collisions;
                    });
        }

        private AxisAlignedBoundingBoxTree<TValue> ConstructTreeRecursively<TValue>(
            AxisAlignedBoundingBoxTree<TValue> tree,
            IEnumerator<TValue> actors)
            where TValue : class, IAxisAlignedBoundingBoxContainer
        {
            if (actors.MoveNext())
            {
                var next = tree.Insert(actors.Current);
                return ConstructTreeRecursively(next, actors);
            }

            return tree;
        }

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
