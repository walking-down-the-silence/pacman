namespace PacMan
{
    public interface IPacMan : ISprite, IResetable, IEatable
    {
        CharacterState State { get; }

        bool IsDead { get; }

        void Kill();

        void Ressurect();

        void Move(SelfMovementContext context);
    }
}
