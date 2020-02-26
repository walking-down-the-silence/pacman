using System.Collections.Generic;

namespace PacMan
{
    public interface ICollisionDetection
    {
        IDictionary<ISprite, ICollection<ISprite>> DetectCollisions(ICollection<ISprite> sprites);
    }
}
