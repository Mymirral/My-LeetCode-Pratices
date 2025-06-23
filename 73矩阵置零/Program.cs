





public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        List<(int, int)> map = new();

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    map.Add((i, j));
                }
            }
        }

        foreach (var i in map)
        {
            int row = i.Item1;
            int col = i.Item2;
            SetZerosLeft(matrix, row, col);
            SetZerosRight(matrix, row, col);
            SetZerosUp(matrix, row, col);
            SetZerosDown(matrix, row, col);
        }
    }

    void SetZerosLeft(int[][] martrix, int row, int col)
    {
        if (col - 1 < 0) return;
        if (martrix[row][col - 1] != 0) martrix[row][col - 1] = 0;
        SetZerosLeft(martrix, row, col - 1);
    }

    void SetZerosRight(int[][] martrix, int row, int col)
    {
        if (col + 1 == martrix[0].Length) return;
        if (martrix[row][col + 1] != 0) martrix[row][col + 1] = 0;
        SetZerosRight(martrix, row, col + 1);
    }

    void SetZerosUp(int[][] martrix, int row, int col)
    {
        if (row - 1 < 0) return;
        if (martrix[row - 1][col] != 0) martrix[row - 1][col] = 0;
        SetZerosUp(martrix, row - 1, col);
    }

    void SetZerosDown(int[][] martrix, int row, int col)
    {
        if (row + 1 == martrix.Length) return;
        if (martrix[row + 1][col] != 0) martrix[row + 1][col] = 0;
        SetZerosDown(martrix, row + 1, col);
    }
}