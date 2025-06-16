

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {

        Dictionary<string, IList<string>> res = new Dictionary<string, IList<string>>();  //记录字母数 和 结果

        foreach (string str in strs)
        {
            int[] s = new int[26];  //
            foreach (char i in str)
            {
                s[i - 97]++;    //对应字母
            }
            string key = string.Join("#", s);  // 关键：变成一个唯一表示结构的字符串
            if (!res.ContainsKey(key)) res.Add(key, new List<string>());
            res[key].Add(str);
        }

        return res.Values.ToList();
    }
    
}