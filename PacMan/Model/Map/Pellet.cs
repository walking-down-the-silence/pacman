﻿namespace PacMan
{
    public sealed class Pellet : SpriteBase, IFood
    {
        public Pellet(Offset position) :
            base(position, new PelletFrame())
        {
        }

        public void Execute(FoodContext context)
        {
            context.Actors.Remove(this);
            context.GameState.UpScore(10);
            context.EventSink.Publish(new PelletEaten(false));
        }
    }
}
