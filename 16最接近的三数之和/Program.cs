

using System.Collections.Immutable;

public class Code
{
    static void Main(string[] args)
    {
        int[] ints = { 4, 0, 5, -5, 3, 3, 0, -4, -5 };
        int target = -2;
        Solution solution = new Solution();
        Console.WriteLine(solution.ThreeSumClosest(ints,target));
    }
}

public class Solution
{
    //这一次试试双指针
    public int ThreeSumClosest(int[] nums, int target)   
    {
        int min=10000;
        int lastgap=10000;

        Array.Sort(nums);
        for (int i = 0; i < nums.Length-2; i++) 
        {
            //设置指针
            int j= i+1, k= nums.Length-1;
            int gap = target - (nums[i] + nums[j] + nums[k]);
            if(i==0) min = nums[i] + nums[j] + nums[k];
            while (true)    //指针移动
            {
                gap = target - (nums[i] + nums[j] + nums[k]);
                min = Math.Abs(lastgap) > Math.Abs(gap) ? target - gap : min;
                lastgap = Math.Abs(lastgap) > Math.Abs(gap) ? gap : lastgap;
                if (gap > 0) { j++; }       //如果间隔大于0，说明加少了
                if (gap < 0) { k--; }       //如果间隔小于0，说明加多了
                if (gap == 0) { return target; }    //如果间隔等于0，说明有和为target的三数。
                if (j == k) { break; }

            }
        }
        return min;
    }
}