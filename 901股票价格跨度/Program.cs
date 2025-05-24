
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

    List<int> list;
    public StockSpanner()
    {
        list = new List<int>();
    }

    public int Next(int price)
    {
        list.Add(price);
        int count = 1;
        for (int i = list.Count - 1; i>=0; i--)
        {
            if (list[i] <= price) count++;
            else break;
        }
        return count;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */