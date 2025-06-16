public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        if(s.Length < p.Length) return new List<int>();

        int[] pnums = new int[26];
        int[] snums = new int[26];

        List<int> list = new List<int>();

        int head = p.Length - 1;
        int tail = 0;

        for(int i = 0;i<p.Length; i ++)
        {
            pnums[p[i]-'a']++;
            snums[s[i]-'a']++;
        }
        string pString = string.Join("#", pnums);  // 关键：变成一个唯一表示结构的字符串,后续比对字符串
        string sString = string.Join("#", snums);  
        
        if(pString == sString) list.Add(tail);

        //开始滑动
        for (int i = head; i < s.Length -1; i++)
        {
            head++;
            snums[s[head] - 'a']++;
            snums[s[tail] - 'a']--;
            tail++;

            sString = string.Join("#", snums);
            if (pString == sString) list.Add(tail);
        }

        return list;
    }
}