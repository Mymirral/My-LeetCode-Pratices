


/*
 * 给你一个字符串 s ，请你返回满足以下条件且出现次数最大的 任意 子串的出现次数：
 * 子串中不同字母的数目必须小于等于 maxLetters 。
 * 子串的长度必须大于等于 minSize 且小于等于 maxSize 。
 */



class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaxFreq("abcde", 2,3,3));
    }

    public static int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
    {
        Dictionary<string, int> times = new Dictionary<string, int>();      //子串出现的次数
        Dictionary<char,int> letterTime = new Dictionary<char,int>();       //字母出现的次数

        string now = "";
        int max = 0;
        bool reachMax = false;

        for (int i = 0; i < minSize; i++)
        {
            if (!letterTime.ContainsKey(s[i]))      //如果窗口内没有这个字母
            {
                letterTime.Add(s[i],1); //添加进字典
                if(letterTime.Count > maxLetters)//如果字典里的总数已经大于规定的
                {
                    reachMax = true;
                }
            }
            else//已经有这个字母了
            {
                letterTime[s[i]]++; 
            }
            now += s[i];  //窗口进入新字符 
        }

        if(!reachMax) times.Add(now, 1);   //没达到阈值，添加进字典，赋值为一
        if (times.ContainsKey(now))
        {
            if (times[now] > max)
            {
                max = times[now];
            }
        }

        int start = 0; //窗口出去的值的下标

        //开始滑动窗口
        for (int i = minSize; i < s.Length; i++)
        {
            letterTime[s[start]]--;  //出窗口的字符数量减1
            now = now.Substring(1); //去掉最开始的字符
            if (letterTime[s[start]] == 0) letterTime.Remove(s[start]);  //如果出窗口的这个字母已经不在窗口内存在，删掉它
            if(letterTime.Count == maxLetters) reachMax = false;

            //接下来看进窗口内部的字符
            if (letterTime.ContainsKey(s[i]))//如果进来窗口内的本来就已经有了
            {
                letterTime[s[i]]++;
            }
            else//如果进来的是窗口内没有的
            {
                letterTime.Add(s[i], 1);
                if (letterTime.Count > maxLetters)//如果字典里的总数已经大于规定的
                {
                    reachMax = true;
                }
            }
            now += s[i]; //窗口内的字符串加上进来的那一个

            if (!reachMax) //如果没超过阈值
            {
                if (times.ContainsKey(now)) //如果已经有这个子串
                {
                    times[now]++;
                }
                else//否则
                {
                    times.Add(now, 1);
                }
            }
            if (times.ContainsKey(now))
            {
                if (times[now] > max)
                {
                    max = times[now];
                }
            }
            start++;
        }
        return max;
    }
}