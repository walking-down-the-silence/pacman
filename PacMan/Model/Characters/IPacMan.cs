namespace PacMan
{
    public interface IPacMan : ISprite, IResetable
    {
        CharacterState State { get; }

        bool IsDead { get; }

        void Kill();

        void Ressurect();

        void Eat(FoodContext context);

        void Move(SelfMovementContext context);
    }
}
