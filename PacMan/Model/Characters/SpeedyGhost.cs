namespace PacMan
{
    public sealed class SpeedyGhost : Ghost
    {
        public SpeedyGhost(Offset position) :
            base(position, Color.Pink, new Offset(2, -2).Extend(Tile.SIZE), new SpeedyChasingMode())
        {
        }

        private sealed class SpeedyChasingMode : IGhostMode
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
