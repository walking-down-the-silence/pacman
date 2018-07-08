using System.Linq;

namespace PacMan
{
    public sealed class PacMan : SpriteBase, IPacMan
    {
        private readonly Offset _initialPosition;

        public PacMan(Offset position) :
            base(position, new PacManFrame())
        {
            _initialPosition = position;
            State = new CharacterState();
        }

        public CharacterState State { get; private set; }

        public bool IsDead { get; private set; }

        public void Kill() => IsDead = true;

        public void Ressurect() => IsDead = false;

        public void Eat(FoodContext context)
        {
            if (context.Eatable is IGhost ghost)
            {
                if (ghost.Mode == GhostMode.Frightened && ghost.Mode != GhostMode.Dead)
                {
                    ghost.Execute(context);
                }
                else if (ghost.Mode != GhostMode.Frightened && ghost.Mode != GhostMode.Dead)
                {
                    Kill();
                    Reset();
                    context.Ghosts.ToList().ForEach(actor => actor.Reset());
                    context.PacManState.DropLife();
                    context.EventSink.Publish(new PacManEaten());
                }
            }
            else
            {
                context.Eatable.Execute(context);
            }
        }

        public void Move(SelfMovementContext context)
        {
            // get next target based on ghost mode and corresponding movement strategy
            var currentVertex = Position.ToVertex();
            var currentTile = context.Map[currentVertex.Y, currentVertex.X];

            // check if ghost needs to change the direction
            if (Position == currentTile.Position)
            {
                var graph = context.Map.AsGraph();

                var allowedDirections = graph.GetNeighbors(currentVertex)
                    .Where(neighbor => !neighbor.IsWall)
                    .Select(neighbor => neighbor.ToOffset())
                    .Select(neighbor => Position.ToDirection(neighbor))
                    .ToList();

                // specified direction is not allowed, so stop
                State.Direction = !allowedDirections.Contains(context.PacManState.Direction)
                    ? Direction.None
                    : context.PacManState.Direction;
            }

            if (State.Direction != Direction.None)
            {
                var nextPosition = Position.Shift(State.Direction.ToOffset());
                var afterVertex = nextPosition.ToVertex();
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
    }
}
