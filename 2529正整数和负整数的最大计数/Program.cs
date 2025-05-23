

/*
 * 给你一个按 非递减顺序 排列的数组 nums ，返回正整数数目和负整数数目中的最大值。
 * 换句话讲，如果 nums 中正整数的数目是 pos ，而负整数的数目是 neg ，返回 pos 和 neg二者中的最大值。
 * 注意：0 既不是正整数也不是负整数。
 */


public class Solution
{

    static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine(s.MaximumCount([-3, -2, -1, 0, 0, 1, 2]));
    }


    public int MaximumCount(int[] nums)
    {
        //很简单, 统计nums的正负，只要看大于0和小于0的有多少咯
        //所以是两种情况： 大于0的， (target = 1)的下标往右      >
        //               小于0的， (target = 0)的下标-1 往左   <


        int positive = nums.Length - LowBound(nums, 1);
        int negative = LowBound(nums, 0);     //其实是 (LowBound(nums, 0) - 1) +1
        
        return Math.Max(positive, negative);

    }

    static int LowBound(int[] nums, int target)
    {
        //来个闭区间的
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        return left;    //闭区间，left在right右边
    }
}