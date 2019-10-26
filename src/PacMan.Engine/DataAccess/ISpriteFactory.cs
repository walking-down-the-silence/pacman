using System.Collections.Generic;

namespace PacMan
{
    public interface ISpriteFactory
    {
        IEnumerable<ISprite> CreateFrom(object parameter);
    }
}
