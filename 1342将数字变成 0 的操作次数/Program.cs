

using System.Numerics;

public class Solution
{
    public int NumberOfSteps(int num)
    {
        return BitOperations.PopCount((uint)num) + Convert.ToString(num, 2).Length - 1;
    }
}