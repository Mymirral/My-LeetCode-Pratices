


/*
 * 给你两个长度相同的字符串，s 和 t。
 * 将 s 中的第 i 个字符变到 t 中的第 i 个字符需要 |s[i] - t[i]| 的开销（开销可能为 0），也就是两个字符的 ASCII 码值的差的绝对值。
 * 用于变更字符串的最大预算是 maxCost。在转化字符串时，总开销应当小于等于该预算，这也意味着字符串的转化可能是不完全的。
 * 如果你可以将 s 的子字符串转化为它在 t 中对应的子字符串，则返回可以转化的最大长度。
 * 如果 s 中没有子字符串可以转化成 t 中对应的子字符串，则返回 0。
 */



public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(EqualSubstring("pxezla", "loewbi", 25));
        Console.WriteLine('p'-'l');
        Console.WriteLine('x'-'o');
        Console.WriteLine('z'-'w');
        Console.WriteLine('l'-'b');
        Console.WriteLine('a'-'i');
    }
    public static int EqualSubstring(string s, string t, int maxCost)
    {
        int head = 0;   //头
        int tail = 0;   //尾

        int cost = 0;
        int max = 0;

        while (head < s.Length)   //开始窗口滑动
        {
            cost += Math.Abs(t[head] - s[head]);  //新进入窗口字符串的花销

            while (cost > maxCost)   //如果现在的消费大于最大值
            {
                cost -= Math.Abs(t[tail] - s[tail]);  //减去尾部的消费         //我他们真的是服了， 我一开始把这里的tail写成了head， 还能他吗的对20多个例子

                tail++; //尾前挪
            }

            if (cost <= maxCost)
            {
                max = Math.Max(max, head - tail + 1);
            }

            head++;
        }

        return max;
    }
}