using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // PLAN:
        // 1. Create a new array of doubles with a capacity equal to the 'length' parameter.
        // 2. Start a loop that iterates from 0 up to 'length - 1'.
        // 3. For each iteration, calculate the multiple by multiplying 'number' by (current index + 1).
        //    (e.g., if index is 0, we get number * 1; if index is 1, we get number * 2).
        // 4. Store this calculated value in the array at the current index.
        // 5. Once the loop is complete, return the populated array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // PLAN:
        // 1. Determine the split point in the list where the rotation starts.
        //    This is found by subtracting 'amount' from the total count of the list.
        // 2. Use the GetRange method to "slice" the elements from the split point to the end.
        // 3. Use RemoveRange to delete those same elements from their original position at the end.
        // 4. Use InsertRange to place the sliced elements at the very beginning of the list (index 0).
        // 5. Since lists are reference types, the original list is modified without needing a return.

        // Calculate the starting position of the segment to move
        int splitPoint = data.Count - amount;

        // Extract the segment that moves to the front
        List<int> rotationSegment = data.GetRange(splitPoint, amount);

        // Remove that segment from the back
        data.RemoveRange(splitPoint, amount);

        // Insert that segment at the front
        data.InsertRange(0, rotationSegment);
    }
}