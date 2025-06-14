

class Test
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(solution.ShortestDistanceAfterQueries(5, [[2, 4], [0, 2], [0, 4]]));
    }
}
public class Solution
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        int[] result = new int[queries.Count()];

        //构建邻接表
        List<int>[] map = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            map[i] = new List<int>();
            if (i != n - 1) map[i].Add(i + 1);
        }

        /*//最开始的思路： 每加一条边，重新跑一遍BFS => 超时
        for (int i = 0; i < queries.Length; i++)
        {
            map[queries[i][0]].Add(queries[i][1]);
            result[i] = BFS(map, n);
        }*/

        //更新思路，添加路径表， distance[i]表示0到i的距离
        int[] distance = new int[n];
        for (int i = 0; i < n; i++)
        {
            distance[i] = i;
        }


        for (int i = 0;i<queries.Length;i++)
        {
            //连接城市
            int u = queries[i][0]; 
            int v = queries[i][1];

            //为什么是这个判断条件： u+1是指u多走一步，如果比直接去v还远，说明新建的这条路，没有用
            if (distance[u] + 1 >= distance[v]) {result[i] = distance[n-1]; continue; }

            distance[v]  = distance[u] + 1;
            map[u].Add(v);
            BFS(map, n,distance,v);
            result[i] = distance[n - 1];
        }

        return result;
    }

    void BFS(List<int>[] map,int n, int[] distance,int start)
    {
        var queue = new Queue<int>();
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int now = queue.Dequeue();
            foreach(var next in map[now])
            {
                if (distance[now] + 1 < distance[next])
                {
                    //到next这个距离，等于到now这个距离再加1（因为连通了）
                    distance[next] = distance[now] + 1;
                    queue.Enqueue(next);
                }
            }
        }
    }
}