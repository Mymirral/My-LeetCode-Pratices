
#define 写法1


/*
 * 给你一个按照非递减顺序排列的整数数组 nums，和一个目标值 target。请你找出给定目标值在数组中的开始位置和结束位置。
 * 如果数组中不存在目标值 target，返回 [-1, -1]。
 * 你必须设计并实现时间复杂度为 O(log n) 的算法解决此问题。
 */


using System.Reflection;

public class Solution
{
    static void Main(string[] args)
    {
        int[] x = SearchRange([2,2], 3);
        foreach (int i in x)
        {
            Console.WriteLine(i);
        }
    }

    //二分法的内容看我的笔记去
    //本题目要求返回2个值
    //1 是大于等于
    //2 是小于等于

    //我们采用开区间写法
    public static int[] SearchRange(int[] nums, int target)
    {
        int left = LowBound(nums, target);
        int right = LowBound(nums, target + 1) - 1;
        int[] ints = { -1, -1 };

        //记住，LowBound根据用法，返回的一定是>= >  < <= , 四种中数的下标
        if (left == nums.Length) return ints; //left是大于等于， 无非两种情况:left 等于 length, 说明区间内没有大于target的
        else if (nums[left] != target) return ints;// left不等于 target， 说明只有大于，没有等于， 
        else
        {
            ints[0] = left;
            ints[1] = right;
            return ints;
        }
    }

    public static int LowBound(int[] nums, int target)
    {
        int left = -1;
        int right = nums.Length;
        int mid;

        //以下都为开区间写法
        while (left + 1 < right)        //开区间循环条件
        {
            mid = left + (right - left) / 2;        //防止数组溢出的写法， 先减再加
            if (nums[mid] < target) left = mid;     //小于target
            else right = mid;                       //大于等于target
        }

        //当循环结束，right指向target
        return right;
    }
}