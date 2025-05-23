


//给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。

//'.' 匹配任意单个字符
//'*' 匹配零个或多个前面的那一个元素
//所谓匹配，是要涵盖 整个 字符串 s的，而不是部分字符串。

//花了一点点时间看懂了题目

//. = 任意字符
//X* = (0~n)X


//2024.5.16  要区配的话....得想个方法

//2024.5.17  好难啊...  ,好好学一下DP 动态规划再来吧...哥们脑细胞耗尽了

//2024.5.18  害...试试另一种方法吧，329 / 356 个通过的测试用例

//2024.5.25  看了题解，还真的是用的迭代，从右往左遍历，然后遇到星号的，按照3个模式：  不重复，检查剩下的。重复一次，再检查剩下的。重复两次或以上再检查剩下的。这种方式，寻找正确解法。   

using System.Text.RegularExpressions;



public class Pro
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        string p = Console.ReadLine();
        //Solution solution = new Solution();
        //bool b = solution.IsMatch(s, p);
        //Console.WriteLine(b);

    }
}


//搏斗法！ 
//如果区配：1、p有*：s下标加一 
//         2、p无*：sp下标加一
//如果不匹配：1、p有*：p下标加二
//           2、p无*：区配失败

//同时有条件：s的长度一定大于等于p中不带*的字母

//被 bbbba  .*a*a 卡了

//被aabcbcbcaccbcaabc  .*a*aa*.*b*.c*.*a* 卡了,这个的本质是找.*后面没带*的数是否区配



#region 最后一次靠自己做的， 329 / 356 个通过的测试用例
//public class Solution


//{
//    public bool IsMatch(string s, string p)
//    {
//        //判断*号个数
//        int z = 0;
//        for (int i = 0; i < p.Length; i++)
//        {
//            if (p[i] == '*') z++;
//        }//通过循环可以获得*号个数z

//        //s，p当前匹配的字母的下标
//        int m = 0, n = 0;

//        while (m != s.Length && n != p.Length)  //在两方都没有到尽头的时候
//        {
//            if (n + 1 != p.Length)  //如果此时p不是最后一个字母
//            {
//                while (p.Length - n - 2 * z >= s.Length - m && p[n + 1] == '*')//如果s的数比p的数小,同时当前的p字符带*  1没考虑到每个字母都要*的情况
//                {
//                    n += 2;
//                    z--;
//                    if (n + 1 == p.Length)      //p已经是最后一个字符了
//                    {
//                        break;
//                    }
//                }
//            }


//            if (Match(s[m], p[n]))       //区配成功
//            {
//                if (n + 1 == p.Length)//如果p是最后一个数
//                {
//                    n++;
//                    m++;
//                }
//                else if (p[n + 1] == '*')//p当前字母有*
//                {
//                    if (m + 1 == s.Length && n + 2 == p.Length)    //如果p是最后一个数且带*
//                    {
//                        return true;
//                    }
//                    m++;
//                }
//                else
//                {
//                    n++;
//                    m++;
//                }
//                if (n == p.Length)
//                {
//                    break;
//                }
//            }

//            else //区配失败
//            {
//                if (n + 1 == p.Length || (p[n + 1] == '*' && n + 2 == p.Length))//如果p是最后一个数,
//                {
//                    break;
//                }
//                else if (p[n + 1] == '*')//p当前字母有*
//                {
//                    n += 2;
//                    z--;
//                }
//                else         //p无*
//                {
//                    break;
//                }
//            }


//        }

//        if (m == s.Length && n == p.Length) return true;
//        else if (m == s.Length && n + 1 == p.Length) return false;
//        else if (m == s.Length && p[n + 1] == '*' && n + 2 == p.Length) return true;         //这种情况是 s区配完了，p也是最后一个字母但是p带了*
//        else if(p.Length - n - 2 * z == 0&&m == s.Length) return true;          //这种情况是   aa  a*a*  
//        else return false;


//    }


//    public bool Match(char s, char p)
//    {
//        if (s == p || p == '.') { return true; }
//        else return false;
//    }
//} 
#endregion
