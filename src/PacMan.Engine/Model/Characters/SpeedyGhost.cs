namespace PacMan
{
    public sealed class SpeedyGhost : Ghost
    {
        private static readonly Offset _patrollingTarget = new Offset(2, -2).Extend(Tile.SIZE);

        public SpeedyGhost(Offset position) :
            base(position, Color.Pink, _patrollingTarget, new SpeedyChasingMode())
        {
        }

        private sealed class SpeedyChasingMode : IGhostMovementStrategy
        {
            public Offset Execute(GhostMovementContext context)
            {
                const int tilesAhead = 4;
                var pacManDirection = context.Map.PacMan.State.Direction;
                var shift = pacManDirection.ToOffset().Extend(tilesAhead);
                var ghostTarget = context.Map.PacMan.Position.Shift(shift);
                return ghostTarget;
            }
        }
    }
}
