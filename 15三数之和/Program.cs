
public class Codes
{
    static void Main(string[] args)
    {
        int[] ints = { -4, -2, 1, -5, -4, -4, 4, -2, 0, 4, 0, -2, 3, 1, -5, 0 };
        Solution solution = new Solution();
        Console.WriteLine(solution.ThreeSum(ints));
    }
}

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> Sum = new List<IList<int>>();
        List<int> plus = new List<int>();       //正数
        List<int> minus = new List<int>();      //负数
        List<int> zero = new List<int>();    //0
        
        
        for (int i = 0; i < nums.Length; i++)       //把正数负数分配到不同的集合里面
        {
            if (nums[i] > 0) { plus.Add(nums[i]); }
            else if (nums[i] < 0) { minus.Add(nums[i]); }
            else { zero.Add(nums[i]); }
        }
        plus.Sort();
        minus.Sort();
        //特殊情况：无正、无负、数组小于等于3、全都是0

        if ((plus.Count == 0 && zero.Count < 3) || (minus.Count == 0 && zero.Count < 3) || nums.Length < 3) { return Sum; }
        if (nums.Length == 3)
        {
            if (nums[0] + nums[1] + nums[2] == 0)
            {
                IList<int> Sum0 = [nums[0], nums[1], nums[2]];
                Sum.Add(Sum0);
                return Sum;
            }
        }
        if (zero.Count >= 3)
        {
            IList<int> Sum0 = [0,0,0];
            Sum.Add(Sum0);
        }


        //接下来进行三次筛选：1、有0   2、无0 两正一负  3、无0 两负一正

        int pLen = plus.Count;
        int mLen = minus.Count;


        if (nums.Contains(0))  //情况1
        {
            for (int i = 0; i <pLen; i++)
            {
                if (i > 0) { if(plus[i - 1] == plus[i]) continue; } //如果这个数和上个数相同，就继续
                if (minus.Contains(-1*plus[i]))
                {
                    IList<int> Sum0 = [plus[i], 0, -1 * plus[i]];
                    Sum.Add(Sum0);
                }
            }
        }

        //情况2：
        for (int i = 0; i < pLen - 1; i++)
        {
            if (i > 0) { if (plus[i - 1] == plus[i]) { continue; } }
            for (int j = i + 1; j < pLen; j++)
            {
                if (j > i+1) { if (plus[j-1] == plus[j]) { continue; } }
                if (minus.Contains(-1 * (plus[i] + plus[j])))
                {
                    IList<int> Sum0 = [plus[i], plus[j], -1 * (plus[i] + plus[j])];
                    Sum.Add(Sum0);
                }
            }
        }
        //情况3：
        for (int i = 0; i < mLen - 1; i++)
        {
            if (i > 0) { if (minus[i - 1] == minus[i]) { continue; } }
            for (int j = i + 1; j < mLen; j++)
            {
                if (j > i+1) { if (minus[j - 1] == minus[j]) { continue; } }
                if (plus.Contains(-1 * (minus[i] + minus[j])))
                {
                    IList<int> Sum0 = [minus[i], minus[j], -1 * (minus[i] + minus[j])];
                    Sum.Add(Sum0);
                }
            }
        }


        return Sum;
    }
}