namespace PacMan
{
    public class Brick : SpriteBase
    {
        public Brick(Offset position) : 
            base(position, new BrickFrame())
        {
        }
    }
}
