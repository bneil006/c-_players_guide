namespace Challenges
{
    public class PasswordValidator
    {
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                bool noCapitalLetterT = true; // requirement of Ingelmar in IT on page 192 of C# Players Guide to not contain a Capital T
                bool noAmperstand = true; // requirment of Ingelmar in IT on page 192 of C# Players Guide to not contain a &

                bool lengthRequirements = false;
                bool oneUppercaseLetter = false;
                bool oneLowercaseLetter = false;
                bool hasSpecialCharacter = false;
                bool hasDigit = false;

                List<char> specialCharacters = new List<char>() { '!', '@', '#', '$', '%', '^', '*' };

                if (value.Count<char>() < 6)
                {
                    Console.WriteLine("Password to short. Min 6 characters, Max 13 characters");
                }
                else if (value.Count<char>() > 13)
                {
                    Console.WriteLine("Password to long. Min 6 characters, Max 13 characters");
                }
                else
                {
                    lengthRequirements = true;
                }

                foreach (char c in value)
                {
                    if (c == 'T')
                    {
                        Console.WriteLine("\"T\" is not allowed in the password.");
                        noCapitalLetterT = false;
                    }
                    else if (c == '&')
                    {
                        Console.WriteLine("\"&\" is not allowed in the password.");
                        noAmperstand = false;
                    }
                    else if (char.IsUpper(c))
                    {
                        oneUppercaseLetter = true;
                    }
                    else if (char.IsLower(c))
                    {
                        oneLowercaseLetter = true;
                    }
                    else if (char.IsDigit(c))
                    {
                        hasDigit = true;
                    }
                }

                foreach(char c in value)
                {
                    if (specialCharacters.Contains(c))
                    {
                        hasSpecialCharacter = true;
                    }
                }

                if (!oneUppercaseLetter)
                {
                    Console.WriteLine("Atleast One Uppercase Letter required in password.");
                }
                else if (!oneLowercaseLetter)
                {
                    Console.WriteLine("Atleast One Lowercase Letter required in password.");
                }
                else if (!hasDigit)
                {
                    Console.WriteLine("Atleast One Digit required in password.");
                }
                else if (!hasSpecialCharacter)
                {
                    Console.WriteLine("Atleast One Special required in password.");
                }

                if (
                    noCapitalLetterT == true
                    && noAmperstand == true
                    && lengthRequirements == true
                    && oneUppercaseLetter == true
                    && oneLowercaseLetter == true
                    && hasSpecialCharacter == true
                    && hasDigit == true)
                {
                    password = value;
                }

            }
        }
        public PasswordValidator(string password)
        {
            Password = password;
        }
    }


}