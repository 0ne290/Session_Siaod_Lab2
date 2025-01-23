namespace Core;

// Мой инстинкт перфекциониста требует реализовать метод балансировки дерева, но это бы усложнило код.
public class BinarySearchTree
{
    public bool IsEmpty() => _root == null;

    public void NodeLeftRight(Action<int> callback)
    {
        Execute(_root);
        
        return;

        void Execute(Node? current)
        {
            while (true)
            {
                if (current == null)
                    return;

                callback(current.Value);

                Execute(current.Left);
                
                current = current.Right;
            }
        }
    }
    
    public void LeftNodeRight(Action<int> callback)
    {
        Execute(_root);
        
        return;

        void Execute(Node? current)
        {
            while (true)
            {
                if (current == null)
                    return;

                Execute(current.Left);
                
                callback(current.Value);
                
                current = current.Right;
            }
        }
    }
    
    public void LeftRightNode(Action<int> callback)
    {
        Execute(_root);
        
        return;

        void Execute(Node? current)
        {
            if (current == null)
                return;

            Execute(current.Left);

            Execute(current.Right);

            callback(current.Value);
        }
    }
    
    public void Add(int value)
    {
        if (IsEmpty())
        {
            _root = new Node { Value = value };
            
            return;
        }

        var current = _root!;
        while (true)
        {
            if (value > current.Value)
            {
                if (current.Right == null)
                {
                    current.Right = new Node { Value = value };
                    
                    return;
                }

                current = current.Right;
            }
            else
            {
                if (current.Left == null)
                {
                    current.Left = new Node { Value = value };
                    
                    return;
                }

                current = current.Left;
            }
        }
    }
    
    public bool Remove(int value)
    {
        
    }

    // Исключение тут используется в качестве оригинального способа завершить все рекурсивно вызванные методы.
    /*public bool Contains(int value)
    {
        try
        {
            NodeLeftRight(v =>
            {
                if (v == value)
                    throw new BinarySearchTreeContainsValueException();
            });

            return false;
        }
        catch (BinarySearchTreeContainsValueException)
        {
            return true;
        }
    }*/
    
    public bool Contains(int value)
    {
        var current = _root;
        while (true)
        {
            if (current == null)
                return false;
            if (value == current.Value)
                return true;
            
            current = value > current.Value ? current.Right : current.Left;
        }
    }
    
    private Node? _root;
}