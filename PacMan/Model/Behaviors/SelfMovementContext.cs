using System;

namespace PacMan
{
    public class SelfMovementContext
    {
        public SelfMovementContext(IEventSink eventSink, ITilemap map, PacManState pacManState, DateTime lastUpdateTime)
        {
            EventSink = eventSink;
            Map = map;
            PacManState = pacManState;
            LastUpdateTime = lastUpdateTime;
            CurrentTime = DateTime.Now;
        }

        public IEventSink EventSink { get; }

        public ITilemap Map { get; }

        public PacManState PacManState { get; }

        public DateTime LastUpdateTime { get; }

        public DateTime CurrentTime { get; }
    }
}
