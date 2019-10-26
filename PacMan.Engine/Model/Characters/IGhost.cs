namespace PacMan
{
    public interface IGhost : ISprite, IResetable, IEatable
    {
        GhostMode Mode { get; }

        CharacterState State { get; }

        void Kill();

        void Ressurect();

        void Frighten();

        void Comfort();

        void Move(SelfMovementContext context);
    }
}
