using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        List<string> res = new List<string>();
        if (s == null) return res;

        HashSet<string> visited = new HashSet<string>();
        Queue<string> queue = new Queue<string>();

        queue.Enqueue(s);
        visited.Add(s);

        bool found = false;

        while(queue.Count != 0) {
            s = queue.Dequeue();

            if (IsValid(s)) {
                res.Add(s);
                found = true;
            }

            if (found) continue;

            for (int i = 0; i < s.Length; i++) {
                if (s[i] != '(' && s[i] != ')') continue;

                string t = s.Substring(0, i) + s.Substring(i + 1);

                if (!visited.Contains(t)) {
                    queue.Enqueue(t);
                    visited.Add(t);
                }
            }
        }

        return res;
    }

    public bool IsValid(string s) {
        int count = 0;
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (c == '(') count++;
            else if (c == ')' && count-- == 0) return false;
        }
        return count == 0;
    }
}