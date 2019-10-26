using System;

namespace PacMan
{
    public class SelfMovementContext
    {
        public SelfMovementContext(IEventSink eventSink, ITilemap map, GameState gameState, DateTime lastUpdateTime)
        {
            EventSink = eventSink;
            Map = map;
            GameState = gameState;
            LastUpdateTime = lastUpdateTime;
            CurrentTime = DateTime.Now;
        }

        public IEventSink EventSink { get; }

        public ITilemap Map { get; }

        public GameState GameState { get; }

        public DateTime LastUpdateTime { get; }

        public DateTime CurrentTime { get; }
    }
}
