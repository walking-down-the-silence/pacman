using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PacMan
{
    internal static partial class Program
    {
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
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEventSink, EventSink>()
                .AddSingleton<IMapLoader<ITilemap>, MapLoader>()
                .AddSingleton<ICollisionDetection, TwoPhaseCollisionDetection>()
                .AddSingleton<IOverlappingStrategy, PixelPerfectOverlapCheck>()
                .AddSingleton<ISpriteRenderer>(new SpriteDifferenceRenderer(new ConsoleSpriteRenderer()))
                .AddSingleton<IGameEngine<ConsoleContext>, PacManGame>();
        }

        public static void Configure(IServiceProvider serviceProvider)
        {
            Console.SetWindowSize(266, 147);
            Console.SetWindowPosition(0, 0);
            Console.Title = "Pac-Man";
        }
    }
}
