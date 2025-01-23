using Core;

namespace ConsoleApplication;

internal static class Program
{
    private static void Main()
    {
        var binarySearchTree = new BinarySearchTree();
        
        binarySearchTree.Add(8);
        binarySearchTree.Add(3);
        binarySearchTree.Add(10);
        binarySearchTree.Add(1);
        binarySearchTree.Add(6);
        binarySearchTree.Add(14);
        binarySearchTree.Add(4);
        binarySearchTree.Add(7);
        binarySearchTree.Add(13);

        var nlr = new List<int>();
        binarySearchTree.NodeLeftRight(v => nlr.Add(v));
        
        var lnr = new List<int>();
        binarySearchTree.LeftNodeRight(v => lnr.Add(v));
        
        var lrn = new List<int>();
        binarySearchTree.LeftRightNode(v => lrn.Add(v));
        
        Console.WriteLine($"NLR: {string.Join(", ", nlr)}.");
        Console.WriteLine($"LNR: {string.Join(", ", lnr)}.");
        Console.WriteLine($"LRN: {string.Join(", ", lrn)}.");
        Console.WriteLine($"Contains 10? {binarySearchTree.Contains(10)}.");
    }
}