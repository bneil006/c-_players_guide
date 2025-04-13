using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public List<RobotCommandBase> Commands { get; } = new List<RobotCommandBase>();

        public void Run()
        {
            foreach (RobotCommandBase command in Commands)
            {
                command.Run(this);
                Console.WriteLine($"X: {X}, Y: {Y}, IsPowered: {IsPowered}");
            }
        }

        public void AddCommands(params List<RobotCommandBase> commands)
        {
            foreach (RobotCommandBase command in commands)
            {
                Commands.Add(command);
            }
        }

    }

    public abstract class RobotCommandBase
    {
        public abstract void Run(Robot robot);
        public virtual void UnPowered()
        {
            Console.WriteLine("Action can't be performed, Robot is powered off.");

        }
    }

    public class PowerOn : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            robot.IsPowered = true;
        }
    }

    public class PowerOff : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            robot.IsPowered = false;
        }
    }

    public class MoveNorthRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.Y += 1;
            }
            else
            {
                UnPowered();
            }
        }

        public override void UnPowered()
        {
            Console.WriteLine("Can't move North, Robot is powered off.");
        }
    }

    public class MoveSouthRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.Y -= 1;
            }
            else
            {
                UnPowered();
            }
        }
    }

    public class MoveWestRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X += 1;
            }
            else
            {
                UnPowered();
            }
        }
    }

    public class MoveEastRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X -= 1;
            }
            else
            {
                UnPowered();
            }
        }
    }
}
