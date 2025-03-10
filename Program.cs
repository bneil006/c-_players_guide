using System; // Top level statements including in C# 9
using Classes; // created a folder for my Triangle class

Triangle myTriangle = new Triangle(10, 600);
Triangle secondTriangle = new Triangle(50, 60000);

// Print the triangle's information
myTriangle.PrintTriangleInfo();
secondTriangle.PrintTriangleInfo();
Console.ReadLine();


