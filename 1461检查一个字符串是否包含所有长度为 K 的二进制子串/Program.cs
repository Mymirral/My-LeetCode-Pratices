
/*
 * 给你一个二进制字符串 s 和一个整数 k 。如果所有长度为 k 的二进制字符串都是 s 的子串，请返回 true ，否则请返回 false 
 */

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(HasAllCodes("0110",2));
    }

    public static bool HasAllCodes(string s, int k)
    {
        int length = (int)Math.Pow(2, k);
        List<string> strings = new List<string>();
        string codes;

        for (int i = 0; i < s.Length - k; i++)
        {
            codes = s.Substring(i, k);
            if(!strings.Contains(codes))strings.Add(codes);
        }

        return length == strings.Count;
    }
}