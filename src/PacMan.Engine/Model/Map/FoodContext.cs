namespace PacMan
{
    public record FoodContext(
        IEventSink EventSink,
        ITilemap Map,
        GameState GameState,
        IEatable Eatable);
}
