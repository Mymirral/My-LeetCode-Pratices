

using System.ComponentModel.Design;

public class Test
{
    static void Main(string[] args)
    {
        Solution s = new Solution();

        Console.WriteLine(s.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
    }
}
public class Solution
{
    //访问表
    bool[] visited;
    bool res = false;       //结果
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if(n == 1) return true; //只有一个点，一定是true

        //实例化访问表
        visited = new bool[n];

        //构建连接表
        /*
         *  我之前用的List<List<int>>爆内存了
         *  
         *  用了这个之后就通过了
         */

        List<int>[] list = new List<int>[n];  
        for (int i = 0; i < n; i++)
        {
            list[i] = new List<int>();
        }

        

        for (int i = 0; i < edges.Length; i++)
        {
            list[edges[i][0]].Add(edges[i][1]);
            list[edges[i][1]].Add(edges[i][0]);
        }

        DFS(list, source, destination);

        return res;
    }

    public void DFS(List<int>[] map,int source,int destination)
    {
        if(source == destination) res = true;
        visited[source] = true;

        foreach (var item in map[source])
        {
            if (!visited[item])DFS(map, item, destination);
        }
    }
}
