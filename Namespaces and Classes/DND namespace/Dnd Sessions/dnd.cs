using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND
{
    public static class SessionEvents
    {
        private static Dictionary<int, string> sessionEvent = new Dictionary<int, string>();
        private static Dictionary<int, (string, string, string)> locationPlayer = new Dictionary<int, (string, string, string)>();
        public static void AddEvent(string text, string location = "Unknown", string player = "Unknown", string dndEvent = "Unknown")
        {
            int id = sessionEvent.Count + 1;
            sessionEvent.Add(id, text);
            locationPlayer.Add(id, (dndEvent, player, location));
        }

        public static void RemoveEvent(int id, string text)
        {
            if (sessionEvent.ContainsKey(id))
            {
                sessionEvent.Remove(id);
            }
        }

        public static void UpdateEvent(int id, string text)
        {
            if (sessionEvent.ContainsKey(id))
            {
                sessionEvent[id] = text;
            }
        }

        public static void GetEvents()
        {
            foreach (var item in sessionEvent)
            {
                Console.Write(
                    $"ID:{item.Key}\n" +
                    $"EVENTS:\n" +
                    $"{item.Value}\n");
                Console.WriteLine();
            }
        }

        public static void GetLocationAndPlayer()
        {
            foreach (var item in locationPlayer)
            {
                Console.Write(item);
                Console.WriteLine();
            }
        }
    }
}
