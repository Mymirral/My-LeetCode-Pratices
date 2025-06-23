
class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MaxSubArray([-2, 1]));
    }
}

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        if(nums.Length == 1) return nums[0];

        int right = 0;
        int left = 0;

        int max = int.MinValue;
        int windowSum = 0;

        while (right < nums.Length)    //左不能大于右
        {
            //窗口值更新
            windowSum += nums[right];
            //最大值更新
            max = Math.Max(max, windowSum);

            while ( windowSum < 0 && left < right && right!= 0 && nums[left] < 0)
            {
                //窗口值更新
                windowSum -= nums[left];

                //最大值更新
                max = Math.Max(max, windowSum);

                left++;
            }

            //窗口扩大
            right++;
        }

        return max;
    }
}