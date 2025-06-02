

public class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.HalfQuestions([1, 5, 1, 3, 4, 5, 2, 5, 3, 3, 8, 6]));
    }
}

public class Solution
{
    public int HalfQuestions(int[] questions)
    {
        var result = questions
                     .GroupBy(n => n)                     // 按数字分组
                     .OrderByDescending(g => g.Count())   // 按出现次数降序排序
                     .ToDictionary(g => g.Key, g => g.Count()); // 转成字典
        //LINQ好用是好用，消耗是消耗
        int Count = questions.Length / 2;
        int minCout = 1;
        foreach (var item in result)
        {
            Count = Count - item.Value;
            if (Count <= 0) break;
            else minCout++;
        }

        return minCout;
    }
}