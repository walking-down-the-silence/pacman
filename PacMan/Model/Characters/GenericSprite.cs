namespace PacMan
{
    public class GenericSprite : SpriteBase
    {
        public GenericSprite(Offset position, Color[,] colors) :
            base(position, new GenericFrame(colors))
        {
        }
    }
}
