Console.WriteLine("Hello, World!");

// System is the namespace that the Console class lives in, WriteLine is a method that belongs to the Console Class
System.Console.WriteLine("Using Writeline"); // BCL (Base Class Library) > System (Namespace in BCL Library) > Console (Class of Namespace System) > WriteLine (Method of Console)

// must tell C# what type of variable we want before variable assignment
string name = "Brandon"; // This is a string literal
Console.WriteLine("Hello " + name);

// Console Application > Program > Main > newVariable
string newVariable = "New String Literal";
string userName; // we can initialize a varaible without assigning a value to it now

Console.WriteLine("What is your name: ");
userName = Console.ReadLine();
Console.WriteLine("Hello, " + userName);