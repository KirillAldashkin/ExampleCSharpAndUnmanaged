partial class Program
{
    private static unsafe void PointersExample()
    {
        // C# supports native pointers and can use it to communicate with unmanaged code
        // NOTE 'unsafe' keyword is required when using native pointers
        double val = 5;
        double* ptr = &val;
        Console.WriteLine($"[C#] Value: {val}");
        squareRoot(ptr);
        Console.WriteLine($"[C#] Value: {val}\n");
    }

    private static void DelegatesToUnmanagedExample()
    {
        // C# can convert managed delegates or lambdas to native function pointers
        Console.WriteLine("[C#] Before \'sumFunc\' (using square function)");
        sumFunc(1, 6, 1, d =>
        {
            Console.WriteLine($"[C#] given: {d} - to return {d * d}");
            return d * d;
        });
        Console.WriteLine("[C#] After \'sumFunc\' (using square function)\n");

        // Refering to outer variables is also supported
        for(double k = 0; k < 3; k++)
        {
            Console.WriteLine($"[C#] Before \'sumFunc\' (using multiply-{k} function)");
            sumFunc(1, 6, 1, d =>
            {
                Console.WriteLine($"[C#] given: {d} - to return {d * k}");
                return d * k;
            });
            Console.WriteLine($"[C#] After \'sumFunc\' (using multiply-{k} function)\n");
        }
    }
}