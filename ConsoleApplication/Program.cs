using Core;

namespace ConsoleApplication;

internal static class Program
{
    private static void Main()
    {
        var binarySearchTree = new BinarySearchTree();

        Console.Write("Enter binary search tree values from console or file? ");
        switch (Console.ReadLine()!.ToLower())
        {
            case "console":
                Console.WriteLine();
                for (var i = 1;; i++)
                {
                    Console.Write($"Enter value {i} of binary search tree (or non-integer to exit): ");
                    if (!int.TryParse(Console.ReadLine(), out var value))
                        break;
            
                    binarySearchTree.Add(value);
                }
                
                break;
            case "file":
                Console.Write($"{Environment.NewLine}Enter path to input file: ");
                string text;
                try
                {
                    text = File.ReadAllText(Console.ReadLine()!);
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to read file.");
            
                    Console.Write($"{Environment.NewLine}To terminate the program, press any key...");
                    Console.ReadKey();
            
                    return;
                }

                foreach (var number in text.Split(", "))
                {
                    if (!int.TryParse(number.Trim(), out var value))
                        continue;
            
                    binarySearchTree.Add(value);
                }
                
                break;
            default:
                Console.WriteLine("Unsupported value.");
                
                Console.Write($"{Environment.NewLine}To terminate the program, press any key...");
                Console.ReadKey();
            
                return;
        }

        var nlr = new List<int>();
        var count = 0d;
        var sum = 0d;
        binarySearchTree.NodeLeftRight(v =>
        {
            sum += v;
            count++;
            nlr.Add(v);
        });
        var average = sum / count;
        
        var lnr = new List<int>();
        binarySearchTree.LeftNodeRight(v => lnr.Add(v));
        
        var lrn = new List<int>();
        binarySearchTree.LeftRightNode(v => lrn.Add(v));

        Console.WriteLine($"{Environment.NewLine}Average value of binary search tree: {(double.IsNaN(average) ? string.Empty : average)}.");
        Console.WriteLine($"NLR: {string.Join(", ", nlr)}.");
        Console.WriteLine($"LNR: {string.Join(", ", lnr)}.");
        Console.WriteLine($"LRN: {string.Join(", ", lrn)}.");
        
        Console.Write($"{Environment.NewLine}To terminate the program, press any key...");
        Console.ReadKey();
    }
}