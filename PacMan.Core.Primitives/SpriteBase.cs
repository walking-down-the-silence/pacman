namespace PacMan
{
    public abstract class SpriteBase : ISprite
    {
        private IFrame _currentFrame;
        
        protected SpriteBase(Offset position, IFrame frame)
        {
            _currentFrame = frame;
            Position = position;
        }

        public Color this[int y, int x] => _currentFrame[y, x];

        public Offset Position { get; protected set; }

        public Size Size => _currentFrame.Size;

        protected void SetCurrentFrame(IFrame frame)
        {
            _currentFrame = frame;
        }
    }
}
