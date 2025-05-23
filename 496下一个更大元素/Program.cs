

public class Solution
{
    static void Main(string[] args)
    {
        var res = NextGreaterElement([4, 1, 2], [1, 3, 4, 2]);
        foreach (var item in res)
        {
            Console.WriteLine(item);
        }
    }
    public static int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        /*var nums = nums1
            .Select((value,index) => new {value, index})
            .ToDictionary(a=>a.value,a=>a.index); //Select的重载
        int[] result = new int[nums1.Length];
        Array.Fill(result, -1);
        var stack = new Stack<int>();

        for (int i = 0; i < nums2.Length; i++)
        {
            while (stack.Count > 0 && nums2[stack.Peek()] < nums2[i])
            {
                try
                {
                    result[nums[nums2[stack.Pop()]]] = nums2[i];
                }
                catch {
                }
            }
            stack.Push(i);
        }
        return result;*/

        //优化一下：
        var dic = new Dictionary<int, int>();
        var stack = new Stack<int>();

        foreach(var num in nums2)
        {
            while (stack.Count > 0 && stack.Peek() < num)
            {
                try
                {
                    dic[stack.Pop()] = num;
                }
                catch
                {
                }
            }
            stack.Push(num);
        }
        return nums1.Select(a=> dic.GetValueOrDefault(a,-1)).ToArray();
    }
}