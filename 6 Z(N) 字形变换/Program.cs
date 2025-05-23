
//将一个给定字符串 s 根据给定的行数 numRows ，以从上往下、从左到右进行 Z 字形排列。

//比如输入字符串为 "PAYPALISHIRING" 行数为 3 时，排列如下：

//P   A   H   N
//A P L S I I G
//Y   I   R
//之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："PAHNAPLSIIGYIR"。


//观察一下，PAYPALISHIRING用三行输出，每一个小部分，即
//P
//A P   这个可以称为一个部分，去掉头行和尾行只有，中间部分都是输出两个字符，即每一个部分 有 2 +（总行数-2）* 2 个 字符，  以三行为例有  2 +（3-2）*2 = 4 个字符
//Y 

//再观察：3行是       4行是         5行是         6行是
//          1           1               1           1
//          2 4         2  6            2   8       2    10      观察规律，发现： 同一列两个数有这个关系：   前和后相差（总行数-列数）* 2  
//          3           3 5             3  7        3   9
//                      4               4 6         4  8
//                                      5           5 7
//                                                  6
using System.ComponentModel;

public class MainProgram
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = Console.ReadLine();
        int row = Convert.ToInt32(Console.ReadLine());
        s = solution.Convert(s, row);
        Console.WriteLine(s);

    }
}

public class Solution
{
    public string Convert(string s, int numRows)
    {
        char[] cs = s.ToCharArray();        //把字符串s变成char数组
        List<char> N = new List<char>();    //用一个泛型集合来接收变换后的s

        //具体做法:

        //先看每一部分有几个字符，一个字符到下一部分同位置字符的次数
        int partnum = 2 + (numRows - 2) * 2;    

        //如果只有1行就不循环了
        if(numRows ==1) { return s; }
        //有几行就循环几次
        for (int i = 0; i < numRows; i++)
        {
            int x = i;
            //因为添加超过数组的部分会报错，所以利用这一点，用try
            try
            {
                while (true)
                {
                    //添加这一行的第一个数
                    N.Add(cs[x]);
                    //除去头部和尾部
                    if (i!=0&&i!=numRows-1)
                    {
                        N.Add(cs[x+(numRows-(i+1))*2]);       //这里i+1是因为 i作为列数，比实际列数少了1
                    }
                    x += partnum;   
                }
            }
            catch { }
        }


        //把泛型集合char数组转换为字符串返回
        string Ns = new string(N.ToArray());
        return Ns;


    }
}

//总结：
//第一个错误： 我审题没审明白，我弄成一部分一部分输出了。不过实际上，首尾可以用这个方法！

//题目不难，但是我用的这个方法是暴力添加，用时640ms！！！  可能是因为try函数特别耗时间
//有待改进