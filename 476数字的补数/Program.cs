public class Solution
{
    public int FindComplement(int num)
    {
        if (num == 0) return 0;
        var x = Convert.ToString(num, 2).Length;

        return (~num << 32 - x) >> 32 - x;
    }
}