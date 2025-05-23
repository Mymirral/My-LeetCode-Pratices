

class Solution
{
    /*
     * 给你一个由 n 个元素组成的整数数组 nums 和一个整数 k 。
     * 请你找出平均数最大且 长度为 k 的连续子数组，并输出该最大平均数。
     * 任何误差小于 10-5 的答案都将被视为正确答案。
     */

    static void Main(string[] args)
    {
        Console.WriteLine(FindMaxAverage([5], 1));
    }

    public static double FindMaxAverage(int[] nums, int k)
    {
        //平均数最大,那说明总和最大咯
        double now = 0;
        double max = 0;
        for (int i = 0;i<k;i++)         //先把初始窗口建立起来
        {
            now += nums[i];
        }
        max = now;

        int start = 0;
        for (int i = k; i < nums.Length; i++)
        {
            now += (nums[i] - nums[start]);     //滑动窗口, 减去最开始的,加上最后的
            if(now > max) max = now;
            start ++;
        }
        return max/k;
    }
}