
#include <iostream>

struct TreeNode {
	int val;
	TreeNode* left;
	TreeNode* right;
	TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};


//如果这个节点找得到p，又找得到q，就是最近祖先
//题目保证了两个都有，如果只找到一个，说明另一个在找到那个的子树。

class Solution {
public:
	TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q) {
		if (!root || root == p || root == q) return root;
		//找左边的
		TreeNode* left = lowestCommonAncestor(root->left, p, q);
		//找右边的
		TreeNode* right = lowestCommonAncestor(root->right, p, q);

		if (left && right) return root;
		
		return left ? left : right;
	}
};