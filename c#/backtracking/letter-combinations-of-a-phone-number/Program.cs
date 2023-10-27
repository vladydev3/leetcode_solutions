// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
// A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

// Example 1:
// Input: digits = "23"
// Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

// Example 2:
// Input: digits = ""
// Output: []

// Example 3:
// Input: digits = "2"
// Output: ["a","b","c"]

// Constraints:
// 0 <= digits.length <= 4
// digits[i] is a digit in the range ['2', '9'].

public class Solution
{
    public static void Main(string[] args)
    {
        IList<string> result = LetterCombinations("23");
        foreach (string s in result)
        {
            Console.WriteLine(s);
        }
    }
    public static IList<string> LetterCombinations(string digits)
    {
        List<string> result = new();

        Dictionary<char, string> map = new Dictionary<char, string>();
        map.Add('2', "abc");
        map.Add('3', "def");
        map.Add('4', "ghi");
        map.Add('5', "jkl");
        map.Add('6', "mno");
        map.Add('7', "pqrs");
        map.Add('8', "tuv");
        map.Add('9', "wxyz");

        if (digits.Length == 0) return result;

        LetterCombinations(digits, 0, "", result, map);
        return result;
    }
    public static void LetterCombinations(string digits, int index, string current, List<string> result, Dictionary<char, string> map)
    {
        if (current.Length == digits.Length)
        {
            result.Add(current);
            return;
        }
        if (digits.Length == 1)
        {
            foreach (char c in map[digits[0]])
            {
                result.Add(c.ToString());
            }
        }
        else
        {
            foreach (char c in map[digits[index]])
            {
                LetterCombinations(digits, index + 1, current + c, result, map);
            }
        }
    }
}