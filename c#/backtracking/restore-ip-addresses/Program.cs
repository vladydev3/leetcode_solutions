// A valid IP address consists of exactly four integers separated by single dots. Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.
// For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.
// Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting dots into s. You are not allowed to reorder or remove any digits in s. You may return the valid IP addresses in any order.

// Input: s = "25525511135"
// Output: ["255.255.11.135","255.255.111.35"]

// Input: s = "0000"
// Output: ["0.0.0.0"]

// Input: s = "101023"
// Output: ["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]

public class Solution
{
    public static void Main(string[] args)
    {
        // string s = "25525511135";
        string s = "172162541";
        var result = RestoreIpAddresses(s);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    public static IList<string> RestoreIpAddresses(string s)
    {
        List<string> result = new();
        if (s.Length > 12) return result;
        Solve(s, 3, "", 0, result);
        return result;
    }
    public static void Solve(string s, int dotsRemaining, string actual, int idx, List<string> result)
    {
        if (actual != "")
        {
            string[] compr = actual.Split(".");
            for (int i = 0; i < compr.Length; i++)
            {
                if (compr[i] == "") continue;
                if (compr[i].Length > 1 && compr[i][0] == '0') return;
                if (int.Parse(compr[i]) > 255) return;
            }
            if (compr[^1].Length>0 && idx<s.Length)
                if (s[idx] == '0' && compr[^1][0] == '0') return;
        }
        if (idx == s.Length)
        {
            if (dotsRemaining == 0 && actual[^1] != '.')
            {
                result.Add(actual);
                return;
            }
            return;
        }
        if ((s.Length - idx) / 3 > dotsRemaining + 1) return;
        if ((s.Length - idx) < dotsRemaining) return;
        if (dotsRemaining == 0)
        {
            if (idx == s.Length)
            {
                result.Add(actual);
                return;
            }
            if (s.Length - idx > 3) return;
            if (s.Length - idx > 1 && s[idx] == '0' && actual[^1] == '.') return;
        }
        if (dotsRemaining < 0 && actual[^1] == '.') return;



        actual += s[idx] + ".";
        Solve(s, dotsRemaining - 1, actual, idx + 1, result);
        actual = actual.Remove(actual.Length - 1);
        Solve(s, dotsRemaining, actual, idx + 1, result);
    }
}