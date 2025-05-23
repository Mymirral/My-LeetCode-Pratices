


/*
 * 给你两个正整数数组 spells 和 potions ，长度分别为 n 和 m ，其中 spells[i] 表示第 i 个咒语的能量强度，potions[j] 表示第 j 瓶药水的能量强度。
 * 同时给你一个整数 success 。一个咒语和药水的能量强度 相乘 如果 大于等于 success ，那么它们视为一对 成功 的组合。
 * 请你返回一个长度为 n 的整数数组 pairs，其中 pairs[i] 是能跟第 i 个咒语成功组合的 药水 数目。
 */


public class Solution
{
    static void Main(string[] args)
    {
        Solution s = new Solution();
        s.SuccessfulPairs([3, 1, 2], [8, 5, 8], 16);
    }
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);

        //目标: spells / success = target 
        //成功区配: potions 中 大于 target 的
        //即 target = spells / success +1

        int[] result = new int[spells.Length];
        for (int i = 0; i < spells.Length; i++)
        {
            long target;
            target = success % spells[i] > 0 ? (success / spells[i]) + 1 : success / spells[i];
            result[i] = potions.Length - LowBound(potions, target);
        }
        return result;
    }

    static int LowBound(int[] nums, long target)
    {
        //开区间
        int left = -1;
        int right = nums.Length;
        int mid;

        while (left + 1 < right)
        {
            mid = left + (right - left) / 2;
            if (nums[mid] < target) left = mid;
            else right = mid;
        }

        return right;

    }
}