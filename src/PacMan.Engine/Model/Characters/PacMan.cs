using System.Linq;

namespace PacMan
{
    public sealed class PacMan : SpriteBase, IPacMan
    {
        private readonly Offset _initialPosition;

        public PacMan(Offset position) : base(position, new PacManFrame())
        {
            _initialPosition = position;
            State = new CharacterState();
        }

        public CharacterState State { get; private set; }

        public bool IsDead { get; private set; }

        public void Kill() => IsDead = true;

        public void Ressurect() => IsDead = false;

        public void Move(SelfMovementContext context)
        {
            // get next target based on ghost mode and corresponding movement strategy
            var currentVertex = Position.ToTile();
            var currentTile = context.Map[currentVertex.Y, currentVertex.X];

            // check if ghost needs to change the direction
            if (Position.Equals(currentTile.Position))
            {
                var allowedDirections = context.Map.GetNeighbors(currentVertex)
                    .Where(neighbor => !neighbor.IsWall)
                    .Select(neighbor => Position.ToDirection(neighbor.Position))
                    .ToList();

                // specified direction is not allowed, so stop
                State.Direction = !allowedDirections.Contains(context.GameState.PacManNextTurn)
                    ? Direction.None
                    : context.GameState.PacManNextTurn;
            }

            if (State.Direction != Direction.None)
            {
                var nextPosition = Position.Shift(State.Direction.ToOffset());
                var afterVertex = nextPosition.ToTile();
                var afterTile = context.Map[afterVertex.Y, afterVertex.X];
                Position = afterTile.IsWall ? Position : nextPosition;
            }
        }

        public void Reset()
        {
            State = new CharacterState { Direction = Direction.None, Target = Offset.Default };
            Position = _initialPosition;
            Ressurect();
        }

        public void Effect(FoodContext context)
        {
            if (context.Eatable is IGhost ghost
                && ghost.Mode != GhostMode.Frightened
                && ghost.Mode != GhostMode.Dead)
            {
                Kill();
                Reset();
                context.Map.Ghosts.ToList().ForEach(actor => actor.Reset());
                context.GameState.DropLife();
                context.EventSink.Publish(new PacManEaten());
            }
        }
    }
}
