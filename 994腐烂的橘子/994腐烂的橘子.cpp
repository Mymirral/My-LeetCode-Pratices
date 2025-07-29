#include <queue>
#include <vector>
#include <utility>
using namespace std;

class Solution {
public:
   
    vector<vector<int>> dirs =
    {
        {0,1},
        {0,-1},
        {1,0},
        {-1,0}
    };

    int orangesRotting(vector<vector<int>>& grid) {
        queue<pair<int,int>> queue;
        int time = 0;
        int fresh = 0;

        for (int i = 0; i < grid.size(); i++)
        {
            for (int j = 0; j < grid[0].size(); j++)
            {
                if (grid[i][j] == 2) queue.push({i,j});
                if (grid[i][j] == 1) fresh ++;
            }
        }

        while (!queue.empty())
        {
            if (fresh == 0) return time;

            int size = queue.size();
            for (int i = 0; i < size; i++)
            {
                pair<int, int> pos = queue.front();
                queue.pop();

                for (auto dir : dirs)
                {
                    int nr = pos.first + dir[0];
                    int nc = pos.second + dir[1];

                    if (nr >= 0 && nr < grid.size() &&
                        nc >= 0 && nc < grid[0].size() &&
                        grid[nr][nc] == 1)
                    {
                        grid[nr][nc] = 2;
                        fresh--;
                        queue.push({ nr, nc });
                    }
                }
            }
            time++;
        }


        if (fresh > 0) return -1;
        //添加fresh优化这个循环
        /*for (int i = 0; i < grid.size(); i++)
        {
            for (int j = 0; j < grid[0].size(); j++)
            {
                if (grid[i][j] == 1) return -1;
            }
        }*/

        return time == 0 ? 0 : time - 1;
    }
};