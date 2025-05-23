


/*
 * 给定一个 n 个元素有序的（升序）整型数组 nums 和一个目标值 target  ，写一个函数搜索 nums 中的 target，如果目标值存在返回下标，否则返回 -1。
 */



//我都不想多写了其实哈哈

public class Solution
{

    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.Search([-1, 0, 3, 5, 9, 12], 0));
    }

    //好好想一下这道题
    //插入的数，大于target-1，小于等于target
    //只要一个条件即可
    public int Search(int[] nums, int target)
    {
        int val = LowBound(nums, target);
        if (val == nums.Length) return -1;
        else if (nums[val] != target) return -1;
        else return val;
        
    }


    //二分查找
    //半闭半开区间写法， 左闭右开
    // <=left左边一定都是小于target的， >=right右边一定都是大于等于target的
    public static int LowBound(int[] nums, int target)
    {
        //采用开区间写法，好用爱用
        int left = 0;   //左闭
        int right = nums.Length;    //右开

        while (left < right) //左闭右开区间条件
        {
            int mid = left + (right - left) / 2;  //防止溢出， 先减再加    注意放里面
            if (nums[mid] < target) left = mid + 1;
            else right = mid;
        }

        return right;  //目标值  半闭半开区间 left 和 right 都是目标值
    }
}