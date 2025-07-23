#include <vector>
#include <queue>
using namespace std; 


struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
    
};

class Solution {
public:
    vector<vector<int>> levelOrder(TreeNode* root) {

        queue<TreeNode*> queue;

        vector<vector<int>> res; 
        vector<int> floor;              //就用这一个来装每一层的数

        queue.push(root);

        //bfs
        while (queue.size() > 0)
        {
            int size = queue.size();

            for (int i = 0; i < size; i++)
            {
                TreeNode* node = queue.front();
                queue.pop();

                if (node)   //当前节点不为空
                {
                    queue.push(node->left);
                    queue.push(node->right);
                    floor.push_back(node->val);
                }
            }

            if(floor.size() > 0) res.push_back(floor);   //把这一层的数添加进去
            floor.clear();  //清空这一层的
        }

        return res;
    }
};