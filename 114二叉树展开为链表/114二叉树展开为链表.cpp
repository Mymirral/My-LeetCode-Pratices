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
	void flatten(TreeNode* root) {
		while (root)
		{
			TreeNode* right = root->right;	//记录右边的

			//把左边接到右边，右边原来会断掉，所以上面记录了
			if (root->left)
			{
				root->right = root->left;
				root->left = nullptr;

				//找到原来左节点的最右边
				TreeNode* final = root->right;
				while (final->right)
				{
					final = final->right;
				}

				final->right = right;
			}

			root = root->right;
		}
	}
};