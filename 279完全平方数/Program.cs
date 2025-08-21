
Solution s = new();
s.NumSquares(12);

// 用当前数 减去一个平方数，dp[n - i^2] + 1; 
// 可以理解为 这个1 就是减去的 i^2;


public class Solution
{
    public int NumSquares(int n)
    {
        int[] dp = new int[n];

        dp[0] = 1;

        for(int i = 1; i < n; i++)
        {
            int min = int.MaxValue;
            int num = 1;

            while((i+1) - (num*num) > 0)
            {
                min = Math.Min(min, dp[i - (num * num)]);
                num++;
            }

            if ((i + 1) - (num * num) == 0)
            {
                dp[i] = 1;
            }
            else dp[i] = min + 1;
        }

        return dp[n-1];
    }
}