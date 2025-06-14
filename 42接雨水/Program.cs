


//接雨水，高频考题？

//找到比栈顶高的数，再要一个栈顶之前的数，就能构成一个水桶

/*
 
 
        
        0    0
        00  00
        000000   比如这个， 遍历到5，找到上一个栈顶的高度，4，再找到上上个栈顶高度2，可以计算出来，2-5能装多少水
        123456
 */
public class Solution
{
    public int Trap(int[] height)
    {
        var stack = new Stack<int>();
        int res = 0;

        for (int i = 0; i < height.Length; i++)
        {
            //这个while代表了  **回头去找**
            while (stack.Count > 0 && height[i] >= height[stack.Peek()]) //如果栈不空，同时这根柱子比栈顶的高(或者一样高)，这个一样高要细品
            {
                //记住往回找的目的： 填平坑/  计算出这个根柱子能和上一个栈顶接多少水
                //因为只有比栈顶高的时候才会进这个循环，所以，记住这个栈一直是单调递减的，一样高也会进入循环，是为了使得标记位正常

                //否则，记录一下，桶底就是栈顶
                int bottom = stack.Pop();

                if (stack.Count == 0) break; //如果这个栈空了，说明只有一条边，跳过啦

                //上上个栈顶就是围起来的桶
                //这里还不能把它弹出来
                //因为这个上上上个栈顶可能比这个还高
                int left = stack.Peek();

                res += (Math.Min(height[left], height[i]) - height[bottom]) * (i - left - 1);
            }
            stack.Push(i);
        }

        return res;
    }
}


class Test
{
    static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine(s.Trap([4, 2, 0, 3, 2, 5]));
    }
/*           0
        0    0
        0  0 0
        00 000
        00 000
 */
}