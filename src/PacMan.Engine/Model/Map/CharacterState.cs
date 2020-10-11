namespace PacMan
{
    public record CharacterState(Offset Target, Direction Direction)
    {
        public static CharacterState Default => new(Offset.Default, Direction.None);
    }
}
