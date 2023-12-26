using System.Net.WebSockets;

class Program{
    static void Main()
    {
        Console.WriteLine(IsPalindrome("awlw", 4));

    }
    static bool IsPalindrome(IEnumerable<char> s, int length)
    {
        Stack<char> chars = new();
        int count = 0;

        foreach (var c in s){
            if (length%2==0)
            {
                if (count <= length / 2)
                {
                    chars.Push(c);
                }
                else if (count > length / 2)
                {
                    if (chars.Pop() != c)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (count < length / 2)
                {
                    chars.Push(c);
                }
                else if (count > length / 2)
                {
                    if (chars.Pop() != c)
                    {
                        return false;
                    }
                }
            }
            count++;
        }
        return true;
    }
}