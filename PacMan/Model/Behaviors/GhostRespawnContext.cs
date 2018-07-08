namespace PacMan
{
    public class GhostRespawnContext
    {
        public GhostRespawnContext(IGhost ghost)
        {
            Ghost = ghost;
        }

        public IGhost Ghost { get; }
    }
}
