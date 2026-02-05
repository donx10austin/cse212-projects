using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    public Node? Root { get; private set; }

    public void Insert(int value)
    {
        if (Root == null) Root = new Node(value);
        else Root.Insert(value);
    }

    public bool Contains(int value) => Root != null && Root.Contains(value);

    public int GetHeight() => Root?.GetHeight() ?? 0;

    // Required by TreeReverseTests
    public IEnumerable<int> Reverse() => Root != null ? Root.TraverseBackward() : Enumerable.Empty<int>();

    public IEnumerator<int> GetEnumerator() => GetValues().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private IEnumerable<int> GetValues()
    {
        return GetValuesRecursive(Root);
    }

    private IEnumerable<int> GetValuesRecursive(Node? node)
    {
        if (node == null) yield break;
        foreach (var v in GetValuesRecursive(node.Left)) yield return v;
        yield return node.Data;
        foreach (var v in GetValuesRecursive(node.Right)) yield return v;
    }

    // Required by Assert.AreEqual("<Bst>{...}", tree.ToString())
    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}