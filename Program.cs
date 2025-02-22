/*
The Method / Function below could be a static void if we didn't want to return anything from it, but since we do and since it is a float
that we want to return, we will call this a static float and return similar to python with a return statment.
Super simple feeling atleast currently.
*/

/*
Also got a little tired of waiting and moved onto dive a little further into the arrays - I was looking into Lists when i realized that in C# and Python they are different
an Array and a List in python seem like the same thing, and Array was what I was essentially looking for here (I think)
 */

static float TriangleFarmerSingle(int b, int h)
{
    return (b * h) / 2f;
}

TriangleFarmerSingle(5, 10); // received out result back but haven't yet printed it or assigned it to a variable so its basically doing nothing here.

// this is all feeling super similar to python, I guess learning the fundementals of one language does have some seriously good translation effects on other languages.
float firstSingleTriangle = TriangleFarmerSingle(5, 10);
Console.WriteLine($"using the variable assigned to the value of TriangleFarmerSingle(5, 10) (firstSingleTriangle): {firstSingleTriangle}");
Console.WriteLine($"using the Method directly in the Console.WriteLine(TriangleFarmerSingle(7, 12): {TriangleFarmerSingle(7, 12)}");

/* 
lets help our farmer out a little more, the C# players guide asks us to create a way for him to calculate the area of a single triangle
but the poor farmer just told us he has many triangles on their farm. I don't want them to have to do this one at a time, he could lose track.
that would be sad. I'll just go ahead and figure out how to return an floats[] array of areas for him, he just needs to give me a list of tuples with
the base (b) and the height (h) and I'll return that array with the areas.
*/

// kinda hate the way you have to declare and then assign lists, seems extreme
List<(int, int)> farmersAssets = new List<(int, int)> { (5, 10), (7, 12), (11, 9) };
static List<float> TriangleFarmerMultiple(List<(int, int)> triangleList)
{
    List<float> areas = new List<float>();
    for (int i = 0; i < triangleList.Count; i++)
    {
        var item = triangleList[i];
        var b = item.Item1;
        var h = item.Item2;
        areas.Add(TriangleFarmerSingle(b, h));
    }
    return areas;
}
List<float> farmersAreas = TriangleFarmerMultiple(farmersAssets);

// foreach loop on all float items in the List<float>
foreach (float area in farmersAreas)
{
    Console.WriteLine($"FOR EACH LOOP: {area}");
}
Console.WriteLine(string.Join(", ", farmersAssets)); // placing all the areas in a single line / Joining them together

List<(float, float, int)> randomItems = new List<(float, float, int)> { }; // want to learn how to do a foreach on this one too
randomItems.Add((6.3f, 7.43f, 10));



