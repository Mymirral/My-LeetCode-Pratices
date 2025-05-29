
public class Test
{
    static void Main(string[] args)
    {
        int[][] c =
        {
            [0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]
        };

        Solution s = new Solution();

        Console.WriteLine(s.MaxAreaOfIsland(c));
    }
}

public class Solution
{
    int[][] dirs = new int[][] {
    new int[] { -1, 0 }, // 上
    new int[] { 1, 0 },  // 下
    new int[] { 0, -1 }, // 左
    new int[] { 0, 1 }   // 右
    };
    public int MaxAreaOfIsland(int[][] grid)
    {
        int area = 0;
        int result = 0;
        int row = 0;    //行
        int col = 0;    //列

        while (row < grid.Length)
        {
            while (col < grid[row].Length)
            {
                if (grid[row][col] == 1)
                {
                    Fire(row, col, grid, ref area);
                }
                result = result < area ? area : result;
                area = 0;
                col++;
            }
            row++;
            col = 0;
        }

        return result;
    }

    public void Fire(int row, int col, int[][] islands, ref int area)
    {
        area++;
        islands[row][col] = 0;
        foreach (var dir in dirs)
        {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            if (newRow >= 0 && newRow < islands.Length &&
                newCol >= 0 && newCol < islands[0].Length &&
                islands[newRow][newCol] == 1)
            {
                Fire(newRow, newCol, islands, ref area);
            }
        }
    }
}