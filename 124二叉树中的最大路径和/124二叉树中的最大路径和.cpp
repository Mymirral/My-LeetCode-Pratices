
#include <algorithm>
#include <climits>

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
	int maxVal = INT32_MIN;

    int maxPathSum(TreeNode* root) {
		findMaxSum(root);
		return maxVal;
    }

	int findMaxSum(TreeNode* node)
	{
		if (!node) return 0;

		int leftMax = findMaxSum(node->left);
		int rightMax = findMaxSum(node->right);

		maxVal = std::max(maxVal, leftMax + rightMax + node->val);

		int max = std::max(leftMax, rightMax) + node->val;

		return std::max(0,max);
	}
};