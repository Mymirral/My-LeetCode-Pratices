

using System.Numerics;

public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        return arr.Order().OrderBy(x => BitOperations.PopCount((uint)x)).ToArray();
    }
}