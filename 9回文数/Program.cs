

//给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。

//回文数
//是指正序（从左向右）和倒序（从右向左）读都是一样的整数。

//不用整型转字符串

public class Pro
{
    static void Main(string[] args)
    {
        int x = Convert.ToInt32 (Console.ReadLine());
        Solution solution = new Solution();
        Console.WriteLine(solution.IsPalindrome(x));
    }
}

public class Solution
{
    public bool IsPalindrome(int x)
    {
        //泛型集合用于接收x的每一位的数字
        List<int> list = new List<int>();
        
        //判断正负
        if (x < 0)return false;

        //拆除小数
        int i = 1;

        while(true)
        {
            if (x < 10)
            {
                //如果x小于10了，表示已经到头了,结束循环
                list.Add(x);
                break;
            }

            //取数字最后一位,用求余
            list.Add(x%10);
            //再取整
            x = x/10;
        }

        //最后再从泛型集合里面判断一下是不是回型
        int head = 0;
        int tail = list.Count-1;
        //相遇之前，一直循环
        while(head < tail) 
        {
            //判断不为回型
            if (list[head] != list[tail]) { return false; }
            head++;
            tail--;
        }
        return true;

    }
}

//总结：题目不难,真的不难，一次过
//     我还以为会面向测试呢哈哈，我还考虑了0110这种情况，结果好像不用考虑