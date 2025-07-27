#include <vector>
#include <unordered_map>
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

	unordered_map<int, int> inordermap;

    TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
		for (int i = 0; i < inorder.size(); i++)
		{
			inordermap[inorder[i]] = i;
		}
		return build(preorder, 0, preorder.size()-1, 0, inorder.size()-1);
    }

	TreeNode* build(vector<int>& preorder,int pleft,int pright,int ileft,int iright)
	{
		if (ileft > iright) return nullptr;

		TreeNode* node = new TreeNode(preorder[pleft]);
		
		int mid = inordermap[preorder[pleft]];
		int leftCount = mid - ileft;
		int rightCount = iright - mid;

		int Lleft = pleft + 1;
		int Lright = pleft + leftCount;

		int Rleft = Lright + 1;
		int Rright = pright;

		node->left = build(preorder, Lleft, Lright, ileft, mid - 1);
		node->right = build(preorder, Rleft, Rright, mid + 1, iright);

		return node;
	}
};