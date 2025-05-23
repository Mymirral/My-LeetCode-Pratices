

/*
 * 给你一个长度为 n 下标从 0 开始的字符串 blocks ，blocks[i] 要么是 'W' 要么是 'B' ，表示第 i 块的颜色。字符 'W' 和 'B' 分别表示白色和黑色。
 * 给你一个整数 k ，表示想要 连续 黑色块的数目。
 * 每一次操作中，你可以选择一个白色块将它 涂成 黑色块。
 * 请你返回至少出现 一次 连续 k 个黑色块的 最少 操作次数。
 */


class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MinimumRecolors("WBBWWBBWBW",7));
    }

    public static int MinimumRecolors(string blocks, int k)
    {
        int min = 100;
        char white = 'W';
        int now = 0;
        //先建立窗口,长度为K
        for (int i = 0; i < k; i++)
        {
            if (blocks[i] == white)
            {
                now++;
            }
            
        }
        if(now == 0)return 0;
        min = now;

        int start = 0;
        //开始滑动
        for (int i = k;i<blocks.Length;i++)
        {
            if (blocks[start] == white) now--;
            if (blocks[i] == white) now++;
            if(now < min) min = now;
            start++;
        }
        
        return min;
    }
}