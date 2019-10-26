namespace PacMan
{
    public class CharacterState
    {
        public CharacterState()
        {
            Target = Offset.Default;
            Direction = Direction.None;
        }

        public Offset Target { get; set; }

        public Direction Direction { get; set; }
    }
}
