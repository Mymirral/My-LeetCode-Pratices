

using System.Diagnostics.CodeAnalysis;

public class Solution
{
    public int[] LongestCommonPrefix(string[] words)
    {
        int[] pre = new int[words.Length];
        int[] sub = new int[words.Length];
        int[] res = new int[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            int max = 0;
            for(int j = i+1; j< words.Length - i - 1; j++)
            {
                int same = Presame(words[j], words[j + 1]);
                max = Math.Max(max, same);
            }
            pre[i] = max;
        }

        for (int i = words.Length - 1; i >= 0; i--)
        {
            int max = 0;
            for (int j = i-2;j >= 0; j--)
            {
                int same = Presame(words[j], words[j + 1]);
                max = Math.Max(max, same);
            }
            sub[i] = max;
        }

        for(int i = 0;i < res.Length;i++)
        {
            if(i==0 || i== res.Length-1) res[i] = Math.Max(sub[i], pre[i]);
            else res[i] = Math.Max(Math.Max(sub[i], pre[i]), Presame(words[i - 1], words[i+1]));
        }

        return res;

    }
    public int Presame(string str1, string str2)
    {
        int same = 0;
        for (int i = 0; i < (str1.Length > str2.Length ? str2.Length : str1.Length); i++)
        {
            if (str1[i] == str2[i])
            {
                same++;
            }
            else
            {
                break;
            }
        }
        return same;
    }
}



public class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.LongestCommonPrefix(["efe", "feae", "fb"]));
    }
}

//竞赛超时了..
/*public int[] LongestCommonPrefix(string[] words)
{
    int n = words.Length;
    int[] lcp = new int[n - 1];
    for (int i = 0; i < n - 1; i++)
    {
        lcp[i] = Presame(words[i], words[i + 1]);
    }


    int[] result = new int[words.Length];
    for (int i = 0; i < n; i++)
    {
        int max = 0;
        if (i > 0)
        max = Math.Max(max, i < n - 1 ? Presame(words[i - 1], words[i + 1]) : 0);

        for (int j = 0; j < n - 1; j++)
        {
            if (j == i || j + 1 == i) continue;
            max = Math.Max(max, lcp[j]);
        }
        result[i] = max;
    }
    return result;
}

public int Presame(string str1, string str2)
{
    int same = 0;
    for (int i = 0; i < (str1.Length > str2.Length ? str2.Length : str1.Length); i++)
    {
        if (str1[i] == str2[i])
        {
            same++;
        }
        else
        {
            break;
        }
    }
    return same;
}*/


//用前后缀去解决！