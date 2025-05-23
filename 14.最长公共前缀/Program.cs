

public class Code
{
    static void Main(string[] args)
    {
        string[] words = new string[] { "flower", "flower", "flower", "flower" };
        Solution solution = new Solution();
        Console.WriteLine(solution.LongestCommonPrefix(words));
    }
}
//纵向历遍
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if(strs.Length == 1) { return strs[0]; }
        if (strs.Contains("")) {  return ""; }
        bool on = true;
        List<char> same = new List<char>();
        string samestr="";
        int x = 0;
        while (on)   //调用循环，从第一个字符开始历遍组里每个字符串
        {
            
                 //第一个字符串
            for (int i = 0; i < strs.Length - 1; i++)
            {
                try 
                {
                    if (strs[i][x] != strs[i + 1][x])
                    {
                        on = false;
                        break;
                    }
                }
                catch 
                {
                    on = false;
                    break;
                }
               
            }
            if (!on) { break; }
            same.Add(strs[0][x]);
            x++;
            
        }
        for (int i = 0;i<same.Count;i++)
        {
            samestr += same[i];
        }
        return samestr;
    }
}