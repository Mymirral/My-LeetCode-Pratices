

//这个b题目我都不行复制描述
//焯！！
//自己去看leetcode 1052


public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaxSatisfied([1, 0, 1, 2, 1, 1, 7, 5], [0, 1, 0, 1, 0, 1, 0, 1],3));
    }

    public static int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {

        //窗口内必定 3 个 0，
        //窗口外的 0 另外计算

        int start = 0;
        int now = 0;
        int max = 0;

        for (int i = 0; i < customers.Length; i++)
        {
            if (grumpy[i] == 0) now += customers[i];
        }

        //建立窗口
        for(int i = 0; i < minutes; i++)
        {
            if (grumpy[i] == 1) now += customers[i]; //窗口内对应的 1 加进去
        }
        if (now > max) max = now;

        //滑动
        for (int i = minutes; i < customers.Length; i++)
        {
            if(grumpy[start] == 1) now -= customers[start];
            start++;
            if (grumpy[i] == 1) now += customers[i];
            if (now > max) max = now;
        }

        return max;



        //76/78 超时
        //while (end <= customers.Length) //窗口的尾部小于数组长度
        //{
        //    //窗口历遍吧...
        //    for (int i = 0; i < customers.Length; i++)
        //    {
        //        //如果i是在窗口内
        //        if (i >= start && i < end) now += customers[i];
        //        else
        //        {
        //            //如果不是窗口内的，判断老板生没生气
        //            if (grumpy[i] == 0) now += customers[i];
        //        }
        //        if (now > max) max = now;
        //    }
        //    now = 0;
        //    start++;
        //    end++;
        //}
        //return max;
    }
}