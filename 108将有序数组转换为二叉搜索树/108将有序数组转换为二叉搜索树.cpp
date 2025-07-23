#include <vector>
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
	TreeNode* sortedArrayToBST(vector<int>& nums) {
		TreeNode* node = new TreeNode;
		node = toBST(nums, 0, nums.size() - 1);
		return node;
	}

	TreeNode* toBST(vector<int>& nums, int left, int right)
	{
		TreeNode* node = new TreeNode;
		int mid = left + (right-left)/2;
		node->val = nums[mid];
		if (mid - 1 >= left)
			node->left = toBST(nums, left, mid - 1);
		if (mid + 1 <= right)
			node->right = toBST(nums, mid + 1, right);
		return node;
	}
};