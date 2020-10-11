namespace PacMan
{
    public class GameState
    {
        public GameState(int pacManLives)
        {
            PacManNextTurn = Direction.None;
            Lives = pacManLives;
        }

        public int Multiplier { get; private set; } = 1;

        public int Score { get; private set; } = 0;

        public int Lives { get; private set; }

        public Direction PacManNextTurn { get; private set; }

        public void SetNextDirection(Direction direction) => PacManNextTurn = direction;

        public void UpMultiplier() => Multiplier *= 2;

        public void DropMultiplier() => Multiplier = 1;

        public void UpScore(int points) => Score += points;

        public void DropLife() => Lives -= 1;
    }
}
