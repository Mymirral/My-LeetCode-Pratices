class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.CarFleet(13, [10, 2, 5, 7, 4, 6, 11], [7, 5, 10, 5, 9, 4, 1]));
    }
}
public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var dict = Enumerable.Range(0, position.Length)
            .OrderByDescending(a => position[a])
            .ToDictionary(i => position[i], i => (float)(target - position[i]) / speed[i]);
        var stack = new Stack<int>();
        foreach(var item in dict)
        {
            if (stack.Count == 0 || item.Value > dict[stack.Peek()])
            {
                stack.Push(item.Key);
            }
        }
        return stack.Count;

        /*
        我们按从离终点近到远排序（position 降序），计算每辆车到达终点的时间 t = (target - position) / speed，然后按时间入栈：
        栈为空时 → 入栈
        栈顶时间 < 当前时间 → 新车队（入栈）
        否则 → 忽略（因为它会追上前面的车队）
        */
    }
}