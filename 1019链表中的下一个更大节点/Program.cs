





//Definition for singly - linked list.
using System.Drawing;

class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        ListNode listNode = new ListNode(2,new(7,new(4,new(3,new(5)))));
        Console.WriteLine(solution.NextLargerNodes(listNode));
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public int[] NextLargerNodes(ListNode head)
    {
        var stack = new Stack<(int,ListNode)>();
        Dictionary<int, int> ans = new();

        int key = 0;
        while (head != null)
        {
            //往回找的条件，栈里有东西，当前这个节点比栈顶的节点要大
            while(stack.Count > 0 && head.val > stack.Peek().Item2.val)
            {
                //进入这个循环的
                //节点是单调递减的
                //当前节点一定比栈顶高

                var point = stack.Pop();
                if (!ans.ContainsKey(point.Item1)) ans.Add(point.Item1, 0);
                ans[point.Item1] = head.val;  //栈顶的下一个最大节点就是当前这个节点
            }

            stack.Push((key,head));
            key++;
            head = head.next; //别忘了把节点变成下一个
        }


        //栈里面剩下的就全是没有找到更高节点的点，所以都是0
        foreach(var point in stack)
        {
            if (!ans.ContainsKey(point.Item1)) ans.Add(point.Item1, 0);
        }

        return ans.OrderBy(ans => ans.Key).Select(ans => ans.Value).ToArray();
    }
}