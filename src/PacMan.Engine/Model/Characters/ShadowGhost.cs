namespace PacMan
{
    public sealed class ShadowGhost : Ghost
    {
        private static readonly Offset _patrollingTarget = new Offset(16, -2).Extend(Tile.SIZE);

        public ShadowGhost(Offset position) :
            base(position, Color.Red, _patrollingTarget, new ShadowChasingMode())
        {
        }

        private sealed class ShadowChasingMode : IGhostMovementStrategy
        {
            public Offset Execute(GhostMovementContext context) => context.Map.PacMan.Position;
        }
    }
}
