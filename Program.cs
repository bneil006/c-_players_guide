using System;
using PlayerHelpers;

Robot myRobot = new Robot();

myRobot.Commands.Add(new OnCommand());
myRobot.Commands.Add(new NorthCommand());
myRobot.Commands.Add(new SouthCommand());
myRobot.Commands.Add(new WestCommand());
myRobot.Commands.Add(new EastCommand());
myRobot.Commands.Add(new OffCommand());

myRobot.Run();
Console.WriteLine();

Robot mySecondRobot = new Robot();
mySecondRobot.AddCommands(new OnCommand(), new NorthCommand(), new SouthCommand(), new WestCommand(), new EastCommand(), new OffCommand());
mySecondRobot.Run();

Console.ReadLine();