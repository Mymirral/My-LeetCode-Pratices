

using System.Numerics;

public class Solution
{
    public int MinChanges(int n, int k)
    {
        /*
         * 首先  n = 13 ， k = 4 可以转换
         *      n = 1101 , k = 0100;
         *       n = 13 , k = 14 无法转换  
         *       n = 1101 , k = 1110；
         * 差别在哪？
         * 
         * 能转换时：k的1，只能出现在n的 1 处
         * 即： n&k  == k
         * 
         * 怎么转？
         * 求差
         * 1、先求异或：  1101^0100  => 1001
         * 2、求差：     ~(1101&1001)  =>  ~1011 => 0100 
         *  即：~(n&(n^k))
         */

        //if(n==k) return 0;
        //if ((n & k) != k) return -1;

        ////剩下的都是可以转换的，用异或求出1的个数，数就对了
        //var bits = Convert.ToString(n ^ k, 2);
        //var time = 0;
        //for (int i = 0; i < bits.Length; i++)
        //{
        //    if (bits[i] == '1') time++;
        //}
        //return time;


        //或者直接：
        return (n & k) != k ? -1 : BitOperations.PopCount((uint)(n ^ k));   //BitOperations.PopCount(),查找1的个数
    }
}