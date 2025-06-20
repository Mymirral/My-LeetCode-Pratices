

using System.Diagnostics;

class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7],3));
    }
}

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        /* 超时
        int maxnum = 0;

        Queue<int> q = new Queue<int>();
        var list = new List<int>();

        for (int i = 0; i < k; i++)
        {
            q.Enqueue(nums[i]);
        }

        maxnum = q.Max();
        list.Add(maxnum);

        for (int i = k - 1; i < nums.Length; i++)
        {
            q.Dequeue();
            q.Enqueue(nums[i]);

            maxnum = q.Max();
            list.Add(maxnum);
        }

        return list.ToArray();
        */

        //单调队列

        if(nums == null||nums.Length==0) return new int[0];

        List<int> ints = new();
        LinkedList<int> l = new LinkedList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if(l.Count > 0 && l.First.Value < i -k +1)
            {
                l.RemoveFirst();
            }
            while (l.Count > 0 && nums[i] > nums[l.Last.Value])
            {
                l.RemoveLast();
            }

            l.AddLast(i);

            if(i >= k-1)ints.Add(nums[l.First.Value]);
        }

        return ints.ToArray();
    }
}