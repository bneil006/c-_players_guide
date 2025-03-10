using System; // Top level statements including in C# 9
using Classes; // created a folder for classes to use here, i called it Classes obviously, this is also the namespace in those .cs files so we can use the classes here.

var firstTriangle = new Triangle(10, 9);
var secondTriangle = new Triangle(2.5f, 5.5f);
var thirdTriangle = new Triangle(5, 7);

List<Triangle> farmersTriangles = new List<Triangle> { firstTriangle, secondTriangle, thirdTriangle };
foreach (Triangle item in farmersTriangles)
{
    item.PrintTriangleInfo();
    Console.WriteLine($"Area: {item.TriangleArea()}");
}

Rectangle firstRectangle = new Rectangle(5, 10);
firstRectangle.PrintRectangleInfo();


Console.ReadLine();


