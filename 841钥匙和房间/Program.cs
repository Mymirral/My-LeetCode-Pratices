

public class Solution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        //访问表
        bool[] visited = new bool[rooms.Count];
        //访问过的房间数量
        int count = 0;
        DFS(rooms, visited, 0, ref count);
        return count == rooms.Count;
    }

    void DFS(IList<IList<int>> rooms, bool[] visited, int now, ref int count)
    {
        //当前访问的房间 => 标记访问
        visited[now] = true;
        //访问过的房间数+1
        count++;
        //遍历房间内的钥匙
        foreach (var key in rooms[now])
        {
            //如果是没去过的房间的钥匙
            if (!visited[key])
            {
                //到这个房间看看
                DFS(rooms, visited, key, ref count);
            }
        }
    }
}