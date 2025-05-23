

public class Solution
{
    /*
     * 给你一个整数数组 arr 和两个整数 k 和 threshold 。
     * 请你返回长度为 k 且平均值大于等于 threshold 的子数组数目。
     */
    static void Main(string[] args)
    {
        Console.WriteLine(NumOfSubarrays([2, 2, 2, 2, 5, 5, 5, 8], 3, 4));
    }

    public static int NumOfSubarrays(int[] arr, int k, int threshold)
    {
        int atlest = k * threshold;
        int count = 0;
        int now = 0;

        //建立初始窗口
        for (int i = 0; i < k; i++)
        {
            now += arr[i];
        }
        if (now >= atlest) count++;

        //开始滑动
        int start = 0;
        for (int i = k; i < arr.Length; i++)
        {
            now += (arr[i] - arr[start]);
            if (now >= atlest) count++;
            start++;
        }
        return count;
    }
}