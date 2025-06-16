






using System;

class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.LongestConsecutive([100, 4, 200, 1, 3, 2]
));
    }
}

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 1) return 1;
        if (nums.Length == 0) return 0;

        Array.Sort(nums);
        int head = 0;
        int tail = 0;
        int max = 1;
        int roop = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (head < nums.Length - 1) head++;
            if (nums[head] == nums[head - 1])
            {
                roop++;
                continue;
            }
            if (nums[head] == nums[head - 1] + 1) max = head - tail - roop + 1 > max ? head - tail - roop + 1 : max;
            else
            {
                roop = 0;
                tail = head;
            }
        }

        return max;
    }
}