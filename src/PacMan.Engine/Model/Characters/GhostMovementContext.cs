namespace PacMan
{
    public record GhostMovementContext(IEventSink EventSink, ITilemap Map, IGhost Ghost);
}
