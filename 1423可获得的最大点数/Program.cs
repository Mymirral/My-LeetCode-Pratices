


/*
 * 几张卡牌 排成一行，每张卡牌都有一个对应的点数。点数由整数数组 cardPoints 给出。
 * 每次行动，你可以从行的开头或者末尾拿一张卡牌，最终你必须正好拿 k 张卡牌。
 * 你的点数就是你拿到手中的所有卡牌的点数之和。
 * 给你一个整数数组 cardPoints 和整数 k，请你返回可以获得的最大点数。
 */

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaxScore([9, 7, 7, 9, 7, 7, 9], 7));
    }

    public static int MaxScore(int[] cardPoints, int k)
    {

        int windowLength = cardPoints.Length - k;

        long tempSum = 0;
        long min = int.MaxValue;

        for (int i = 0; i < windowLength; i++)
        {
            tempSum += cardPoints[i];
        }

        min = tempSum < min ? tempSum:min ;
        int start = 0;

        for (int i = windowLength; i < cardPoints.Length; i++)
        {
            tempSum += (cardPoints[i] - cardPoints[start]);
            min = tempSum < min ? tempSum : min;
            start++;
        }

        return (int)(cardPoints.Sum() - min);
    }
}