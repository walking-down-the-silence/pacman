namespace PacMan
{
    public class CollisionContext
    {
        public CollisionContext(ISprite collisionObject)
        {
            CollisionObject = collisionObject;
        }

        public ISprite CollisionObject { get; }
    }
}
