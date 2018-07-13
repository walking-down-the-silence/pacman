namespace PacMan
{
    public sealed class Cherry : SpriteBase, IFood
    {
        public Cherry(Offset position) :
            base(position, new CherryFrame())
        {
        }

        public void Effect(FoodContext context)
        {
            context.Map.All.Remove(this);
            context.GameState.UpScore(100);
            context.EventSink.Publish(new CherryEaten());
        }
    }
}
