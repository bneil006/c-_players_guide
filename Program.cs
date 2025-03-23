using System;
using PlayerHelpers;

Robot myRobot = new Robot();
myRobot.AddCommands(new PowerOn(), new PowerOff(), new MoveNorth(), new MoveSouth(), new MoveWest(), new MoveEast(), new PowerOff());

myRobot.Run();
foreach (RobotCommandBase command in myRobot.Commands)
{
    Console.WriteLine(command.ToString());
}
Console.ReadLine();