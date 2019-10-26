namespace PacMan
{
    public sealed class ShadowGhost : Ghost
    {
        public ShadowGhost(Offset position) :
            base(position, Color.Red, new Offset(16, -2).Extend(Tile.SIZE), new ShadowChasingMode())
        {
        }

        private sealed class ShadowChasingMode : IGhostMode
        {
            public Offset Execute(GhostMovementContext context) => context.Map.PacMan.Position;
        }
    }
}
