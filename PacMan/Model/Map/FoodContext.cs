namespace PacMan
{
    public class FoodContext
    {
        public FoodContext(
            IEventSink eventSink,
            ITilemap tilemap,
            GameState gameState,
            IEatable eatable)
        {
            EventSink = eventSink;
            Map = tilemap;
            GameState = gameState;
            Eatable = eatable;
        }

        public IEventSink EventSink { get; }

        public ITilemap Map { get; }

        public GameState GameState { get; }

        public IEatable Eatable { get; }
    }
}
