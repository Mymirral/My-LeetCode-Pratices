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

	int res = 0;

	int pathSum(TreeNode* root, int targetSum) {
		unordered_map<int, int> premap;
		premap[0]++;
		nodeSum(root,targetSum, 0, premap);

		return res;
	}

	void nodeSum(TreeNode* node, int k,long long sum,unordered_map<int,int>& premap)
	{
		if (!node) return;

		sum += node->val;
		
		res += premap[sum - k];
		premap[sum]++;

		nodeSum(node->left, k, sum,premap);
		nodeSum(node->right, k, sum, premap);

		premap[sum]--;
	}
};