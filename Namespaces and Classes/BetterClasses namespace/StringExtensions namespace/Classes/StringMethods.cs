using System;
using System.Text;

namespace BetterClasses.StringExtensions
{
    public static class StringExtensions
    {
        public static string AlternatingCapital(this string text)
        {
            string newMessage = "";
            int count = 2;
            foreach (char c in text)
            {
                string temp = Convert.ToString(c);
                if (count % 2 == 0)
                {
                    temp = temp.ToUpper();
                }
                else if (count % 2 == 1)
                {
                    temp = temp.ToLower();
                }

                newMessage += temp;
                count++;
            }

            return newMessage;
        }

        public static string Capitalize(this string text)
        {
            string newMessage = "";
            newMessage += text[0];
            newMessage = newMessage.ToUpper();

            text = text.Remove(0, 1);
            newMessage += text;

            return newMessage;
        }
    }
}
