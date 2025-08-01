#include <unordered_map>
#include <queue>
#include <vector>
using namespace std;

class Solution {
public:
    bool canFinish(int numCourses, vector<vector<int>>& prerequisites) {

        queue<int> queue;
        unordered_map<int, vector<int>> coursenext; //课程 -> 后置课程
        unordered_map<int, int> courseneednum;

        for (int i = 0; i < prerequisites.size(); i++)
        {
            coursenext[prerequisites[i][1]].push_back(prerequisites[i][0]);
            courseneednum[prerequisites[i][0]]++;
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (courseneednum[i] == 0)  queue.push(i);
        }

        while (!queue.empty())
        {
            int course = queue.front();
            queue.pop();

            for (int i = 0; i < coursenext[course].size() ; i++)
            {
                courseneednum[coursenext[course][i]]--;
                if (courseneednum[coursenext[course][i]] == 0) queue.push(coursenext[course][i]);
            }
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (courseneednum[i] == 1)  return false;
        }

        return true;
    }
};