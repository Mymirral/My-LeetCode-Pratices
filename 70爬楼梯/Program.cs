
//初始递归
public class Solution1
{
    public int ClimbStairs(int n)
    {
        if(n == 1) return 1;
        else if(n == 2) return 2;
        else
        {
            return ClimbStairs(n-1) + ClimbStairs(n-2);
        }
    }
}

//带记忆递归
public class Solution2
{
    Dictionary<int, int> dp = new Dictionary<int, int>()
    {
        {1, 1},
        {2, 2}
    };
    public int ClimbStairs(int n)
    {
        if (dp.ContainsKey(n))
            return dp[n];
        else
            dp[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        return dp[n];
    }
}

public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;

        int[] dp = new int[n];

        dp[0] = 1;
        dp[1] = 2;

        for(int i = 2; i < n; i++)
        {
            dp[i] = dp[i - 1] + dp[i-2];
        }

        return dp[n-1];
    }
}