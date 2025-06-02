
public class Test
{
    static void Main(string[] args)
    {
        var c = new string[] { "110", "231", "221" };

        Solution s = new Solution();

        Console.WriteLine(s.LargestArea(c));
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
    int area;
    bool isAdjacentToCorridor = false; // 如果碰到了边界，就标记为true，如果为true，不加入area
    public int LargestArea(string[] grid)
    {
        char[][] map = grid.Select(row => row.ToCharArray()).ToArray();
        int row = 0;    //行
        int col = 0;    //列
        List<int> areas = new List<int>();
        while (row < map.Length)
        {
             while (col < map[row].Length)
            {
                if (map[row][col] != 'x') Dfs(row, col, map, map[row][col]);
                col++;
                if (!isAdjacentToCorridor) areas.Add(area);
                isAdjacentToCorridor = false ;
                area = 0;
            }
            col = 0;
            row++;
        }
        return areas.Count>0? areas.Max():0;
    }

    public void Dfs(int row, int col, char[][] map, char num)
    {
        area++;
        if (row == 0 || row == map.Length - 1 || col == 0 || col == map[row].Length - 1)
        { 
            isAdjacentToCorridor = true;
        }
        if (map[row][col] == '0')
        {
            isAdjacentToCorridor = true;
            return;
        }
        map[row][col] = 'x';
        foreach (var dir in dirs)
        {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            if (newRow >= 0 && newRow < map.Length &&
                newCol >= 0 && newCol < map[0].Length)
            {
                if (map[newRow][newCol] == '0')
                {
                    isAdjacentToCorridor = true;
                    return;
                }
                if(map[newRow][newCol] == num)
                Dfs(newRow, newCol, map, num);
            }
        }


    }
}