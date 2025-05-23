


//题目：给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。

//初步想法：合并数组，数组个数的中间就是，奇数数组是中间，偶数数组是中间两个之和的平均

class Progarm
{
    static void Main(string[] args)
    {
        int[] num1 = { 1, 2 };
        int[] num2 = { 3,4 };
        Solution s = new Solution();
        double num3 = s.FindMedianSortedArrays(num1,num2);
        Console.WriteLine("{0:0.00000}",num3);
    }
}

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double MedianNum = 0;

        //这里我小小作弊了一下，搜了一下合并数组的方法
        int[] nums3 = new int[nums1.Length+nums2.Length];       //创建一个数组3
        Array.Copy(nums1, nums3, nums1.Length);                 //将数组1添加进来，括号从左往右依次是：要复制的数组，要复制去到哪个数组，复制多少个
        Array.Copy(nums2, 0, nums3, nums1.Length, nums2.Length);//将数组2添加进来，括号从左往右依次是：要复制的数组，从哪里开始复制，要复制去到哪个数组，在目标哪里开始放，复制多少个
        Array.Sort(nums3);                                      //排序

        //判断一下个数是奇数还是偶数
        if (nums3.Length % 2 == 1)   //奇数的话     比如下标是0，1，2，length是3，（3+1）/2-1 =1得到下标 
        {
            MedianNum = nums3[(nums3.Length+1) / 2 - 1];
        }
        else                         //偶数的话     比如下标是0,1,2,3 length是4， 要得到下标1和下标2代表的数的平均数，则4/2=2 2-1 = 1
        {
            MedianNum = ((double)nums3[nums3.Length / 2-1] + (double)nums3[nums3.Length / 2])/2;        
        }

        return MedianNum;

    }
}