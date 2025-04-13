namespace Challenges
{
    public class Door
    {
        private int passcode;
        private string doorState = "LOCKED";

        public Door(int intPasscode)
        {
            this.passcode = intPasscode;
        }

        public void InteractWithDoor()
        {
            Console.WriteLine("AVALIABLE ACTIONS:");
            Console.WriteLine("OPEN, CLOSE, LOCK, UNLOCK, CHANGE PASSWORD, STOP");
            Console.WriteLine();

            AskUserForAction();
        }

        private void AskUserForAction()
        {
            while (true)
            {

                Console.WriteLine($"The door is {doorState}");
                Console.WriteLine($"What would you like to do: ");
                string userResponse = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (userResponse == "UNLOCK" && (doorState == "LOCKED"))
                {
                    UnlockDoor();
                }
                else if (userResponse == "OPEN" && (doorState == "UNLOCKED" || userResponse == "OPEN" && doorState == "CLOSED"))
                {
                    OpenDoor();
                }
                else if (userResponse == "CLOSE" && doorState == "OPEN")
                {
                    CloseDoor();
                }
                else if (userResponse == "LOCK" && (doorState == "CLOSED" || userResponse == "LOCK" && doorState == "UNLOCKED"))
                {
                    LockDoor();
                }
                else if (userResponse == "CHANGE PASSWORD" || userResponse == "PASSWORD")
                {
                    Console.Write("Provide the current password: ");
                    int userPasswordResponse = int.Parse(Console.ReadLine());
                    ChangePasscode(userPasswordResponse, passcode);
                }
                else if (userResponse == "STOP")
                {
                    break;
                }

            }
        }

        private void UnlockDoor()
        {
            Console.Write($"Please provide the pin to unlock the door: ");
            int userProvidedPasscode = int.Parse(Console.ReadLine());
            if (passcode == userProvidedPasscode)
            {
                doorState = "UNLOCKED";
                AskUserForAction();
            }
            else
            {
                Console.WriteLine("Wrong passcode provided.");
                Console.WriteLine();
                AskUserForAction();
            }
        }

        private void OpenDoor()
        {
            doorState = "OPEN";
            AskUserForAction();
        }

        private void CloseDoor()
        {
            doorState = "CLOSED";
            AskUserForAction();
        }

        private void LockDoor()
        {
            doorState = "LOCKED";
            AskUserForAction();
        }

        private void ChangePasscode(int newPasscode, int oldPasscode)
        {
            if (oldPasscode == newPasscode)
            {
                Console.Write("New Passcode PIN #: ");
                int response = int.Parse(Console.ReadLine());

                Console.WriteLine($"Passcode changed.");
                Console.WriteLine();

                passcode = response;
                AskUserForAction();
            }
            else
            {
                Console.WriteLine($"Passcode not changed, wrong current passcode.");
                Console.WriteLine();
            }
        }
    }

}