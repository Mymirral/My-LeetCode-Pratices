
public class Test
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.WatchedVideosByFriends([["A", "B"], ["C"], ["B", "C"], ["D"]], [[1, 2], [0, 3], [0, 3], [1, 2]],0,2));
    }
}
public class Solution
{
    
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
    {
        bool[] visited;
        Dictionary<string, int> result = new();
        visited = new bool[watchedVideos.Count];
        var queue = new Queue<int>();
        var time = 0;
        //先把我放进来
        queue.Enqueue(id);
        visited[id] = true;

        while (queue.Count > 0 && time < level)
        {
            //对我进行BFS
            int size = queue.Count;

            for (int i = 0; i < size; i++)
            {
                var people = queue.Dequeue();
                foreach (var friend in friends[people])
                {
                    if (!visited[friend])
                    {
                        queue.Enqueue(friend);
                        visited[friend] = true;
                    }
                } 
            }
            time++;     //完成一次是一层
        }

        //队列里的就是该Level的所有好友
        foreach(var man in queue)
        {
            //这个人看过的所有电视
            foreach (var TV in watchedVideos[man])
            {
                if(!result.ContainsKey(TV)) result.Add(TV,0);
                result[TV]++; //统计一下次数
            }
        }

        return result.OrderBy(x => x.Value)
            .ThenBy(x => x.Key) //关键： 频率相同时，按照字母顺序
            .Select(x => x.Key)
            .ToArray();
    }
}