public class Test
{
    static void Main(string[] args)
    {
        var s = new Solution();
        var c = new int[][] { [1, 1, 0], [1, 1, 0], [0, 0, 1] };
        Console.WriteLine(s.FindCircleNum(c));
    }
}

public class Solution
{
    int count = 0;  //省份数量
    bool[]? visited;
    public int FindCircleNum(int[][] isConnected)
    {
        //建立城市访问表
        visited = new bool[isConnected.Length];
        for (int i = 0; i < isConnected.Length; i++)
        {
            //如果这个城市已经遍历过了，到下个城市
            if (visited[i]) continue;
            else
            {  
                //否则，测试连通
                BFS(i,isConnected);
                count++;
            }
        }
        return count;
    }

    void BFS(int city, int[][] isConnected)
    {
        //标记这个城市被访问了
        visited[city] = true;

        //跑一下，这个城市的连通性
        for (int i = 0; i < isConnected.Length; i++)
        {
            //如果访问过了，下个城市
            if (visited[i]) continue ;
            //如果没有，对新的城市遍历
            if (isConnected[city][i] == 1) BFS(i,isConnected);
        }
    }
}