using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PacMan
{
    internal static partial class Program
    {
        private static int _bufferHeight;
        private static int _bufferWidth;
        private static int _windowHeight;
        private static int _windowWidth;

        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            Configure(serviceProvider);

            var cts = new CancellationTokenSource();
            await serviceProvider
                .GetService<IGameEngine<ConsoleContext>>()
                .Run(new ConsoleContext(50, 0, 0), cts.Token);

            Restore(serviceProvider);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEventSink, EventSink>()
                .AddSingleton<IMapLoader<ITilemap>, MapLoader>()
                .AddSingleton<ICollisionDetection, TwoPhaseCollisionDetection>()
                .AddSingleton<ISpriteRenderer>(new SpriteDifferenceRenderer(new ConsoleSpriteRenderer()))
                .AddSingleton<IGameEngine<ConsoleContext>, PacManGame>();
        }

        public static void Configure(IServiceProvider serviceProvider)
        {
            _bufferHeight = Console.BufferHeight;
            _bufferWidth = Console.BufferWidth;
            _windowHeight = Console.WindowHeight;
            _windowWidth = Console.WindowWidth;
            Console.SetBufferSize(276, 157);
            Console.SetWindowSize(266, 147);
            Console.SetWindowPosition(0, 0);
            Console.Title = "Pac-Man";
        }

        public static void Restore(IServiceProvider serviceProvider)
        {
            Console.SetBufferSize(_bufferHeight, _bufferWidth);
            Console.SetWindowSize(_windowHeight, _windowWidth);
        }
    }
}
