namespace PacMan
{
    public sealed class PokeyGhost : Ghost
    {
        private static Offset _patrollingTarget = new Offset(0, 22).Extend(Tile.SIZE);

        public PokeyGhost(Offset position) :
            base(position, Color.DarkYellow, _patrollingTarget, new PokeyChasingMode())
        {
        }

        private sealed class PokeyChasingMode : IGhostMode
        {
            public Offset Execute(GhostMovementContext context)
            {
                const int pokeyConfortableDistance = 8 * Tile.SIZE;
                var pacManPosition = context.Map.PacMan.Position;
                var ghostPosition = context.Ghost.Position;
                var distance = ghostPosition.ManhattanDistance(pacManPosition);
                var ghostTarget = distance > pokeyConfortableDistance ? pacManPosition : _patrollingTarget;
                return ghostTarget;
            }
        }
    }
}
