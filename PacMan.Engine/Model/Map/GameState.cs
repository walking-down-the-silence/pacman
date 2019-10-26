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

        public Direction PacManNextTurn { get; set; }

        public void UpMultiplier() => Multiplier = Multiplier * 2;

        public void DropMultiplier() => Multiplier = 1;

        public void UpScore(int points) => Score = Score + points;

        public void DropLife() => Lives = Lives - 1;
    }
}
