using System.Collections.Generic;

namespace PacMan
{
    public interface ICollisionDetection
    {
        ICollection<(ISprite one, ISprite two)> DetectCollisions(ICollection<ISprite> actors);
    }
}
