class TrieNode {
  children: Map<string, TrieNode>;
  isEnd: boolean;
  constructor() {
    this.children = new Map();
    this.isEnd = false;
  }
  public insert(word: string): void {
    let node = this as TrieNode;
    for (let i = 0; i < word.length; i++) {
      const ch = word.charAt(i);
      if (!node.children.has(ch)) {
        node.children.set(ch, new TrieNode());
      }
      node = node.children.get(ch) as TrieNode;
    }
    node.isEnd = true;
  }
}

function longestCommonPrefix(strs: string[]): string {
  let T = new TrieNode();

  for (let i = 0; i < strs.length; i++) {
    T.insert(strs[i]);
  }

  let u = T as TrieNode;
  let response = "";

  while (u.children.size === 1 && !u.isEnd) {
    for (const [key, value] of u.children) {
      response += key;
      u = value;
    }
  }

  return response;
}
