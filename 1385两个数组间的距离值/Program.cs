




/*
 * 给你两个整数数组 arr1 ， arr2 和一个整数 d ，请你返回两个数组之间的 距离值 。
 * 「距离值」 定义为符合此距离要求的元素数目：对于元素 arr1[i] ，不存在任何元素 arr2[j] 满足 |arr1[i]-arr2[j]| <= d 。
 */


public class Solution
{
    static void Main(string[] args)
    {
        int[] int1 = [4, 5, 8];
        int[] int2 = [10, 9, 1, 8];
        
        Solution solution = new Solution();

        Console.WriteLine(solution.FindTheDistanceValue(int1,int2,2));
    }

    //查找值的
    //在一个数组里面找到对应目标大小的
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        Array.Sort(arr1);
        Array.Sort(arr2);

        int distance = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            if (!InGap(arr2, arr1[i],d))
            {
                distance++;
            }
        }
        return distance;
    }


    static bool InGap(int[] nums,int target,int d)
    {
        //开区间
        int left = -1;
        int right = nums.Length;

        while (left + 1 < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] < target) left = mid;
            else right = mid;
        }

        //此时的 nums[right] >= target

        if (right==0) return Math.Abs(nums[right] - target) <= d;
        else if(right == nums.Length) return Math.Abs(nums[right-1] - target) <= d;
        else return (Math.Abs(nums[right] - target) <= d)|| (Math.Abs(nums[right - 1] - target) <= d);
    }
}