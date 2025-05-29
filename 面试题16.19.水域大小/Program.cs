public class Test
{
    static void Main(string[] args)
    {
        int[][] c =
        {
            [0,2,1,0],
  [0,1,0,1],
  [1,1,0,1],
  [0,1,0,1]
        };

        Solution s = new Solution();

        foreach(var item in s.PondSizes(c))
        {
            Console.WriteLine(item);
        }
    }
}

public class Solution
{
    int[][] dirs = new int[][] {
    new int[] { -1, -1 }, // 左上
    new int[] { -1, 0 }, // 上
    new int[] { -1, 1 }, // 右上
    new int[] { 1, -1 },  // 左下
    new int[] { 1, 0 },  // 下
    new int[] { 1, 1 },  // 右下
    new int[] { 0, -1 }, // 左
    new int[] { 0, 1 }   // 右
    };
    public int[] PondSizes(int[][] land)
    {
        int area = 0;
        List<int> sizes = new List<int>();
        int row = 0;    //行
        int col = 0;    //列

        while (row < land.Length)
        {
            while (col < land[row].Length)
            {
                if (land[row][col] == 0)
                {
                    Fill(row, col, land, ref area);
                    sizes.Add(area);
                }
                //sizes.Add(area); 不是写在这里啊你这小子！
                area = 0;
                col++;
            }
            row++;
            col = 0;
        }
        return sizes.Order().ToArray();
    }
    public void Fill(int row, int col, int[][] islands, ref int area)
    {
        area++;
        islands[row][col] = 1;
        foreach (var dir in dirs)
        {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            if (newRow >= 0 && newRow < islands.Length &&
                newCol >= 0 && newCol < islands[0].Length &&
                islands[newRow][newCol] == 0)
            {
                Fill(newRow, newCol, islands, ref area);
            }
        }
    }
}