


/*
 * 给你一个长度为 n 的整数数组 nums ，和一个长度为 m 的整数数组 queries 。
 * 返回一个长度为 m 的数组 answer ，其中 answer[i] 是 nums 中 元素之和小于等于 queries[i] 的 子序列 的 最大 长度  。
 * 子序列 是由一个数组删除某些元素（也可以不删除）但不改变剩余元素顺序得到的一个数组。
 */

public class Solution
{
    static void Main(string[] args)
    {
        Solution s = new Solution();
        s.AnswerQueries([469781, 45635, 628818, 324948, 343772, 713803, 452081], [816646, 929491]);
    }
    //贪心+二分
    public int[] AnswerQueries(int[] nums, int[] queries)
    {

        Array.Sort(nums);
        //二分写在哪里？
        //贪心要的最大值， 就是二分查找的返回值

        //二分的类型： <=小于等于 
        int sum;
        int max;
        int[] result = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            sum = 0;
            max = LowBound(nums, queries[i]+1) - 1;
            int count = 0;
            while(count <= max)
            {
                if (sum + nums[count] <= queries[i])
                {
                    sum += nums[count];
                    result[i]++;
                }
                count++;
            }
        }

        return result;
    }


    //先不管了，写个二分

    static int LowBound(int[] nums, int target)
    {
        int left = -1;
        int right = nums.Length;
        int mid;

        while (left + 1 < right)
        {
            mid = left + (right - left) / 2;

            if (nums[mid] < target) left = mid;
            else right = mid;
        }
        return right;
    }
}