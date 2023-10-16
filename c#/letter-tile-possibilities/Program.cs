public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(NumTilePossibilities("AAB"));
    }
    public static int NumTilePossibilities(string tiles)
    {
        return NumTilePossibilities(tiles, "", tiles.Length, new HashSet<string>());
    }
    public static int NumTilePossibilities(string tiles, string actual, int n, HashSet<string> count)
    {
        if (actual.Length == n)
        {
            count.Add(actual);
            return 0;
        }
        if (tiles.Length == 0)
        {
            count.Add(actual);
            return 0;
        }

        string old = actual;
        actual += tiles[0];
        char removed = tiles[0];
        tiles = tiles.Remove(0,1);
        NumTilePossibilities(tiles, actual, n, count);
        old += removed;
        NumTilePossibilities(tiles, old, n, count);

        foreach (var item in count)
        {
            Console.Write(item + " ");
        }
        return count.Count;
    }
}