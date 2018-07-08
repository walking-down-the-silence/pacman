namespace PacMan
{
    public class GhostNormalFrame : FrameBase
    {
        private const Color Eyes = Color.White;
        private const Color Pupl = Color.Blue;

        public GhostNormalFrame(Color body) : base(
            new[,]
            {
                { None, None, body, body, body, None, None },
                { None, body, body, body, body, body, None },
                { body, Eyes, Eyes, body, Eyes, Eyes, body },
                { body, Eyes, Pupl, body, Eyes, Pupl, body },
                { body, body, body, body, body, body, body },
                { body, body, body, body, body, body, body },
                { body, None, body, None, body, None, body }
            })
        {
        }
    }
}
