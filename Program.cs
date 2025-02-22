/*
    Starting again from scratch and creating the same method to give the farmer a way to calculate the area of all his triangles.
    Wanted to do this to put to test my C# knowledge that I gained lastnight.
*/

List<(float, float)> farmerTriangles = new List<(float, float)> {  }; // all the farmers Triangles (Base (b), Height (h))

static List<float> triangleAreas(List<(float, float)> triangles)
{
    List<float> result = new List<float> { };
    foreach ((float, float) item in triangles)
    {
        result.Add((item.Item1 * item.Item2) / 2); // triangle area formula (base * height) / 2
    }
    return result;
}

var farmerAssets = triangleAreas(farmerTriangles);


bool addToList = true;
while (addToList == true)
{
    Console.WriteLine("Would you like to add anymore items to your triangle List? [YES / NO]");
    string response = Console.ReadLine();

    if (response == "yes" || response == "Yes" || response == "YES")
    {
        Console.WriteLine("What is the new items base? ");
        string newBase = Console.ReadLine();
        int newerBase = Convert.ToInt32(newBase); // i feel like there has to be a better way to convert string to int on user inputs from the ReadLine Method.

        Console.WriteLine("What is the new items height? ");
        string newHeight = Console.ReadLine();
        int newerHeight = Convert.ToInt32(newHeight);

        farmerTriangles.Add((newerBase, newerHeight));

        int newArea = (newerBase * newerHeight) / 2;
        farmerAssets.Add(newArea);
    }
    else
    {
        addToList = false;
    }
}

bool checkLists = true;
while (checkLists == true)
{
    Console.WriteLine("If you would like to see all the Base, Height pairs in your farmerTriangles or all areas in farmerAssets variable TYPE FT OR FA or Quit with any other entry");
    string userSecondResponse = Console.ReadLine();
    if (userSecondResponse == "FT")
    {
        foreach ((float, float) item in farmerTriangles)
        {
            Console.WriteLine($"BASE: {item.Item1}, HEIGHT: {item.Item2}");
        }
    }
    else if (userSecondResponse == "FA")
    {
        foreach (float item in farmerAssets)
        {
            Console.WriteLine($"AREA: {item}");
        }
    }
    else
    {
        checkLists = false;
    }
}



