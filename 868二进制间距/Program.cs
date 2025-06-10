

using System.Numerics;
using System;


class Test
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(solution.BinaryGap(12));
    }
}
public class Solution
{
    public int BinaryGap(int n)
    {
        if(BitOperations.PopCount((uint)n) <2) return 0; 
        var bits = Convert.ToString(n, 2).Length;

        var distance = 0;
        int point = 0;
        bool first = false;
        for (var i = 0; i < bits; i++)
        {
            if ((n & 1) == 1)
            {

                if (!first)
                {
                    point = i;
                    first = true;
                }
                distance = distance > i - point ? distance : i - point;
                point = i;
            }
            n >>= 1;
        }
        return distance;
    }
}