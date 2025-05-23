

/*
 * 给你一个字符串 s ，请找出满足每个字符最多出现两次的最长子字符串，
 * 并返回该子字符串的 最大 长度
 */


public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaximumLengthSubstring("bcbbbcba"));
    }
    public static int MaximumLengthSubstring(string s)
    {
        int head = 0; //窗口头
        int tail = 0; //窗口尾
        
        int max = 0; //子串长度最大值  为 头 - 尾 +1

        Dictionary<char,int> record = new Dictionary<char,int>(); //用于记录目前窗口内的存在的字符及其次数

        while (head != s.Length)
        {
            if (record.ContainsKey(s[head]))    //如果包含这个字符
            {
                record[s[head]]++;  //次数加一
            }
            else //不包含进入的字符
            {
                record.Add(s[head], 1); //添加进字典
            }

            while (record[s[head]] > 2) //新进来的这个字符已经存在两个了, 就循环直到窗口内没有大于2的字符
            {
                tail++; //尾巴向前挪1
                if (record.ContainsKey(s[tail - 1])) //如果退出窗口的尾巴是窗口内存在的
                {
                    record[s[tail - 1]]--;  //次数减一
                    if (record[s[tail-1]] == 0) record.Remove(s[tail-1]);   //如果已经是0了，移除这个尾巴
                }
            }
            max = head - tail + 1 > max ? head - tail +1 : max; //更新最大值

            head++; //挪动头部
        }

       
        return max;
    }
}