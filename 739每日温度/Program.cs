public class Solution
{
    static void Main(string[] args)
    {
        
    }

    //我嘞个豆哇，ai直接从题库找到的代码
    public int[] DailyTemperatures(int[] temperatures)
    {
        var result = new int[temperatures.Length];
        var stack = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                var index = stack.Pop();
                result[index] = i - index;
            }
            stack.Push(i);
        }

        return result; 
    }
}