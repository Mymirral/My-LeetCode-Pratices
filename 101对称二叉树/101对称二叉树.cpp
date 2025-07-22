

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
	bool isSymmetric(TreeNode* root) {
		return isSymmetric(root->left, root->right);
	}

	bool isSymmetric(TreeNode* left, TreeNode* right) {
		
		if (left && !right) return false;
		if (!left && right) return false;
		if (!left || !right) return true;
		bool same = left->val == right->val;
		return same && isSymmetric(left->left,right->right) && isSymmetric(left->right, right->left);
	}
};