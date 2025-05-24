



public class Solution
{
    static void Main(string[] args)
    {
        var res = NextGreaterElements([1, 2, 1]);
        foreach (var item in res)
        {
            Console.WriteLine(item);
        }
    }

    public static int[] NextGreaterElements(int[] nums)
    {
        var result = new int[2*nums.Length];
        Array.Fill(result,-1);
        var stack = new Stack<int>();

        for(int i = 0; i<2*nums.Length; i++)
        {
            while (stack.Count > 0 && nums[stack.Peek() % nums.Length] < nums[i%nums.Length])
            {
                result[stack.Pop()] = nums[i % nums.Length];
            }
            stack.Push(i);
        }

        return result.Select(x => x == 0 ? -1 : x).Take(nums.Length).ToArray(); 
    }
}