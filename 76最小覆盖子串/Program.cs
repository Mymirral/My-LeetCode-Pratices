
class Test
{
    static void Main(string[] args)
    {

        Solution solution = new Solution();

        Console.WriteLine(solution.MinWindow("av", "A"));
    }
}

public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";
        if (t.Length > s.Length) return "";
        

        Dictionary<char, int> tFreq = new Dictionary<char, int>();
        int check = 0;

        foreach (char c in t)
        {
            tFreq[c] = tFreq.GetValueOrDefault(c, 0) + 1;
        }

        Dictionary<char, int> sFreq = new Dictionary<char, int>();

        int minLen = int.MaxValue;
        int minStart = 0;

        int left = 0;
        int right = 0;

        while (right < s.Length)
        {
            char c = s[right];

            //如果右边进来的字符是t中的
            if (tFreq.ContainsKey(c))
            {
                sFreq[c] = sFreq.GetValueOrDefault(c, 0) + 1;

                //如果这个字符满足了t中的频率
                if (sFreq[c] == tFreq[c]) check++;
            }

            while (check == tFreq.Count) //字符种类相等的情况 , 缩小窗口
            {
                //更新最小窗口
                if (right - left < minLen )
                {
                    minStart = left;
                    minLen = right - left + 1;
                }

                char o = s[left];

                //如果离开窗口的字符是t中的
                if (sFreq.ContainsKey(o))
                {
                    sFreq[o]--;
                    if (sFreq[o] < tFreq[o]) check--;
                }

                left++;
            }

            //向右移动窗口
            right++;
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }
}