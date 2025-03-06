using Microsoft.Extensions.DependencyInjection;
using W7_assignment_template.Data;
using W7_assignment_template.Interfaces;
using W7_assignment_template.Models.Characters;
using W7_assignment_template.Models.Rooms;
using W7_assignment_template.Services;

namespace W7_assignment_template;

internal class Program
{
    private static void ConfigureServices(IServiceCollection services)
    {
        // Register services for DI
        services.AddTransient<GameEngine>();
        services.AddTransient<MenuManager>();
        services.AddTransient<MapManager>();
        services.AddSingleton<OutputManager>();

        // Register Room and RoomFactory
        services.AddTransient<IRoom, Room>();
        services.AddTransient<IRoomFactory, RoomFactory>();

        // Register IContext
        services.AddSingleton<IContext, DataContext>();
    }


    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var gameEngine = serviceProvider.GetService<GameEngine>();

        gameEngine?.Run();
    }
}
