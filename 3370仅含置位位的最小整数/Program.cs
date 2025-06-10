

public class Solution
{
    public int SmallestNumber(int n)
    {
        #region 我自己写的
        /*int final = 0;
        int time = 0;
        while (true)
        {
            if (final > n) return final;
            final += 1 << time;
            time++;
        } */
        #endregion

        //看了题解自己写一遍
        int bits = Convert.ToString(n,2).Length;
        return (1 << bits) - 1;
        //这个的意思：
        /*
         获取输入int的二进制长度，比如：5是101，长度是3，
        然后构造全集：
        111

        构造方法就是：（1<<3）  =>  1000 - 1， =>  0111
        
         */
    }
}