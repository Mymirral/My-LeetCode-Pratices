
class Test
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(solution.SubarraySum([1, 1, 1],2));
    }
}

public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        int[] presum = new int[nums.Length + 1];

        for (int i = 1; i < presum.Length; i++)
        {
            presum[i] += nums[i - 1] + presum[i - 1];
        }

        int sum = 0;

        for (int i = 0; i < presum.Length; i++)
        {
            for (int j = i+1; i < presum.Length - 1; j++)
            {
                if (presum[j] - k == presum[i]) sum++;
            }
        }

        return sum;
    }
}