

/*
 * 给你字符串 s 和整数 k 。
 * 请返回字符串 s 中长度为 k 的单个子字符串中可能包含的最大元音字母数。
 * 英文中的 元音字母 为（a, e, i, o, u）。
 */

public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaxVowels("tryhard", 4)); 
    }

    public static int MaxVowels(string s, int k)
    {
        char[] chars = {'a','e','i','o','u' };  //元音
        int max = 0;    //最大值
        int now = 0;    //现在的元音数

        for (int i = 0; i < k; i++)
        {
            if (chars.Contains(s[i])) now++;
        }
        max = now;

        int start = 0;
        for (int i = k;i<s.Length;i++)
        {
            if (chars.Contains(s[i])) now++;
            if (chars.Contains(s[start])) now--;
            start++;
            if(now>max) max = now;
        }

        return max;
    }
}