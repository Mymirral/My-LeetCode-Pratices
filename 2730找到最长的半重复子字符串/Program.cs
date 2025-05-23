



/*
 * 给你一个下标从 0 开始的字符串 s ，这个字符串只包含 0 到 9 的数字字符。
 * 如果一个字符串 t 中至多有一对相邻字符是相等的，那么称这个字符串 t 是 半重复的 。例如，"0010" 、"002020" 、"0123" 、"2002" 和 "54944" 是半重复字符串，而 "00101022" （相邻的相同数字对是 00 和 22）和 "1101234883" （相邻的相同数字对是 11 和 88）不是半重复字符串。
 * 请你返回 s 中最长 半重复子字符串的长度。
 */


public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(LongestSemiRepetitiveSubstring("00010"));
    }
    public static int LongestSemiRepetitiveSubstring(string s)
    {
        int head = 0;
        int tail = 0;

        int now = 0;
        int max = 0;

        int repet = 0;  //重复的子串

        while (head < s.Length)  //当head没到头
        {
            if(head != 0)
            {
                if(s[head] == s[head - 1])  //如果这个字符等于前一个字符
                {
                    repet++;
                }
            }

            while(repet >= 2)
            {
                if (s[tail] == s[tail + 1]) //如果尾巴等于倒数第二个数
                {
                    repet--;
                }

                tail++;
            }

            now = head - tail + 1;
            max = Math.Max(max, now);

            head++;
        }
        return max;
    }
}


//乐 ， 写了10分钟的字典... 
//结果换了一种最简单的写法就过了...