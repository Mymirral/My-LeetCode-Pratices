

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        HashSet<int> key = new HashSet<int>();

        int res = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            key.Add(nums[i]);
        }

        for (int i = 1; i < nums.Length+1; i++)
        {
            if (!key.Contains(i)) return i;
        }

        return nums.Length+1;
    }
}