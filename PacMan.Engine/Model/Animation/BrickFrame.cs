namespace PacMan
{
    public sealed class BrickFrame : FrameBase
    {
        private const Color Full = Color.DarkBlue;

        public BrickFrame() : base(
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
