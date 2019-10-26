namespace PacMan
{
    public sealed class PelletFrame : FrameBase
    {
        private const Color Full = Color.White;

        public PelletFrame() : base(
            new[,]
            {
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None },
                { None, None, None, Full, None, None, None },
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None }
            })
        {
        }
    }
}
