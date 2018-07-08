namespace PacMan
{
    public class GameState
    {
        public int Multiplier { get; private set; } = 1;

        public int Score { get; private set; } = 0;

        public void UpMultiplier() => Multiplier = Multiplier * 2;

        public void DropMultiplier() => Multiplier = 1;

        public void UpScore(int points) => Score = Score + points;
    }
}
