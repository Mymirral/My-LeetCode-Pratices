
Solution s = new();
s.Generate(5);
public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> res = new();

        res.Add(new List<int>() { 1 });
        if (numRows == 1)
        {
            return res;
        }

        res.Add(new List<int>() { 1, 1 });
        if (numRows == 2)
        {
            return res;
        }


        for (int i = 2; i < numRows; i++)
        {
            List<int> list = new List<int>();

            list.Add(1);
            for (int j = 1; j < i; j++)
            {
                list.Add(res[i - 1][j-1] + res[i - 1][j]);
            }
            list.Add(1);

            res.Add(list);
        }

        return res;
    }
}