

/*
 * 给你一个二进制数组 nums ，你需要从中删掉一个元素。
 * 请你在删掉元素的结果数组中，返回最长的且只包含 1 的非空子数组的长度。
 * 如果不存在这样的子数组，请返回 0 。
 */

public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(LongestSubarray([0, 1, 1, 1, 0, 1, 1, 0, 1]));
    }
    public static int LongestSubarray(int[] nums)
    {
        int head = 0;   //头
        int tail = 0;   //尾

        int[] time = new int[2];  //这个数组只有两个，0，1 刚好对应他们的数量

        int max = 0;

        while(head < nums.Length)       //当头没到数组最后面
        {
            if (nums[head] == 1)  //如果这个数是1 
            {
                time[1]++;
            }
            else
            {
                time[0]++;  //0的个数加一
                while (time[0] == 2)    //如果0已经大于2个了, 持续推进尾巴直到0的个数小于2
                {
                    if (nums[tail] == 0)
                    {
                        time[0]--;
                    }
                    else
                    {
                        time[1]--;
                    }
                    tail++; //尾巴向前移动
                }
            }

            head++;
            max = Math.Max(max, time[1]);
        }

        if(max == nums.Length) return nums.Length -1;   //如果全是1，必须删掉一个
        return max;
    }
}
