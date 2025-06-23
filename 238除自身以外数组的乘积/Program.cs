public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] pre = new int[nums.Length + 1];
        Array.Fill(pre, 1);
        for (int i = 1; i < pre.Length; i++)
        {
            pre[i] = pre[i - 1] * nums[i - 1];
        }

        int[] sub = new int[nums.Length + 1];
        Array.Fill(sub, 1);
        for (int i = sub.Length - 2; i > -1; i--)
        {
            sub[i] = sub[i + 1] * nums[i];
        }

        var res = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            res[i] = pre[i]*sub[i + 1];
        }

        return res;
    }
}