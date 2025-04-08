using System;
using System.Diagnostics;

namespace PlayerHelpers
{
    public class DungeonGame
    {
        public Player player {  get; set; }
        public Dungeon dungeon { get; set; }
        private int arrows = 5;
        private bool fountainOnBool = false;
        
        public DungeonGame(Player player, Dungeon dungeon)
        {
            this.player = player;
            this.dungeon = dungeon;
            dungeon.SetDungeonRooms();
            dungeon.SetFountainLocation();
        }
        
        public void RunGame()
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bool win = WinGame();
            while (player.playerAlive == true && win == false)
            {
                ShowPosition();
                Prompt();
                PlayerEvent();
                win = WinGame();    
            }

            stopwatch.Stop();
            Console.WriteLine($"Game finished in: {stopwatch.Elapsed.ToString(@"mm\:ss")}");

        }

        private void ShowPosition()
        {
            Console.WriteLine($"Row:{player.playerPosition.Row}, Column:{player.playerPosition.Column}");
        }
        private bool WinGame()
        {
            if (fountainOnBool == true && player.playerPosition == (0, 0))
            {
                Console.WriteLine("YOU WIN!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PlayerEvent()
        {
            if (dungeon.dungeonRooms[player.playerPosition] == "Fountain Of Objects")
            {
                Console.WriteLine("You have found the Fountain Of Objects!");
            }
            else if (dungeon.dungeonRooms[player.playerPosition] == "Pit")
            {
                Console.WriteLine("You fell into a Snake pit surcame to a slow death of poison.");
                player.playerAlive = false;
            }
            else if (dungeon.dungeonRooms[player.playerPosition] == "Bear")
            {
                Console.WriteLine("You stumbled into a room with a bear and were eaten.");
                player.playerAlive = false;
            }
            else if (dungeon.dungeonRooms[player.playerPosition] == "Storm")
            {
                Console.WriteLine("You wandered into a storm and it attempts to move you One room North and Two Rooms East.");
                RequestedMoveCommand("Move North");
                ShowPosition();
                
                RequestedMoveCommand("Move East");
                ShowPosition();

                RequestedMoveCommand("Move East");
            }
        }

        private void Prompt()
        {
            string userResponse = String.Empty;
            List<string> moveCommands = new List<string>()
            {
                "Move North",
                "Move South",
                "Move West",
                "Move East",
            };

            List<string> shootCommands = new List<string>()
            {
                "Shoot North",
                "Shoot South",
                "Shoot West",
                "Shoot East"
            };

            List<string> senseCommands = new List<string>()
            {
                "Listen"
            };

            List<string> fountainCommands = new List<string>()
            {
                "Turn On",
                "Turn Off"
            };

            List<string> showCommands = new List<string>()
            {
                "Show Arrows",
                "Show Position",
                "Show Visited",
                "Clear Screen"
            };

            while (!moveCommands.Contains(userResponse) || shootCommands.Contains(userResponse))
            {
                Console.Write("What would you like to do? ");
                userResponse = Console.ReadLine();
                if (moveCommands.Contains(userResponse))
                {
                    RequestedMoveCommand(userResponse);
                }

                if (shootCommands.Contains(userResponse))
                {
                    if (arrows > 0)
                    {
                        RequestedShootCommand(userResponse);
                    }
                    else
                    {
                        Console.WriteLine("Out of Arrows.");
                    }
                }

                if (senseCommands.Contains(userResponse))
                {
                    SenseCommand(userResponse);
                }

                if (fountainCommands.Contains(userResponse))
                {
                    RequestFountainCommand(userResponse);
                }

                if (showCommands.Contains(userResponse))
                {
                    ShowCommand(userResponse);
                }

                if (userResponse == "Help")
                {
                    Console.WriteLine();
                    Console.WriteLine("You can use any of the Below Commands");
                    List<string> allCommands = new List<string>();

                    Console.WriteLine("MOVEMENT COMMANDS [YOU CAN DO THIS ANYTIME]");
                    foreach (string command in moveCommands)
                    {
                        Console.WriteLine(command);
                    }
                    Console.WriteLine();

                    Console.WriteLine("SHOOT COMMANDS [YOU HAVE 5 ARROWS TOTAL]");
                    foreach (string command in shootCommands)
                    {
                        Console.WriteLine(command);
                    }
                    Console.WriteLine();

                    Console.WriteLine("SENSE COMMANDS [YOU CAN DO THIS ANYTIME]");
                    foreach (string command in senseCommands)
                    {
                        Console.WriteLine(command);
                    }
                    Console.WriteLine();

                    Console.WriteLine("FOUNTAIN COMMANDS [YOU CAN ONLY DO THIS IN THE FOUNTAIN OF OBJECTS ROOM]");
                    foreach (string command in fountainCommands)
                    {
                        Console.WriteLine(command);
                    }
                    Console.WriteLine();

                    Console.WriteLine("SHOW COMMANDS [YOU CAN DO THIS ANYTIME]");
                    foreach (string command in showCommands)
                    {
                        Console.WriteLine(command);
                    }
                    Console.WriteLine();
                }
            }
        }

        private void ShowCommand(string validCommand)
        {
            switch (validCommand)
            {
                case "Show Arrows":
                    Console.WriteLine($"You have: {arrows} arrows left.");
                    break;
                case "Show Position":
                    ShowPosition();
                    break;
                case "Show Visited":
                    player.ShowVisitedRooms();
                    break;
                case "Clear Screen":
                    Console.Clear();
                    break;
            }
        }

        private void RequestFountainCommand(string validCommand)
        {
            if (dungeon.dungeonRooms[player.playerPosition] == "Fountain Of Objects")
            {
                switch (validCommand)
                {
                    case "Turn On":
                        fountainOnBool = true;
                        Console.WriteLine($"The Fountain Of Objects is Turned On.");
                        break;
                    case "Turn Off":
                        fountainOnBool = false;
                        Console.WriteLine($"The Fountain Of Objects is Turned Off.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No fountain in this room, unable to interact with fountain.");
            }
        }

        private (int, int) RequestedMoveCommand(string validCommand)
        {
            int max = MaxSizeCheck();

            switch (validCommand)
            {
                case "Move North":
                    if (player.playerPosition.Row < max) { player.MoveNorth(1); }
                    else { Console.WriteLine("You can go no farther North."); }
                    break;
                case "Move South":
                    if (player.playerPosition.Row > 0) { player.MoveSouth(1); }
                    else { Console.WriteLine("You can go no farther South."); }
                    break;
                case "Move West":
                    if (player.playerPosition.Column > 0) { player.MoveWest(1); }
                    else { Console.WriteLine("You can go no farther West."); }
                    break;
                case "Move East":
                    if (player.playerPosition.Column < max) { player.MoveEast(1); }
                    else { Console.WriteLine("You can go no farther East."); }
                    break;
            }
            return player.playerPosition;
        }

        private void RequestedShootCommand(string validCommand)
        {
            int max = MaxSizeCheck();

            var northOfPlayer = (player.playerPosition.Row + 1, player.playerPosition.Column);
            var southOfPlayer = (player.playerPosition.Row - 1, player.playerPosition.Column);
            var westOfPlayer = (player.playerPosition.Row, player.playerPosition.Column - 1);
            var eastOfPlayer = (player.playerPosition.Row, player.playerPosition.Column + 1);

            void CheckRooms((int, int) position, string direction)
            {
                if (dungeon.pitRooms.Contains(position)) { Console.WriteLine($"You hear hissing from the room {direction} of you. (Snake Pit)"); }
                if (dungeon.stormRooms.Contains(position)) { Console.WriteLine($"You hear loud winds from the room {direction} of you. (Storm)"); }
                if (dungeon.bearRooms.Contains(position)) { Console.WriteLine($"You hear a loud growing from the room {direction} of you. (Bear)"); }
            }

            switch (validCommand)
            {
                case "Listen":
                    CheckRooms(northOfPlayer, "north");
                    CheckRooms(southOfPlayer, "south");
                    CheckRooms(westOfPlayer, "west");
                    CheckRooms(eastOfPlayer, "east");
                    break;
                case "Shoot North":
                    if (dungeon.bearRooms.Contains(northOfPlayer))
                    {
                        dungeon.bearRooms.Remove(northOfPlayer);
                        dungeon.dungeonRooms[northOfPlayer] = "Empty";
                        Console.WriteLine($"You shot a bear in Room North of you.");
                    }
                    else
                    {
                        Console.WriteLine("You shot and hit nothing.");
                    }
                    break;
                case "Shoot South":
                    if (dungeon.bearRooms.Contains(southOfPlayer))
                    {
                        dungeon.bearRooms.Remove(southOfPlayer);
                        dungeon.dungeonRooms[southOfPlayer] = "Empty";
                        Console.WriteLine($"You shot a bear in Room South of you.");
                    }
                    else
                    {
                        Console.WriteLine("You shot and hit nothing.");
                    }
                    break;
                case "Shoot West":
                    if (dungeon.bearRooms.Contains(westOfPlayer))
                    {
                        dungeon.bearRooms.Remove(westOfPlayer);
                        dungeon.dungeonRooms[westOfPlayer] = "Empty";
                        Console.WriteLine($"You shot a bear in Room West of you.");
                    }
                    else
                    {
                        Console.WriteLine("You shot and hit nothing.");
                    }
                    break;
                case "Shoot East":
                    if (dungeon.bearRooms.Contains(eastOfPlayer))
                    {
                        dungeon.bearRooms.Remove(eastOfPlayer);
                        dungeon.dungeonRooms[eastOfPlayer] = "Empty";
                        Console.WriteLine($"You shot a bear in Room East of you.");
                    }
                    else
                    {
                        Console.WriteLine("You shot and hit nothing.");
                    }
                    break;
            }

            arrows -= 1;
        }

        private void SenseCommand(string validCommand)
        {
            var northOfPlayer = (player.playerPosition.Row + 1, player.playerPosition.Column);
            var southOfPlayer = (player.playerPosition.Row - 1, player.playerPosition.Column);
            var westOfPlayer = (player.playerPosition.Row, player.playerPosition.Column - 1);
            var eastOfPlayer = (player.playerPosition.Row, player.playerPosition.Column + 1);

            void CheckRooms((int, int) position, string direction)
            {
                if (dungeon.pitRooms.Contains(position)) { Console.WriteLine($"You hear hissing from the room {direction} of you. (Snake Pit)"); }
                if (dungeon.stormRooms.Contains(position)) { Console.WriteLine($"You hear loud winds from the room {direction} of you. (Storm)"); }
                if (dungeon.bearRooms.Contains(position)) { Console.WriteLine($"You hear a loud growing from the room {direction} of you. (Bear)"); }
            }

            switch (validCommand)
            {
                case "Listen":
                    CheckRooms(northOfPlayer, "north");
                    CheckRooms(southOfPlayer, "south");
                    CheckRooms(westOfPlayer, "west");
                    CheckRooms(eastOfPlayer, "east");
                    break;
            }
        }

        private int MaxSizeCheck()
        {
            int max = 0;
            switch (dungeon.roomSizeType)
            {
                case "Small":
                    max = 3;
                    break;
                case "Medium":
                    max = 5;
                    break;
                case "Large":
                    max = 7;
                    break;
            }
            return max;
        }
    }
}