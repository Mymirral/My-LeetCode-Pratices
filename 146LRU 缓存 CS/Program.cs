


public class LRUCache
{
    int _capacity;
    Dictionary<int, LinkedListNode<(int, int)>> map = new();
    LinkedList<(int, int)> cache = new();
    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (map.ContainsKey(key))
        {
            cache.Remove(map[key]);
            cache.AddFirst(map[key]);
            return map[key].Value.Item2;
        }
        else return -1;
    }

    public void Put(int key, int value)
    {
        if (map.ContainsKey(key))   //已经有这个键值对了
        {
            var node = map[key]; //获取当前节点
            cache.Remove(node); //从链表中移除
        }
        else if (map.Count >= _capacity)
        {
            //没有这个键值对，但是满了
            map.Remove(cache.Last.Value.Item1);
            cache.RemoveLast();
        }
        var newnode = new LinkedListNode<(int, int)>((key, value));
        cache.AddFirst(newnode);
        map[key] = newnode; //添加到字典中
    }
}