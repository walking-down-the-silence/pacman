namespace PacMan
{
    public class GhostMovementContext
    {
        public GhostMovementContext(IEventSink eventSink, ITilemap map, IGhost ghost)
        {
            EventSink = eventSink;
            Map = map;
            Ghost = ghost;
        }

        public IEventSink EventSink { get; }

        public ITilemap Map { get; }

        public IGhost Ghost { get; }
    }
}
