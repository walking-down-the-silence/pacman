using System.Linq;

namespace PacMan
{
    public sealed class BashfulGhost : Ghost
    {
        public BashfulGhost(Offset position) :
            base(position, Color.Cyan, new Offset(18, 22).Extend(Tile.SIZE), new BashfulChasingMode())
        {
        }

        private sealed class BashfulChasingMode : IGhostMode
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
