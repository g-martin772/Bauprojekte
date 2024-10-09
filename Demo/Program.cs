using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Lib.Services;
using Lib.Data;


var serviceCollection = new ServiceCollection();
serviceCollection.AddLogging(configure =>
{
    configure.AddConsole();
    var logger = new LoggerConfiguration()
        .WriteTo.File("logs.txt")
        .CreateLogger();
    configure.AddSerilog(logger);
});

serviceCollection.AddSingleton<ProjectManager>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var projectManager = serviceProvider.GetRequiredService<ProjectManager>();

var project = new Project("My Project", "This is my project");
projectManager.AddProject(project);

var houseTask = new BuildTask
{
    Name = "Build a house",
    Description = "Build a big family house",
    Type = BuildTaskType.House
};

var gardenTask = new BuildTask
{
    Name = "Build a garden",
    Description = "Build a beautiful garden",
    Type = BuildTaskType.Garden
};

project.AddBuildTask(houseTask);
project.AddBuildTask(gardenTask);

gardenTask.AddMaterial(Material.Wood, 100);
gardenTask.AddMaterial(Material.Stone, 50);

houseTask.AddMaterial(Material.Wood, 1000);
houseTask.AddMaterial(Material.Stone, 500);
houseTask.AddMaterial(Material.Brick, 2000);
houseTask.AddMaterial(Material.Concrete, 300);
houseTask.AddMaterial(Material.Steel, 150);

var room1 = new BuildTask
{
    Name = "Living Room",
    Description = "Build a living room",
    Type = BuildTaskType.Room
};

houseTask.AddSubTask(room1);
room1.AddMaterial(Material.Wood, 100);
room1.AddMaterial(Material.Stone, 50);
room1.AddMaterial(Material.Brick, 200);
room1.AddMaterial(Material.Concrete, 30);


var room2 = new BuildTask
{
    Name = "Kitchen",
    Description = "Build a kitchen",
    Type = BuildTaskType.Room
};

houseTask.AddSubTask(room2);
room2.AddMaterial(Material.Wood, 50);
room2.AddMaterial(Material.Stone, 20);
room2.AddMaterial(Material.Brick, 100);
room2.AddMaterial(Material.Concrete, 20);

Console.ReadKey();