using System.Linq;

namespace PacMan
{
    public class FoodMonitorHandler :
        IHandler<PelletEaten>,
        IHandler<CherryEaten>
    {
        private readonly ITilemap _tilemap;
        private readonly IGameEngine<IGameContext> _gameEngine;

        public FoodMonitorHandler(ITilemap tilemap, IGameEngine<IGameContext> gameEngine)
        {
            _tilemap = tilemap;
            _gameEngine = gameEngine;
        }

        public void Handle(CherryEaten value)
        {
            InternalCheck();
        }

        public void Handle(PelletEaten value)
        {
            InternalCheck();
        }

        private void InternalCheck()
        {
            if (!_tilemap.All.OfType<IFood>().Any())
            {
                _gameEngine.TokenSource.Cancel();
            }
        }
    }
}
