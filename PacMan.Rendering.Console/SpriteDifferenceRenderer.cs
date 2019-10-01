namespace PacMan
{
    public class SpriteDifferenceRenderer : ISpriteRenderer
    {
        private ISprite _previous;
        private readonly ISpriteRenderer _renderer;

        public SpriteDifferenceRenderer(ISpriteRenderer renderer)
        {
            _renderer = renderer;
        }

        public void Render(ISprite source)
        {
            if (_previous == null)
            {
                _renderer.Render(source);
            }
            else
            {
                ISprite differenceView = _previous.GetBitmapDifference(source, Color.Black);
                _renderer.Render(differenceView);
            }

            _previous = source;
        }
    }
}
