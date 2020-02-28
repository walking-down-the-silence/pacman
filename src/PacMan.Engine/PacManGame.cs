using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PacMan
{
    public class PacManGame : GameEngineBase<IGameContext>
    {
        private readonly IEventSink _eventSink;
        private readonly IMapLoader<ITilemap> _mapLoader;
        private readonly GameState _gameState;
        private readonly ICollisionDetection _collisionDetection;
        private readonly ISpriteRenderer _renderer;
        private ITilemap _map;
        private DateTime _lastUpdateTime;

        public PacManGame(
            IEventSink eventSink,
            IMapLoader<ITilemap> mapLoader,
            ICollisionDetection collisionDetection,
            ISpriteRenderer renderer)
        {
            _eventSink = eventSink;
            _mapLoader = mapLoader;
            _gameState = new GameState(3);
            _collisionDetection = collisionDetection;
            _renderer = renderer;
        }

        public override Task Run(IGameContext context, CancellationToken token)
        {
            _map = _mapLoader.Load("Levels", "*.cshtml").First();
            _eventSink.Subscribe<ConsoleKeyPressedEvent>(new MovementHandler(_gameState).Handle);
            _eventSink.Subscribe<PelletEaten>(new FoodMonitorHandler(_map, this).Handle);
            _eventSink.Subscribe<CherryEaten>(new FoodMonitorHandler(_map, this).Handle);
            _renderer.Render(_map.ToSprite(new Offset(0, 0)));
            _lastUpdateTime = DateTime.Now;
            return base.Run(context, token);
        }

        protected override Task PhysicsStep(IGameContext context, CancellationToken token)
        {
            _renderer.Render(_map.ToSprite(new Offset(0, 0)));

            _collisionDetection
                .DetectCollisions(_map.PacMan, _map.All)
                .OfType<IEatable>()
                .ToList()
                .ForEach(eatable =>
                {
                    _map.PacMan.Effect(new FoodContext(_eventSink, _map, _gameState, eatable));
                    eatable.Effect(new FoodContext(_eventSink, _map, _gameState, _map.PacMan));
                });

            var deadGhostSprites = _map.Ghosts
                .Where(ghost => ghost.Mode == GhostMode.Dead)
                .Cast<ISprite>()
                .ToList();

            _map.All
                .OfType<IRespawnSprite>()
                .ToList()
                .ForEach(respawn =>
                {
                    _collisionDetection
                        .DetectCollisions(respawn, deadGhostSprites)
                        .OfType<IGhost>()
                        .ToList()
                        .ForEach(ghost => respawn.Effect(new GhostRespawnContext(ghost)));
                });

            // TODO: do the movement in a separate timers to simulate different speeds
            var selfMovementContext = new SelfMovementContext(_eventSink, _map, _gameState, _lastUpdateTime);
            _map.PacMan.Move(selfMovementContext);
            _map.PacMan.Move(selfMovementContext);
            _map.Ghosts.ToList().ForEach(ghost => ghost.Move(selfMovementContext));

            _lastUpdateTime = DateTime.Now;
            return Task.CompletedTask;
        }

        protected override Task InputHandle(IGameContext context, CancellationToken token)
        {
            var lastConsoleKey = Console.ReadKey().Key;
            _eventSink.Publish(new ConsoleKeyPressedEvent(lastConsoleKey));
            return Task.CompletedTask;
        }
    }
}
