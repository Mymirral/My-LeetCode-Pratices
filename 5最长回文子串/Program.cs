

//给你一个字符串 s，找到 s 中最长的回文子串。
//如果字符串的反序与原始字符串相同，则该字符串称为回文字符串。


//我想一下暴力枚举法
//以第一个数为标，从最后一个数开始往回数，
//如果遇到一样的就进入另一个循环，然后两个数相互靠近判断
public class MainProgram
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string output = Solution.LongestPalindrome(input);
        Console.WriteLine(output);
    }
}

public class Solution
{
    public static string LongestPalindrome(string s)
    {
        char[] chars = s.ToCharArray();     //把进入的字符串变成数组

        List<int[]> ints = new List<int[]>();

        int tou = 0;    //头下标
        int wei = 0;    //尾下标

        bool judge = false;        //判断一下是不是回环
        bool find = false;        //判断一下是不是已经找到了

        for (int i = 0; i < s.Length; i++)      //从第一个数开始历遍
        {
            char head = chars[i];       //以这个char为回型字符串的头
            char tail;                 //这个是尾

            for (int j = chars.Length - 1; j > i; j--)      //从最后一个数开始判断，看看有没有和头一样的字符
            {

                if (chars[j] == head)  //这个时候确定了尾和头一样时，就该确定他们之间的数回不回型
                {
                    tail = chars[j];
                    tou = i + 1;        //头的下标
                    wei = j - 1;        //尾的下标，+1和-1是为了少循环一次

                    for (int l = 0; l < j - i - 1; l++)  //是为了少循环      
                    {
                        if (chars[tou] != chars[wei]) { break; }
                        tou++;
                        wei--;
                    }//第三个循环：看看是不是回环

                    //如果循环三完整的循环下来，说明是回环，这个时候有：
                    //tou == j && wei == i

                    if (tou == j && wei == i)
                    {
                        tou = i;
                        wei = j;
                        judge = true;
                        find = true;
                        break;
                    }
                }

            }//第二个循环：找尾
            if (find)   //如果找到回环了，存一下泛型集合，方便判断哪个回环最长
            {
                int[] num = new int[2];
                num[0] = tou;
                num[1] = wei;
                ints.Add(num);
                find = false;
            }
        }//第一个循环：定头

        //确定最长的回环
        int max = 0;
        int index = 0;
        for (int i = 0; i < ints.Count; i++)
        {
            max = max > ints[i][1] - ints[i][0] ? max : ints[i][1] - ints[i][0];
        }
        for (int i = 0; i < ints.Count; i++)
        {
            if (max == ints[i][1] - ints[i][0])
            {
                index = i; break;
            }
        }
        //这个时候，泛型集合里面下标为i的int[]是最长回环的头尾

        //确定头尾的下标后，把要截的字符串从数组里面变出来

        if(ints.Count == 0)     //如果没有回环
        {
            return chars[0].ToString();
        }

        char[] output = new char[max + 1];
        Array.Copy(chars, ints[index][0], output, 0, max + 1);
        string oo = new string(output);
        return oo;
    }
}

//总结，题目总体不难，草，我做了3个小时，缝缝补补才过的
//问题出在考虑不全面啊，
//1、如果没有回环的情况
//2、如果后面有比前面回环更长的情况