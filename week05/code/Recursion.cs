using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string current = "", bool[]? used = null)
    {
        if (used == null) used = new bool[letters.Length];

        if (current.Length == size)
        {
            results.Add(current);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                PermutationsChoose(results, letters, size, current + letters[i], used);
                used[i] = false;
            }
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();

        if (s == 0) return 1;
        if (s < 0) return 0;

        if (remember.ContainsKey(s)) return remember[s];

        remember[s] = CountWaysToClimb(s - 1, remember) + 
                      CountWaysToClimb(s - 2, remember) + 
                      CountWaysToClimb(s - 3, remember);
        
        return remember[s];
    }

    /// <summary>
    /// Problem 4: Wildcard Binary
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// Problem 5: Maze
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null) currPath = new List<(int, int)>();
        
        // Add current position to path
        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else 
        {
            // Possible directions: Right, Down, Left, Up
            int[] dx = { 1, 0, -1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                // FIXED: Used nextY for the second coordinate instead of nextX
                if (maze.IsValidMove(currPath, nextX, nextY))
                {
                    // Parameters maintained in required order: results, maze, x, y, currPath
                    SolveMaze(results, maze, nextX, nextY, currPath);
                }
            }
        }

        // Backtrack: remove the current position before returning to the previous caller
        currPath.RemoveAt(currPath.Count - 1);
    }
}