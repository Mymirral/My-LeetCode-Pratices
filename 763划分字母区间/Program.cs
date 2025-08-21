
Solution s = new();
s.PartitionLabels("ababcbacadefegdehijhklij");

public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        List<int> res = new();
        Dictionary<char, int> record = new();

        //记录每个字母最远距离
        for (int i = 0; i < s.Length; i++)
        {
            record[s[i]] = i;
        }

        int start = 0;
        while (start < s.Length)
        {
            int end = record[s[start]];
            int i = start;
            while (i <= end)
            {
                end = Math.Max(end, record[s[i]]);
                i++;
            }
            res.Add(i - start);
            start = i;
        }

        return res;
    }
}

   
