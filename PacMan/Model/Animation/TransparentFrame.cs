namespace PacMan
{
    public sealed class TransparentFrame : FrameBase
    {
        private const Color Full = Color.Transparent;

        public TransparentFrame() : base(
            new[,]
            {
                { Full, Full, Full, Full, Full, Full, Full },
                { Full, Full, Full, Full, Full, Full, Full },
                { Full, Full, Full, Full, Full, Full, Full },
                { Full, Full, Full, Full, Full, Full, Full },
                { Full, Full, Full, Full, Full, Full, Full },
                { Full, Full, Full, Full, Full, Full, Full },
                { Full, Full, Full, Full, Full, Full, Full }
            })
        {
        }
    }
}
