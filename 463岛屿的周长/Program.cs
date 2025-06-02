

public class Test
{
    static void Main(string[] args)
    {
        int[][] c =
        {
            [0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]
        };
        Solution s = new Solution();

        Console.WriteLine(s.IslandPerimeter(c));
    }
}

public class Solution
{
    int[][] dirs = new int[][] {
        new int[] { -1, 0 }, // 上
        new int[] { 1, 0 },  // 下
        new int[] { 0, -1 }, // 左
        new int[] { 0, 1 }  // 右
        };
    int Perimeter = 0;
    public int IslandPerimeter(int[][] grid)
    {

        int row = 0;    //行
        int col = 0;    //列
        List<int> areas = new List<int>();
        while (row < grid.Length)
        {
            while (col < grid[row].Length)
            {
                if (grid[row][col] == 1) Dfs(row, col, grid);
                col++;
            }
            col = 0;
            row++;
        }
        return Perimeter;
    }
    void Dfs(int row, int col, int[][] grid)
    {
        grid[row][col] = 2;
        foreach (var dir in dirs)
        {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            if (newRow >= 0 && newRow < grid.Length &&
                newCol >= 0 && newCol < grid[0].Length)
            {
                if (grid[newRow][newCol] == 1) Dfs(newRow, newCol, grid);
                if (grid[newRow][newCol] == 0) Perimeter++;
            }
            else Perimeter++;
        }
    }
}