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
	bool isValidBST(TreeNode* root) {
		return validate(root, LONG_MAX, LONG_MIN);
	}

	bool validate(TreeNode* root,long max, long min)
	{
		if (!root) return true;

		if (root->val >= max || root->val <= min) return false;

		return validate(root->left, root->val, min) && validate(root->right, max, root->val);
	}
};