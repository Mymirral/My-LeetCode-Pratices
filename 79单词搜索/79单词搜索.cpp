#include <string>
#include <vector>

using namespace std;

class Solution {
public:

    vector<vector<int>> dirs = {
        {1,0},
        {-1,0},
        {0,1},
        {0,-1}
    };

    vector<vector<bool>> used;

    bool res = false;

    bool exist(vector<vector<char>>& board, string word) {
        
        used = vector<vector<bool>>(board.size(), vector<bool>(board[0].size(), false));

        for (int i = 0; i < board.size(); i++)
        {
            for (int j = 0; j < board[0].size(); j++)
            {
                if (board[i][j] == word[0])
                {
                    used[i][j] = true;
                    dfs(board, word, i, j,1);
                    used[i][j] = false;

                    if (res) return res;
                }
            }
        }

        return res;
    }

    void dfs(vector<vector<char>>& board,string& word,int row,int column,int index)
    {
        //找到了就直接返回
        if (res) return;

        //dfs终止条件
        if (index == word.size()) {
            res = true;
            return;
        }

        for (auto& dir : dirs)
        {
            //下一步的位置
            int newR = row + dir[0];
            int newC = column + dir[1];

            //边界判断加判断是否有下一步
            if (newR >= 0 && newR < board.size() &&
                newC >= 0 && newC < board[0].size() &&
                !used[newR][newC] && board[newR][newC] == word[index])
            {
                used[newR][newC] = true;
                dfs(board, word, newR, newC,index+1);
                used[newR][newC] = false;
            }
        }
    }
};