class Trie:
    def __init__(self):
        self.children = {}
        self.is_word = False
        self.word = None

    def insert(self, word):
        node = self
        for char in word:
            if char not in node.children:
                node.children[char] = Trie()
            node = node.children[char]
        node.is_word = True
        node.word = word

class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        trie = Trie()
        for word in strs:
            trie.insert(word)

        node = trie

        count = 0

        while len(node.children) == 1 and not node.is_word:
            count += 1
            node = list(node.children.values())[0]

        return strs[0][:count] if count > 0 else ""