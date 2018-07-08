namespace PacMan
{
    public sealed class Cherry : SpriteBase, IFood
    {
        public Cherry(Offset position) :
            base(position, new CherryFrame())
        {
        }

        public void Execute(FoodContext context)
        {
            context.Actors.Remove(this);
            context.GameState.UpScore(100);
            context.EventSink.Publish(new CherryEaten());
        }
    }
}
