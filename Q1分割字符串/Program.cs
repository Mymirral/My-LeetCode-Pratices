


public class Solution
{
    public IList<string> PartitionString(string s)
    {
        List<string> res = new();
        HashSet<string> str = new();

        int left = 0;
        int right = 0;

        string window = "";

        while (right < s.Length)
        {
            window += s[right];

            if(!str.Contains(window))
            {
                str.Add(window);
                res.Add(window);
                left++;
                window = "";
            }
            right++;
        }

        return res;
    }
}