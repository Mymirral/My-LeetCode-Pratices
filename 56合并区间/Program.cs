
class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]));
    }
}
public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        Stack<int[]> stack = new Stack<int[]>();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        for (int i = 0; i < intervals.Length; i++)
        {
            bool merged = false;

            if(stack.Count > 0 && intervals[i][0] <= stack.Peek()[1])
            {
                int[] ints = stack.Pop();

                stack.Push(new int[2] { Math.Min(ints[0], intervals[i][0]), Math.Max(ints[1], intervals[i][1]) });

                merged = true;
            }

            if (!merged) stack.Push(intervals[i]);
        }

        return stack.ToArray();
    }

    //这道题的重点是排序！！！！！！！！
}