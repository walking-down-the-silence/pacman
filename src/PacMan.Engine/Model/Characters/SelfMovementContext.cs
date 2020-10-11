using System;

namespace PacMan
{
    public record SelfMovementContext(IEventSink EventSink, ITilemap Map, GameState GameState, DateTime CurrentTime);
}
