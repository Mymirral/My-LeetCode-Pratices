
#include <unordered_map>
#include <queue>
using namespace std;

class LRUCache {
public:
    int _capacity;
    unordered_map<int,int> map;
    queue<int> cache;

    LRUCache(int capacity) : _capacity(capacity)
    {
    };

    int get(int key) {
        if (map.find(key) != map.end())
        {
            int value = cache.back();
            cache.pop();
            cache.push(value);
            return map[key];
        }
        else
            return -1;
    }

    void put(int key, int value) {
        if (map.find(key) != map.end())
        {
            map[key] = value;
        }
        else
        {
            if (cache.size() < _capacity)
            {
                map[key] = value;
            }
            else
            {
                cache.pop();
                cache.push(key);
                map[key] = value;
            }
        }
    }
};
