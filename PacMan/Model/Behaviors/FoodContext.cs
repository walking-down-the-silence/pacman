using System.Collections.Generic;

namespace PacMan
{
    public class FoodContext
    {
        public FoodContext(
            IEventSink eventSink,
            ICollection<ISprite> actors,
            ICollection<IGhost> ghosts,
            PacManState pacmanState, 
            GameState gameState, 
            IEatableBehavior eatable)
        {
            EventSink = eventSink;
            Actors = actors;
            Ghosts = ghosts;
            PacManState = pacmanState;
            GameState = gameState;
            Eatable = eatable;
        }

        public IEventSink EventSink { get; }

        public ICollection<ISprite> Actors { get; }

        public ICollection<IGhost> Ghosts { get; }

        public PacManState PacManState { get; }

        public GameState GameState { get; }

        public IEatableBehavior Eatable { get; }
    }
}
