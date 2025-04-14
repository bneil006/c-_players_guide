////SessionEvents.AddEvent(
////    location: "",
////    player: "",
////    text:
////    "");

//SessionEvents.GetEvents();
//Console.WriteLine();
//SessionEvents.GetEventDetails();

//SessionEvents.WriteEventsToFile("");

namespace DND
{
    public static class SessionEvents
    {
        private static Dictionary<int, string> sessionEvent = new Dictionary<int, string>();
        private static Dictionary<int, (string, string, string)> logDetails = new Dictionary<int, (string, string, string)>();
        public static void AddEvent(string text, string location = "Unknown", string player = "Unknown", string dndEvent = "Unknown")
        {
            int id = sessionEvent.Count + 1;
            sessionEvent.Add(id, text);
            logDetails.Add(id, (dndEvent, player, location));
        }

        public static void RemoveEvent(int id)
        {
            if (sessionEvent.ContainsKey(id))
            {
                sessionEvent.Remove(id);
                logDetails.Remove(id);
            }
        }

        public static void UpdateEvent(int id, string text, string location = "Unknown", string player = "Unknown", string dndEvent = "Unknown")
        {
            if (sessionEvent.ContainsKey(id))
            {
                sessionEvent[id] = text;
                logDetails[id] = (dndEvent, location, player);
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

        public static void GetEventDetails()
        {
            foreach (var item in logDetails)
            {
                Console.Write(item);
                Console.WriteLine();
            }
        }

        public static void WriteEventsToFile(string fileName)
        {
            string fullSession = $"";
            foreach (var item in sessionEvent)
            {
                fullSession += 
                    $"ID:" +
                    $"{item.Key}\n" +
                    $"EVENTS:\n" +
                    $"{item.Value}\n";

            }

            foreach (var item in logDetails)
            {
                fullSession +=
                    $"ID:" +
                    $"{item.Key}\n" + 
                    $"DETAILS:\n" +
                    $"{item.Value}\n";
            }
            File.WriteAllText($"C:\\Users\\brmne\\Desktop\\C# Projects\\workspaces\\github.com\\players_guide\\Namespaces and Classes\\Files\\{fileName}.txt", fullSession);
        }
    }
}
