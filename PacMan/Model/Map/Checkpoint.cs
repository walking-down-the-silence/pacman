namespace PacMan
{
    public class Checkpoint : SpriteBase, ICheckpoint
    {
        public Checkpoint(Offset position) : base(position, new TransparentFrame())
        {
        }
    }
}
