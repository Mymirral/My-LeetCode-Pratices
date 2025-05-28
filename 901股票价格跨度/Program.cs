
public class Test
{
    static void Main(string[] args)
    {
        StockSpanner stockSpanner = new StockSpanner();
        Console.WriteLine(stockSpanner.Next(100));
        Console.WriteLine(stockSpanner.Next(80));
        Console.WriteLine(stockSpanner.Next(60));
        Console.WriteLine(stockSpanner.Next(70));
        Console.WriteLine(stockSpanner.Next(60));
        Console.WriteLine(stockSpanner.Next(75));
        Console.WriteLine(stockSpanner.Next(85));
    }
}
public class StockSpanner
{
    int day;
    Stack<Tuple<int,int>> stack;
    public StockSpanner()
    {
        day = -1;
        stack = new Stack<Tuple<int,int>>();
        stack.Push(new Tuple<int, int>(day,int.MaxValue));
    }

    public int Next(int price)
    {
        /* 暴力解法
        list.Add(price);
        int count = 1;
        for (int i = list.Count - 1; i>=0; i--)
        {
            if (list[i] <= price) count++;
            else break;
        }
        return count;
        */
        day++;
        //首先这个题目,要找到是上一个更大的数，相当于放进栈里的，按照要求弹出来后，
        //最后会呈现出单调递减的趋势。
        //就是说，放进去的，如果比上一个数大，上一个数是要掉脑袋的。
        while (stack.Count > 0 && price >= stack.Peek().Item2)
        {
            stack.Pop();
        }
        int res = day - stack.Peek().Item1;
        stack.Push(new Tuple<int, int>(day, price));
        return res;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */