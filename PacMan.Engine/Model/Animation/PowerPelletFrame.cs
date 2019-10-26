namespace PacMan
{
    public sealed class PowerPelletFrame : FrameBase
    {
        private const Color Full = Color.White;

        public PowerPelletFrame() : base(
            new[,]
            {
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None },
                { None, None, Full, Full, Full, None, None },
                { None, None, Full, Full, Full, None, None },
                { None, None, Full, Full, Full, None, None },
                { None, None, None, None, None, None, None },
                { None, None, None, None, None, None, None }
            })
        {
        }
    }
}
