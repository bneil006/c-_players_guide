
Action<int> PrintInt = value => Console.WriteLine(value);
Func<int, int, int> AddItems = (a, b) => a + b;

static void MyNewMethod(Action<int> log, Func<int, int, int> operation, int a, int b)
{
    log(operation(a, b));
}

MyNewMethod(PrintInt, AddItems, 3, 8);
