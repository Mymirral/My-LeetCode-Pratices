

//请你来实现一个 myAtoi(string s) 函数，使其能将字符串转换成一个 32 位有符号整数。

//函数 myAtoi(string s) 的算法如下：

//空格：读入字符串并丢弃无用的前导空格（" "）
//符号：检查下一个字符（假设还未到字符末尾）为 '-' 还是 '+'。如果两者都不存在，则假定结果为正。
//转换：通过跳过前置零来读取该整数，直到遇到非数字字符或到达字符串的结尾。如果没有读取数字，则结果为0。
//舍入：如果整数数超过 32 位有符号整数范围 [−231,  231 − 1] ，需要截断这个整数，使其保持在这个范围内。具体来说，小于 −2^31 的整数应该被舍入为 −2^31 ，大于 2^31 − 1 的整数应该被舍入为 2^31 − 1 。
//返回整数作为最终结果。


public class Pro
{
    public static void Main(string[] args)
    {
        string x = Console.ReadLine();
        Solution solution = new Solution();
        Console.WriteLine(solution.MyAtoi(x));
    }
}

public class Solution
{
    public int MyAtoi(string s)
    {
        bool minus = false;  //判断正负

        s = s.Trim();        //去除首位空格

        int i = 0;           //循环下标

        string number = "";
        int Num = 0;
        try
        {
            if (s[0] == '-') { minus = true; i++; }      //如果是负数
            if (s[0] == '+') i++;
        }
        catch { return 0; }

        char[] num = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        try
        {
            while (num.Contains(s[i]))
            {
                number += s[i];
                i++;
            }
        }
        catch { }

        try
        {
            Num = Convert.ToInt32(number);
        }
        catch
        {

            if (i>3)
            {
                if (minus) { return -2147483648; }
                return 2147483647; 
            }
        }

        if (minus) { return -Num; }
        return Num;
    }
}


//总结： 自从用来异常捕获之后，就停不下来辣！！！！
//
//      这种题吧，不难，但是呢，他各种情况在你打代码的时候你都没想到
//      比如： 只有一个空格，什么都不输入，只输入一个-，或者输入+-，或者输入+-+数字
//            锻炼思维吧，唉。