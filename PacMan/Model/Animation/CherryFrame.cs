namespace PacMan
{
    public sealed class CherryFrame : FrameBase
    {
        private const Color Full = Color.Red;

        public CherryFrame() : base(
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
