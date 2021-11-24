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
        Console.WriteLine("[C#] \'sumFunc\': using square function");
        var summ = sumFunc(1, 6, 1, d =>
        {
            Console.WriteLine($"[C#] given: {d} - to return {d * d}");
            return d * d;
        });
        Console.WriteLine($"[C#] Total sum: {summ}");

        // Lambdas with context is also supported
        for (double k = 0; k < 3; k++)
        {
            Console.WriteLine($"\n[C#] \'sumFunc\': using multiply-{k} function");
            summ = sumFunc(1, 6, 1, d =>
            {
                Console.WriteLine($"[C#] given: {d} - to return {d * k}");
                return d * k;
            });
            Console.WriteLine($"[C#] Total sum: {summ}");
        }
        Console.WriteLine();
    }

    private static void UnmanagedToDelegatesExample()
    {
        // C# can convert native function pointers to delegates
        var methods = Enumerable.Range(1, 20).Select(index => (index, method: getFunction(index)));
        foreach (var call in methods)
        {
            Console.Write($"[C#] {call.index}:");
            call.method();
        }
        Console.WriteLine();
    }

    private static void SortExample()
    {
        // Using std::qsort from unmanaged code
        int[] data = new int[20];
        Random rnd = new();
        for (int i = 0; i < data.Length; i++) data[i] = rnd.Next(-1000, 1001);
        Console.WriteLine($"Before unmanaged sort: {string.Join(' ', data)}");
        StdSort<int>(data);
        Console.WriteLine($"After unmanaged sort: {string.Join(' ', data)}");
    }
}