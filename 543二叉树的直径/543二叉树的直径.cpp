#include <algorithm>
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
	int maxLen = 0;

	//我这样把长度和深度都单独算了！
	int diameterOfBinaryTree(TreeNode* root) {

		if (!root) return 0;
		floor(root);
		return maxLen;
	}

	//层数
	int floor(TreeNode* root)
	{
		if (!root) return 0;

		int left = floor(root->left);
		int right = floor(root->right);

		maxLen = max(maxLen, left + right);

		return max(left,right) + 1;
	}
};