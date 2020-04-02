using System.Linq;

namespace PacMan
{
    public sealed class BashfulGhost : Ghost
    {
        private static readonly Offset _patrollingTarget = new Offset(18, 22).Extend(Tile.SIZE);

        public BashfulGhost(Offset position) :
            base(position, Color.Cyan, _patrollingTarget, new BashfulChasingMode())
        {
        }

        private sealed class BashfulChasingMode : IGhostMovementStrategy
        {
            public Offset Execute(GhostMovementContext context)
            {
                const int timesAhead = 2;
                var shadow = context.Map.Ghosts.OfType<SpeedyGhost>().Single();
                var shift = shadow.State.Target.Subtract(shadow.Position);
                var extended = shift.Extend(timesAhead);
                var ghostTarget = shadow.Position.Shift(extended);
                return ghostTarget;
            }
        }
    }
}
