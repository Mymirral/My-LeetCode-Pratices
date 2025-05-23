


/*
 * 给你一个字符数组 letters，该数组按非递减顺序排序，以及一个字符 target。letters 里至少有两个不同的字符。
 * 返回 letters 中大于 target 的最小的字符。如果不存在这样的字符，则返回 letters 的第一个字符。
 */



using System.Text;

public class Solution
{

    //也很好解决啦其实

    //char字符对应一个 ASCII 值
    //比对即可
    //题目：  返回 letters 中大于 target 的最小的字符, 即类型是  大于target
    //大于target 则使用target+1

    static void Main(string[] args)
    {
        Console.WriteLine(NextGreatestLetter(['x', 'x', 'y'],'z'));
    }


    public static char NextGreatestLetter(char[] letters, char target)
    {
        //开区间
        int left = -1;
        int right = letters.Length;

        while(left + 1 < right)
        {
            int mid = left + (right - left) / 2;

            if (letters[mid] < target+1) left = mid;    //注意判断条件
            else right = mid;
        }

        if (right == letters.Length) return letters[0];
        return letters[right];
    }


}