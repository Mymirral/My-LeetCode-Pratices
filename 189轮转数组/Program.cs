

public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        int times = k;

        while( times > nums.Length)
        {
            times -= nums.Length;
        }

        int[] res = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            int index = (nums.Length - times + i) % nums.Length;

            res[i] = nums[index];
        }

        Array.Copy(res, nums,res.Length);
    }
}