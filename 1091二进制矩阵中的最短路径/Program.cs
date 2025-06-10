
class Test
{
    static void Main(string[] args)
    {
        
        var solution = new Solution();

        var grid = new int[][] { [0, 0, 0], [1, 1, 0], [1, 1, 0] };

        Console.WriteLine(solution.ShortestPathBinaryMatrix(grid));
    }
}

public class Solution
{
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int step = 1;
        var queue = new Queue<(int,int)>();
        if (grid[0][0] == 1) return -1;
        if (grid.Length == 1 && grid[0].Length == 1 && grid[0][0] == 0) return 1;
        queue.Enqueue((0, 0));
        grid[0][0] = 1; //做标记

        //方向矩阵
        int[][] dirs = new int[][]
        {
           new int[] { -1, 0 },
           new int[] { -1, 1 },
           new int[] { -1, -1 },
           new int[] { 1, 0 },
           new int[] { 1, 1 },
           new int[] { 1, -1 },
           new int[] { 0, -1 },
           new int[] { 0, 1 }
        };

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var pos = queue.Dequeue();
                int r = pos.Item1;
                int c = pos.Item2;

                foreach (var dir in dirs)
                {
                    int nr = r + dir[0], nc = c + dir[1];
                    if (nr >= 0 && nr < grid.Length &&
                    nc >= 0 && nc < grid[0].Length &&
                    grid[nr][nc] == 0)
                    {
                        if (nr == grid.Length-1 && nc == grid[0].Length-1) return step + 1;
                        queue.Enqueue((nr, nc));
                        grid[nr][nc] = 1; // 立即标记
                    }
                }
            }
            step ++;
        }

        return -1;
    }
}