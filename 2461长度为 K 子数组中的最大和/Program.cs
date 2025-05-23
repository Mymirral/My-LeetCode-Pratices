

using System.Diagnostics.CodeAnalysis;

public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaximumSubarraySum([1,2,3,4,5,6,7,8,9,10], 5));
    }
    public static long MaximumSubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        //字典<这个数，这个数出现的次数>

        int now = 0;    //临时的和
        int max = 0;    //最大和
        //建立窗口
        for (int i = 0; i < k; i++)
        {
            if (dic.ContainsKey(nums[i])) //如果以及包含了这个Key
            {   
                //这个key出现的次数+1
                dic[nums[i]]++;
                continue;
            }
            else dic.Add(nums[i], 1);  //否则把这个key加进去，赋值为1
            now += nums[i];     //然后现在的和加上没有重复的值
        }

        if (dic.Count == k) max = now;  //如果
        int start = 0;

        for (int i = k; i < nums.Length; i++)
        {
            dic[nums[start]]--;
            if (dic.ContainsKey(nums[i]))
            {
                dic[nums[i]]++;
                if (dic[nums[start]] == 0)
                {
                    dic.Remove(nums[start]);
                    now -= nums[start];
                }
                start++;
                continue;
            }
            else
            {
                dic.Add(nums[i], 1);
            }

            if (dic[nums[start]] > 0)
            {
                now += nums[i];
            }
            else
            {
                now += (nums[i] - nums[start]);
            }
            if (dic[nums[start]] == 0) dic.Remove(nums[start]);
            start++;
            if (dic.Count == k && now > max)
                max = now;
        }

        return max;
    }
}