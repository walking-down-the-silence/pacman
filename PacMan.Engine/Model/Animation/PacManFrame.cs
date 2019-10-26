namespace PacMan
{
    public sealed class PacManFrame : FrameBase
    {
        private const Color Full = Color.Yellow;

        public PacManFrame() : base(
            new[,]
            {
                { None, None, Full, Full, Full, Full, None },
                { None, Full, Full, Full, Full, Full, Full },
                { Full, Full, Full, Full, None, None, None },
                { Full, Full, Full, None, None, None, None },
                { Full, Full, Full, Full, None, None, None },
                { None, Full, Full, Full, Full, Full, Full },
                { None, None, Full, Full, Full, Full, None }
            })
        {
        }
    }
}
