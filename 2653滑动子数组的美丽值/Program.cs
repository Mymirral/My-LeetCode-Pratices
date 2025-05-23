/*
 * 给你一个长度为 n 的整数数组 nums ，请你求出每个长度为 k 的子数组的 美丽值 。
 * 一个子数组的 美丽值 定义为：如果子数组中第 x 小整数 是 负数 ，那么美丽值为第 x 小的数，否则美丽值为 0 。
 * 请你返回一个包含 n - k + 1 个整数的数组，依次 表示数组中从第一个下标开始，每个长度为 k 的子数组的 美丽值 
 * 子数组指的是数组中一段连续 非空 的元素序列。
 */

public class Solution
{
    static void Main(string[] args)
    {
        int[] sz = GetSubarrayBeauty();
        foreach (int s in sz)
        {
            Console.WriteLine(s);
        }
    }
    public static int[] GetSubarrayBeauty(int[] nums, int k, int x)
    {
        int[] beauty = new int[nums.Length - k + 1];      //存美丽数
        Dictionary<int, int> search = new Dictionary<int, int>();
        int negetiveNum = 0;

        //先用字典把-50~-1存一个0
        for (int i = -50; i < 0; i++)
        {
            search.Add(i, 0);
        }

        //建立窗口
        for (int i = 0; i < k; i++)
        {
            if (nums[i] < 0)
            {
                search[nums[i]]++; //字典对应的负数
                negetiveNum++;
            }
        }

        //建立完第一个窗口（子串）之后,添加第一个美丽数
        int index = 1; //index代表第n小
        if (negetiveNum >= x)
        {
            for (int i = -50; i < 0; i++)
            {
                if (search[i] != 0) //如果这个值不为0，代表这个是第index小
                {

                    if (search[i] > 1)  //为了防止出现次数大于1
                    {
                        index += search[i] - 1;
                        if(x < index)   //说明第x小的数也是这个
                        {
                            beauty[0] = i;
                            index++;
                            break;
                        }
                    }
                    if (index == x)
                    {
                        beauty[0] = i;
                        index++;
                        break;
                    }
                    index++;

                }
            }
        }
        else
        {
            beauty[0] = 0;
        }

        //窗口滑动了
        int start = 0;
        for (int i = k; i < nums.Length; i++)
        {
            //先看出窗口的
            if (nums[start] < 0)
            {
                search[nums[start]]--;
                negetiveNum--;
            }

            //看进窗口的
            if (nums[i] < 0)
            {
                search[nums[i]]++;
                negetiveNum++;
            }


            if (negetiveNum >= x)
            {
                index = 1; //index代表第n小
                for (int j = -50; j < 0; j++)
                {
                    if (search[j] != 0) //如果这个值不为0，代表这个是第index小
                    {
                        if (search[j] > 1)
                        {
                            index += search[j] - 1;
                            if (x < index)   //说明第x小的数也是这个
                            {
                                beauty[start + 1] = j;
                                index++;
                                break;
                            }
                        }
                        if (index == x)
                        {
                            beauty[start + 1] = j;
                            index++;
                            break;
                        }
                        index++;
                    }
                }
            }
            else
            {
                beauty[start + 1] = 0;
            }

            start++;
        }
        return beauty;
    }
}