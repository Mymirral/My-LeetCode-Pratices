
/*
 * 交换 定义为选中一个数组中的两个 互不相同 的位置并交换二者的值。
 * 环形 数组是一个数组，可以认为 第一个 元素和 最后一个 元素 相邻 。
 * 给你一个 二进制环形 数组 nums ，返回在 任意位置 将数组中的所有 1 聚0集在一起需要的最少交换次数。
 */


public class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MinSwaps([1, 1, 0, 0, 1]));
    }
    public static int MinSwaps(int[] nums)
    {
        //理清一下思路
        //窗口中有几个0，就要移动几次
        //要知道有几个0，就用子串的长度减去1的总数
        //子串中1的总数等于子串的数字和

        //难点： 数组环形 （首尾相连）

        int oneNum = nums.Sum();    //1的总数就是数组的和
        List<int> window = new List<int>(); //窗口/子串

        int oneNumWin;
        int min = oneNum;   //最小值指的是0的最少次数， 其实就是  窗口长度（1的总数）- 子串1的个数

        //建立窗口
        for (int i = 0; i < oneNum; i++)
        {
            window.Add(nums[i]);
        }

        //对第一个窗口进行处理
        //窗口内1的总数
        oneNumWin = window.Sum();
        //对窗口进行处理
        //0的个数等于 1的总数 - 窗口中1的总数
        min = min > oneNum - oneNumWin ? oneNum - oneNumWin : min; //如果0的总数小于min ， 则更新min


        int outer = 0;  //退出窗口的值的下标
        //开始滑动窗口
        for (int i = oneNum; i < nums.Length; i++)
        {
            window.Remove(nums[outer]); //去掉退出窗口的
            window.Add(nums[i]);        //加上进入窗口的

            //对新窗口进行处理
            //窗口内1的总数
#if 过于耗时
            oneNumWin = window.Sum(); 
#endif

            if (nums[i] == 1) oneNumWin++;
            if (nums[outer]==1 ) oneNumWin--;

            //对窗口进行处理
            //0的个数等于 1的总数 - 窗口中1的总数
            min = min > oneNum - oneNumWin ? oneNum - oneNumWin : min; //如果0的总数小于min ， 则更新min
            outer++;
        }

        //对环形窗口进行滑动
        //滑动次数等于  窗口（子串）的长度-1
        for (int i = 0; i < window.Count - 1; i++)
        {
            window.Remove(nums[outer]); //去掉退出窗口的
            window.Add(nums[i]);    //加上进入窗口的


            //对新窗口进行处理
            //窗口内1的总数
#if 过于耗时
            oneNumWin = window.Sum(); 
#endif
            if (nums[i] == 1) oneNumWin++;
            if (nums[outer] == 1) oneNumWin--;
            //对窗口进行处理
            //0的个数等于 1的总数 - 窗口中1的总数
            min = min > oneNum - oneNumWin ? oneNum - oneNumWin : min; //如果0的总数小于min ， 则更新min
            outer++;
        }

        return min;
    }
}