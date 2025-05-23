



/*
 * 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
 * 请必须使用时间复杂度为 O(log n) 的算法。
 */

public class Solution
{

    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.SearchInsert([1,3],2)); 
    }

    //好好想一下这道题
    //插入的数，大于target-1，小于等于target
    //只要一个条件即可
    public int SearchInsert(int[] nums, int target)
    {
        return LowBound(nums, target);
    }


    //二分查找
    //开区间写法
    // <=left左边一定都是小于target的， >=right右边一定都是大于等于target的
    public static int LowBound(int[] nums, int target)
    {
        //采用开区间写法，好用爱用
        int left = -1;
        int right = nums.Length;

        while (left + 1 < right) //开区间条件
        {
            int mid = left + (right - left) / 2;  //防止溢出， 先减再加    注意放里面
            if (nums[mid] < target) left = mid;
            else right = mid;
        }

        return right;  //目标值
    }
}