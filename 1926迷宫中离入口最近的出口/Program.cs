class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        var maze = new char[][]{ ['+', '+', '.', '+'], ['.', '.', '.', '+'], ['+', '+', '+', '.'] };
        var en = new int[]{ 1, 2 };
        Console.WriteLine(solution.NearestExit(maze,en));
    }
}
public class Solution
{
    public int NearestExit(char[][] maze, int[] entrance)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();  //新建一个队列
        queue.Enqueue((entrance[0], entrance[1]));          //放进入口
        maze[entrance[0]][entrance[1]] = '+'; //标记已经走过

        int step = 0;

        int[][] dirs = new int[][] 
        {
           new int[] { -1, 0 },
           new int[] { 1, 0 },
           new int[] { 0, -1 },
           new int[] { 0, 1 }
        };

        while (queue.Count > 0)
        {
            int size = queue.Count;  // 当前这一层有多少路
            for (int i = 0; i < size; i++)  //这一层嵌套很重要，说明一层有几个，一层一层去递进
            {
                (int, int) pos = queue.Dequeue();
                int r = pos.Item1;
                int c = pos.Item2;
                foreach (var dir in dirs)
                {
                    int nr = r + dir[0], nc = c + dir[1];
                    if (nr >= 0 && nr < maze.Length &&
                    nc >= 0 && nc < maze[0].Length &&
                    maze[nr][nc] == '.')
                    {
                        queue.Enqueue((nr, nc));
                        maze[nr][nc] = '+'; // 立即标记
                        if (nr == 0 || nc == 0 || nr == maze.Length - 1 || nc == maze[0].Length - 1)
                            return step;
                    }
                }
            }
            step++;
        }
        return -1;
    }
}