using System.Linq;

namespace PacMan
{
    public sealed class PowerPellet : SpriteBase, IFood
    {
        public PowerPellet(Offset position) :
            base(position, new PowerPelletFrame())
        {
        }

        public void Execute(FoodContext context)
        {
            context.Actors.Remove(this);
            context.Ghosts.ToList().ForEach(ghost => ghost.Frighten());
            context.GameState.UpScore(50);
            context.EventSink.Publish(new PelletEaten(true));
        }
    }
}
