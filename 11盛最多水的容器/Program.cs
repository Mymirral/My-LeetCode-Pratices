
//暴力解法会导致计算量过大，超时！！

public class Codes
{
    static void Main(string[] args)
    {
       Solution solution = new Solution();
        int[] ints = { 2, 3, 4, 5, 18, 17, 6 };
        int max = solution.Maxwater(ints);
        Console.WriteLine(max);
    }
}

public class Solution
{
    public int Maxwater(int[] x)
    {
        int max = 0;                //最大值
        int len = x.Length-1;
        int head=0;
        int tail=len;

        #region 暴力历遍
        //for (int i = 0; i < x.Length-1; i++) 
        //{

        //    for (int j = i+1;j<x.Length;j++)
        //    {
        //        len = j - i;
        //        int S = len * (x[j] > x[i] ? x[i] : x[j]);
        //        if (S > max) max = S;
        //    }
        //}
        #endregion

        #region 双指针
        //头尾一个指针，哪头长哪头不动，动短的
        if (len == 1 ) { return x[head] > x[tail] ? x[tail] : x[head]; }
        int S = len * (x[head] > x[tail] ? x[tail] : x[head]);
        max = S > max ? S : max;
        for (int i = 0;i<x.Length-2;i++) 
        {
            
            if (x[head] > x[tail])
            {
                tail--;
            }
            else
            {
                head++;
            }
            len--;
            S = len * (x[head] > x[tail] ? x[tail] : x[head]);
            max = S > max ? S : max;
        }
        #endregion
        return max;
    }
}
