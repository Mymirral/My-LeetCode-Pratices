

//给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。

//如果反转后整数超过 32 位的有符号整数的范围 [−231,  231 − 1] ，就返回 0。

//假设环境不允许存储 64 位整数（有符号或无符号）。



//第一眼看到这题想用常规做法，就是用计算的方法
//后面看见他说不允许存储 64 位整数，所以...我用转格式，用数组反转做了,     ------然后错了

//后面评论区看见了说用异常捕获的，我试了一下，过了很多实例，但是依然存在错误  测试：-2147483648

//所以我在各个可能出异常的地方都用了异常捕获
//然后就对了  😂

public class Pg
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int x = Convert.ToInt32(Console.ReadLine());
        x = solution.Reverse(x);
        Console.WriteLine(x);
    }
}
public class Solution
{
    public int Reverse(int x)
    {

        bool minus = false;
        if (x < 0)
        {
            minus = true;
        }

        int REx;
        try
        {
            REx = Math.Abs(x);
        }
        catch 
        {
            return 0; 
        }
        
        string RESx = REx.ToString();
        char[] RECx = RESx.ToCharArray();
        Array.Reverse(RECx);
        string RESRx = new string(RECx);
        try
        {
            REx = Convert.ToInt32(RESRx);
        }
        catch { return 0; }

        if (minus) { return -REx; }
        else { return REx; }

    }
}

//总结，题目不难，难点在于要求：环境不允许存储 64 位整数（有符号或无符号）
//因为int数的范围是  -2^31 - 2^31-1
//所以会出异常，要求不允许存储 64 位整数，即题目要求不能使用LONG
//
//做是做出来了,但是算法比较暴力，后续有待加强...
//问题：1、字符串转换的效率较低
//     2、使用太多库函数，效率较低
//还是这样，后续还得加强