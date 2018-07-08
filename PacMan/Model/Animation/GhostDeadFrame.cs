namespace PacMan
{
    public sealed class GhostDeadFrame : FrameBase
    {
        private const Color Eyes = Color.White;
        private const Color Pupl = Color.Cyan;

        public GhostDeadFrame() : base(
            new[,]
            {
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None },
                { None, Eyes, Eyes, None, Eyes, Eyes, None },
                { None, Eyes, Pupl, None, Eyes, Pupl, None },
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None }
            })
        {
        }
    }
}
