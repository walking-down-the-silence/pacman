namespace PacMan
{
    public record ConsoleContext(int Fps, int OffsetX, int OffsetY) : IGameContext;
}
