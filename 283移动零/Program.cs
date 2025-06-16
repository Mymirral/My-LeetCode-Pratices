


public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int head = 0;
        int tail = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if(head < nums.Length - 1)head++;
            if (nums[tail] == 0)
            {
                if (nums[tail]==0 && nums[head] == 0) continue;
                nums[tail] = nums[head];
                nums[head] = 0;
            }
            tail++;
        }
    }
}