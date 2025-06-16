
class Test
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        solution.TwoSum(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11);
    }
}
public class Solution
{

    /*
     * 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target  的那 两个 整数，并返回它们的数组下标。
     * 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。
     * 你可以按任意顺序返回答案。
     */
    /*  //暴力
        public int[] TwoSum(int[] nums, int target)
        {

            //拿第一个数和其他数值相加，如果没有，排除第一个数，选取第二个数依次循环，
            //若成功，程序退出。

            bool a = false;
            int[] Dt = new int[2];
            for (int i = 0; i < nums.Length; i++) //外部循环  取第一个数
            {
                for (int j = i + 1; j < nums.Length; j++)          //内部循环  取从第一个数开始的下一个数
                {
                    if (nums[i] + nums[j] == target)
                    {
                        Dt[0] = i;
                        Dt[1] = j;
                        a = true;
                    }
                }
                if (a)
                {
                    break;
                }
            }
            return Dt;
        }*/
    //哈希
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        var res = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            if (!keyValuePairs.ContainsKey(nums[i]))    //如果字典里没有 num[i] ，说明没有和为target的目标
            {
                if (keyValuePairs.ContainsKey(target - nums[i]))
                {
                    continue;
                }
                keyValuePairs.Add(target - nums[i], i);     //键添加为 target - num[i] ， 同时把num[i] 的 下标添加上
            }
            else
            {
                res[0] = keyValuePairs[nums[i]];  //如果有num[i] ， 说明之前有一个 target-num[i(之前的i)]  = num[i(当前的i)]
                res[1] = i;
                break;
            }
        }

        return res;
    }
}