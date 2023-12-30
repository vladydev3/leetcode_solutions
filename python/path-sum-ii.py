# Definition for a binary tree node.
# Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.

# A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.

from typing import List
from pyparsing import Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def pathSum(self, root: Optional[TreeNode], targetSum: int) -> List[List[int]]:
        if (root == None):
            return []
        if (root.left == None and root.right == None): # leaf node
            if (root.val == targetSum):
                return [[root.val]]
            else:
                return []
            
        toReturn = []
        if (root.left != None):
            leftPaths = self.pathSum(root.left, targetSum - root.val)
            for path in leftPaths:
                toReturn.append([root.val] + path)

        if (root.right != None):
            rightPaths = self.pathSum(root.right, targetSum - root.val)
            for path in rightPaths:
                toReturn.append([root.val] + path)

        return toReturn