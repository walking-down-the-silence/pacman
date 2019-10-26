namespace PacMan
{
    public sealed class PelletEaten : Event
    {
        public PelletEaten(bool powerPellet)
        {
            PowerPellet = powerPellet;
        }

        public bool PowerPellet { get; }
    }
}
