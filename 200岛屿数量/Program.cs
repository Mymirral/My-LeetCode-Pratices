
public class Test
{
    static void Main(string[] args)
    {
        char[][] c =
        {
            ['1','1', '1', '1', '0',],
            ['1','1', '0', '1', '0',],
            ['1','1', '0', '0', '0',],
            ['0','0', '0', '0', '0',]
        };

        Solution s = new Solution();

        Console.WriteLine(s.NumIslands(c));
    }
}
public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int count = 0;
        int row = 0;    //行
        int col = 0;    //列

        while (row < grid.Length)
        {
            while (col < grid[row].Length)
            {
                if (grid[row][col] == '1')
                {
                    Fire(row, col, grid);
                    count++;
                }
                col++;
            }
            row++;
            col = 0;
        }

        return count;
    }

    int[][] dirs = new int[][] {
    new int[] { -1, 0 }, // 上
    new int[] { 1, 0 },  // 下
    new int[] { 0, -1 }, // 左
    new int[] { 0, 1 }   // 右
};

    public void Fire(int row, int col, char[][] grid)
    {
        grid[row][col] = '0';
        foreach (var dir in dirs)
        {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            if (newRow >= 0 && newRow < grid.Length &&
                newCol >= 0 && newCol < grid[0].Length &&
                grid[newRow][newCol] == '1')
            {
                Fire(newRow, newCol, grid);
            }
        }
    }
}