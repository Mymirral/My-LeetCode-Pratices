Solution s = new();
s.Rob([2, 1, 1, 2]);

//看走到每一家能偷到的最大金额
//第i家能偷盗的最大金额数是 [i] + [i-2] 或者 [i-1]

public class Solution
{
    public int Rob(int[] nums)
    {
        if(nums.Length == 1) return nums[0];
        if(nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int[] dp = new int[nums.Length];

        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(nums[i] + dp[i-2], dp[i-1]);
        }

        return dp[nums.Length - 1];
    }
}