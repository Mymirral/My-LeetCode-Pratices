/*
 * 你有一个炸弹需要拆除，时间紧迫！你的情报员会给你一个长度为 n 的 循环 数组 code 以及一个密钥 k 。
 * 为了获得正确的密码，你需要替换掉每一个数字。所有数字会 同时 被替换。
 * 如果 k > 0 ，将第 i 个数字用 接下来 k 个数字之和替换。
 * 如果 k < 0 ，将第 i 个数字用 之前 k 个数字之和替换。
 * 如果 k == 0 ，将第 i 个数字用 0 替换。
 * 由于 code 是循环的， code[n-1] 下一个元素是 code[0] ，且 code[0] 前一个元素是 code[n-1] 。
 * 给你 循环 数组 code 和整数密钥 k ，请你返回解密后的结果来拆除炸弹！你有一个炸弹需要拆除，时间紧迫！
 * 你的情报员会给你一个长度为 n 的 循环 数组 code 以及一个密钥 k 。
 * 为了获得正确的密码，你需要替换掉每一个数字。所有数字会 同时 被替换。
 * 如果 k > 0 ，将第 i 个数字用 接下来 k 个数字之和替换。
 * 如果 k < 0 ，将第 i 个数字用 之前 k 个数字之和替换。
 * 如果 k == 0 ，将第 i 个数字用 0 替换。
 * 由于 code 是循环的， code[n-1] 下一个元素是 code[0] ，且 code[0] 前一个元素是 code[n-1] 。
 * 给你 循环 数组 code 和整数密钥 k ，请你返回解密后的结果来拆除炸弹！
 */


public class Solution
{
    static void Main(string[] args)
    {
        int[] xs = Decrypt([10, 5, 7, 7, 3, 2, 10, 3, 6, 9, 1, 6], - 4);
        foreach (int i in xs)
        {
            Console.WriteLine(i);
        }
    }
    public static int[] Decrypt(int[] code, int k)
    {
        int[] result = new int[code.Length];
        int sum = 0;
        if (k >= 0)
        {
            //建立窗口
            for (int i = 0; i < k; i++)
            {
                sum += code[i];
            }

            result[code.Length - 1] = sum;

            int start = 0;

            for (int i = k; i < code.Length; i++)
            {
                sum += (code[i] - code[start]);
                result[start] = sum;
                start++;
            }

            int end = 0;

            for (int i = 0; i < k - 1; i++)
            {
                sum += (code[end] - code[start]);       //记住， end 是下一个进入窗口的，start是下一个出窗口的，所以start永远是窗口外的，
                result[start] = sum;
                start++;
                end++;
            }
        }

        else
        {
            k = -k;
            //建立窗口
            for (int i = 0; i < k; i++)
            {
                sum += code[i];
            }

            result[k] = sum;

            int start = 0;

            for (int i = k; i < code.Length; i++)
            {
                sum += (code[i] - code[start]);
                if(i==code.Length-1)result[0] = sum;
                else result[i+1] = sum;
                start++;
            }

            int end = 0;

            for (int i = 0; i < k - 1; i++)
            {
                sum += (code[end] - code[start]);       //记住， end 是下一个进入窗口的，start是下一个出窗口的，所以start永远是窗口外的，
                result[i+1] = sum;
                start++;
                end++;
            }
        }


        return result;
    }
}