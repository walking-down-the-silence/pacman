﻿namespace PacMan
{
    public sealed class GhostRespawn : SpriteBase, IRespawnSprite
    {
        public GhostRespawn(Offset position) :
            base(position, new TransparentFrame())
        {
        }

        public void Execute(GhostRespawnContext context)
        {
            if (context.Ghost.Mode == GhostMode.Dead)
            {
                context.Ghost.Ressurect();
            }
        }
    }
}
