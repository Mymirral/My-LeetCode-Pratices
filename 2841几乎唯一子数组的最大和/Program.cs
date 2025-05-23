


public class Solution
{

    static void Main(string[] args)
    {
        Console.WriteLine(MaxSum([996021492, 996021492, 973489433, 66259330, 554129007, 713784351, 646092981, 328987029, 469368828, 685679486, 66259330, 165954500, 731567840, 595800464, 552439059, 14673238, 157622945, 521321042, 386913607, 733723177, 330475939, 462727944, 69696035, 958945846, 648914457, 627088742, 363551051, 50748590, 400980660, 674779765, 439950964, 613843311, 385212079, 725525766, 813504429, 385212079, 66563232, 578031878, 935017574, 554725813, 456892672, 245308625, 626768145, 270964388, 554725813, 768296675, 676923124, 939689721, 115905765, 625193590, 717796816, 27972217, 277242430, 768296675, 480860474, 659230631, 570682291, 601689140, 955632265, 767424000, 251696645, 675750691, 767424000, 251696645, 767424000, 675750691, 675750691, 251696645], 8, 8));
    }
    public static long MaxSum(IList<int> nums, int m, int k)
    {
        List<long> window = new List<long>();
        long sumMax = 0;
        int diffNum = k;

        //建立窗口
        for (int i = 0;i<k;i++)
        {
            if (window.Contains(nums[i])) diffNum --;
            window.Add(nums[i]);
        }

        if (diffNum >= m) { sumMax = window.Sum(); }

        int start = 0;

        for (int i = k;i< nums.Count;i++)
        {
            window.Remove(nums[start]);
            if (window.Contains(nums[start])) diffNum++;
            if (window.Contains(nums[i])) diffNum--;         
            if (diffNum < m)
            {
                window.Add(nums[i]);
                start ++;
                continue;
            }
            window.Add(nums[i]);
            start++;
            if(window.Sum() > sumMax) sumMax = window.Sum();
        }
        return sumMax;
    }
}

#if 优质算法
public class Solution
{
    public long MaxSum(IList<int> nums, int m, int k)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int diffCount = 0;
        long ans = 0;
        long tempSum = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            if (dic.ContainsKey(nums[i]))
            {
                dic[nums[i]]++;
            }
            else
            {
                dic[nums[i]] = 1;
                diffCount++;
            }
            tempSum += nums[i];
            if (i < k - 1) continue;
            if (dic.Count >= m) ans = Math.Max(ans, tempSum);
            tempSum -= nums[i - k + 1];
            dic[nums[i - k + 1]]--;
            if (dic[nums[i - k + 1]] == 0) dic.Remove(nums[i - k + 1]);
        }
        return ans;
    }
}
#endif