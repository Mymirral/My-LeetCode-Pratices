

public class Solution
{
    /*给你一个下标从 0 开始的数组 nums ，数组中有 n 个整数，另给你一个整数 k 。
     * 半径为 k 的子数组平均值 是指：nums 中一个以下标 i 为 中心 且 半径 为 k 的子数组中所有元素的平均值，即下标在 i - k 和 i + k 范围（含 i - k 和 i + k）内所有元素的平均值。如果在下标 i 前或后不足 k 个元素，那么 半径为 k 的子数组平均值 是 -1 。
     * 构建并返回一个长度为 n 的数组 avgs ，其中 avgs[i] 是以下标 i 为中心的子数组的 半径为 k 的子数组平均值 。
     * x 个元素的 平均值 是 x 个元素相加之和除以 x ，此时使用截断式 整数除法 ，即需要去掉结果的小数部分。
     */
    static void Main(string[] args)
    {
        int[] x = GetAverages([2,2,1],1);
            foreach (var i in x)
        {
            Console.WriteLine(i);
        }
    }

    public static int[] GetAverages(int[] nums, int k)
    {
        int[] result = new int[nums.Length];
        int windowLength = 2 * k + 1;
        double sum = 0;
        int index = 0;      //结果数组的输出

        if (windowLength > nums.Length && k!=0)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = -1;
            }
            return result;
        }

        //建立窗口， 同时给半径外的数赋值为-1
        for (int i = 0; i < windowLength; i++)
        {
            if (i < k) { result[i] = -1; index++; }
            sum += nums[i];     //第一个窗口的和
        }
        result[index] = (int)(sum / windowLength);
        index++;

        int start = 0;
        for (int i = windowLength; i < nums.Length; i++)
        {
            sum += (nums[i] - nums[start]);
            start++;
            result[index] = (int)(sum / windowLength);
            index++;
        }

        for (int i = index; i < nums.Length; i++)
        {
            result[i] = -1;
        }


        return result;
    }
}