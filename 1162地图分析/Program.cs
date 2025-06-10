

//初次解法，暴力枚举，超时
//public class Solution
//{
//    //方向矩阵
//    int[][] dirs = new int[][]
//    {
//           new int[] { -1, 0 },
//           new int[] { 1, 0 },
//           new int[] { 0, -1 },
//           new int[] { 0, 1 }
//    };

//    public int MaxDistance(int[][] grid)
//    {
//        int maxdistance = -1;
//        //遍历整个表
//        for (int r = 0; r < grid.Length; r++)
//        {
//            for (int c = 0; c < grid[r].Length; c++)
//            {
//                //遇到海洋就进行BFS
//                if (grid[r][c] == 0)
//                {
//                    //新建一个一样的地图进行历遍
//                    //int[][] newGrid = new int[grid.Length][];
//                    //Array.Copy(grid, newGrid, grid.Length);

//                    int[][] newGrid = new int[grid.Length][];
//                    for (int i = 0; i < grid.Length; i++)
//                    {
//                        newGrid[i] = new int[grid[i].Length];
//                        Array.Copy(grid[i], newGrid[i], grid[i].Length);
//                    }

//                    //进行BFS
//                    int dis = BFS( r, c, newGrid);
//                    maxdistance = Math.Max(maxdistance, dis);
//                }
//            }
//        }
//        return maxdistance;
//    }   

//    int BFS(int r, int c, int[][] grid)
//    {
//        int dis=0;

//        //队列
//        var queue = new Queue<(int, int)>();
//        //海洋块入列
//        queue.Enqueue((r, c));
//        //做标记
//        grid[r][c] = 2;

//        while (queue.Count() > 0)
//        {
//            //每一层，曼哈顿距离加1
//            dis++;
//            int size = queue.Count();
//            for (int i = 0; i < size; i++)
//            {
//                var pos = queue.Dequeue();
//                r = pos.Item1;
//                c = pos.Item2;
//                foreach (var dir in dirs)
//                {
//                    int nr = r + dir[0];
//                    int nc = c + dir[1];

//                    if (nr >= 0 && nr < grid.Length &&
//                        nc >= 0 && nc < grid[0].Length)
//                    {
//                        //如果新块是0，入列，做标记
//                        if (grid[nr][nc] == 0)
//                        {
//                            queue.Enqueue((nr, nc));
//                            grid[nr][nc] = 2;
//                        }
//                        //如果是1，说明是最近的陆地块
//                        if (grid[nr][nc] == 1)
//                        {
//                            //返回
//                            return dis;
//                        }
//                    }
//                }
//            }
//        }
//        return -1;
//    }
//}


//多源BFS
public class Solution
{
    public int MaxDistance(int[][] grid)
    {
        //方向矩阵
        int[][] dirs = new int[][]
       {
           new int[] { -1, 0 },
           new int[] { 1, 0 },
           new int[] { 0, -1 },
           new int[] { 0, 1 }
       };

        //队列
        var queue = new Queue<(int, int)>();

        //把所有陆地添加到队列中
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    queue.Enqueue((i, j));
                }
            }
        }

        //如果全是海洋或者全是陆地
        if (queue.Count() == 0 || queue.Count() == grid.Length * grid[0].Length)
        {
            return -1;
        }

        //这里应该是-1，因为开始的时候 +1 ，变成0，是开始
        int maxDistance = -1;

        /*
         * 初始：
            1 0 0   //第0层，开始遍历才开始出队，所以出队之前是0
            0 0 0
            0 0 0

            第一层扩散（距离1）：
            1 1 0
            1 0 0
            0 0 0

            第二层扩散（距离2）：
            1 1 1
            1 1 0
            1 0 0

            第三层扩散（距离3）：
            1 1 1
            1 1 1
            1 1 0

            第四层扩散（距离4）：
            1 1 1
            1 1 1
            1 1 1
         */

        while (queue.Count() > 0)
        {
            int size = queue.Count();

            //每一层加1
            maxDistance++;

            for (int i = 0; i < size; i++)
            {
                var pos = queue.Dequeue();
                int r = pos.Item1;
                int c = pos.Item2;
                foreach (var dir in dirs)
                {
                    int nr = r + dir[0];
                    int nc = c + dir[1];

                    if (nr >= 0 && nr < grid.Length && nc >= 0 && nc < grid[0].Length && grid[nr][nc] == 0)
                    {
                        queue.Enqueue((nr, nc));
                        grid[nr][nc] = 1;
                    }
                }
            }
        }

        return maxDistance;
    }
}