


/*
 * 给你一个字符串 s ，它只包含三种字符 a, b 和 c 。
 * 请你返回 a，b 和 c 都 至少 出现过一次的子字符串数目。
 */


public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(NumberOfSubstrings("abcabc"));
    }
    public static int NumberOfSubstrings(string s)
    {
        int head = 0;
        int tail = 0;

        int total = 0;

        int[] ints = new int[3];

        while (tail < s.Length - 2)  
        {
            while (head < s.Length)
            {

            }

            tail++;
        }

        return total;
    }
}