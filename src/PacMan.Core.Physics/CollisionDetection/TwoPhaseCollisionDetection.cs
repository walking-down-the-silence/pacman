using System.Collections.Generic;

namespace PacMan
{
    public class TwoPhaseCollisionDetection : ICollisionDetection
    {
        private readonly IOverlappingStrategy _broadPhase = new AxisAlignedBoundingBoxOverlapCheck();
        private readonly IOverlappingStrategy _narrowPhase = new PixelPerfectOverlapCheck();

        public ICollection<(ISprite one, ISprite two)> DetectCollisions(ICollection<ISprite> actors)
        {
            List<(ISprite one, ISprite two)> collisions = new List<(ISprite one, ISprite two)>();

            // TODO: build an AABB tree for faster search of overlapping objects
            foreach (var actor1 in actors)
            {
                foreach (var actor2 in actors)
                {
                    // run a broad phase of collision detection
                    // and narrow the objects that are potentially colliding
                    // run a narrow phase of collision detection
                    // and execute the logic for detecting objects 
                    if (!ReferenceEquals(actor1, actor2)
                        && _broadPhase.Overlap(actor1, actor2)
                        && _narrowPhase.Overlap(actor1, actor2))
                    {
                        collisions.Add((actor1, actor2));
                    }
                }
            }

            return collisions;
        }
    }
}
