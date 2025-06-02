public class Test
{
    static void Main(string[] args)
    {
        int[][] c =
        {
            [0,2,1,0],[4,0,0,3],[1,0,0,4],[0,3,2,0]
        };
        Solution s = new Solution();

        Console.WriteLine(s.FindMaxFish(c));
    }
}

public class Solution
{
    int[][] dirs = new int[][] {
        new int[] { -1, 0 }, // 上
        new int[] { 1, 0  },  // 下
        new int[] { 0, -1 }, // 左
        new int[] { 0, 1  }   // 右
        };
    int area = 0;
    public int FindMaxFish(int[][] grid)
    {
        int row = 0;    //行
        int col = 0;    //列
        int areas = 0;
        while (row < grid.Length)
        {
            while (col < grid[row].Length)
            {
                if (grid[row][col] > 0) Dfs(row, col, grid);
                col++;
                areas = area > areas ? area : areas;
                area = 0;
            }
            col = 0;
            row++;
        }
        return areas;
    }

    void Dfs(int row, int col, int[][] grid)
    {
        area += grid[row][col];
        grid[row][col] = 0;
        foreach (var dir in dirs)
        {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            if (newRow >= 0 && newRow < grid.Length &&
                newCol >= 0 && newCol < grid[0].Length)
            {
                if (grid[newRow][newCol] > 0)
                {
                    Dfs(newRow, newCol, grid);
                }
            }
        }
    }
}