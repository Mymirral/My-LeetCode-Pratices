

using Microsoft.VisualBasic;

public class Solution
{
    static void Main(string[] args)
    {
        var x = new int[] { 8, 4, 6, 2, 3 };
        foreach (var item in FinalPrices(x))
        {
            Console.WriteLine(item);
        }
    }
    public static int[] FinalPrices(int[] prices)
    {
        //我不要用AI，我要自己写！
        var result = new int[prices.Length];
        var stack = new Stack<int>();
        for (int i = 0; i < prices.Length; i++)
        {
            while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
            {
                var index = stack.Pop();
                result[index] = prices[index] - prices[i];
            }
            stack.Push(i);
        }
        foreach (var item in stack)
        {
            result[item] = prices[item];
        }
        return result;
    }
}