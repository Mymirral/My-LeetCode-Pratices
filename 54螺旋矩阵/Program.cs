







class Test
{
    static void Main(string[] args)
    {
        Solution s = new();
        s.SpiralOrder([[1, 2, 3]]);
    }
}






public class Solution
{
    List<int> res = new List<int>();

    //用边界判断，当边界相接，结束
    public IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix.Length == 0) { return new List<int>(); }

        int u = 0, r = matrix[0].Length, d = matrix.Length, l = 0;

        while (true)
        {
            for (int i = l; i < r; i++) { res.Add(matrix[u][i]); }
            u++;
            if (u == d) break;
            for (int i = u; i < d; i++) { res.Add(matrix[i][r - 1]); }
            r--;
            if (r == l) break;
            for (int i = r - 1; i >= l; i--) { res.Add(matrix[d - 1][i]); }
            d--;
            if (d == u) break;
            for (int i = d - 1; i >= u; i--) { res.Add(matrix[i][l]); }
            l++;
            if (l == r) break;
        }

        return res;
    }
}