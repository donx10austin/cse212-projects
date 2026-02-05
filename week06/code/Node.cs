using System;
using System.Collections.Generic;

public class Node
{
    public int Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int data)
    {
        Data = data;
    }

    public void Insert(int value)
    {
        // No duplicates allowed
        if (value == Data) return;

        if (value < Data)
        {
            if (Left is null) Left = new Node(value);
            else Left.Insert(value);
        }
        else
        {
            if (Right is null) Right = new Node(value);
            else Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data) return true;
        if (value < Data) return Left != null && Left.Contains(value);
        return Right != null && Right.Contains(value);
    }

    public IEnumerable<int> TraverseBackward()
    {
        if (Right != null)
            foreach (var v in Right.TraverseBackward()) yield return v;
        yield return Data;
        if (Left != null)
            foreach (var v in Left.TraverseBackward()) yield return v;
    }

    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}