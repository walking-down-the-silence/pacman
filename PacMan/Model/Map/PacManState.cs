namespace PacMan
{
    public class PacManState
    {
        public PacManState(int lives)
        {
            Direction = Direction.None;
            Lives = lives;
        }

        public Direction Direction { get; set; }

        public int Lives { get; private set; }

        public void DropLife() => Lives = Lives - 1;
    }
}
