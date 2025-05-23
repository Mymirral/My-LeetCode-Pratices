

/*
 * 给定一个含有 n 个正整数的数组和一个正整数 target 。
 * 找出该数组中满足其总和大于等于 target 的长度最小的子数组
 * [numsl, numsl+1, ..., numsr-1, numsr] ，并返回其长度。如果不存在符合条件的子数组，返回 0 。
 */


public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MinSubArrayLen(15,[2,14]));
    }
    public static int MinSubArrayLen(int target, int[] nums)
    {
        if (nums.Sum() < target) return 0;

        int head = 0;
        int tail = 0;

        int now = nums.Length;
        int min = nums.Length;  //窗口的最小长度

        int sum = 0;

        while(head < nums.Length)   //经典开始条件
        {
            sum += nums[head];  //先把进窗口的加进去
            if(sum >= target)    //如果和已经大于目标
            {
                now = head-tail +1;
            }

            while(sum > target)
            {
                sum -= nums[tail];
                tail++;
                if (sum >= target)    //如果和已经大于目标
                {
                    now = head - tail + 1;
                }
            }

            min = Math.Min(min, now);
            head++;
        }
        return min;
    }
}