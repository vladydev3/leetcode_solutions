using System.Runtime.ExceptionServices;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] matchsticks = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 102];
        System.Console.WriteLine(Makesquare(matchsticks));
    }
    public static bool Makesquare(int[] matchsticks)
    {
        Array.Sort(matchsticks);
        matchsticks = matchsticks.Reverse().ToArray();
        int sideLength = matchsticks.Sum();
        if (sideLength % 4 != 0) return false;
        sideLength /= 4;
        int firstSide = sideLength;
        int secondSide = sideLength;
        int thirdSide = sideLength;
        int side4thSide = sideLength;

        bool Backtracking(int index, int first, int second, int third, int side4th)
        {
            if (first < 0 || second < 0 || third < 0 || side4th < 0) return false;
            if (index == matchsticks.Length) return first == 0 && second == 0 && third == 0 && side4th == 0;

            bool side1 = false;
            bool side2 = false;
            bool side3 = false;
            bool side4 = false;

            if (first - matchsticks[index] >= 0) side1 = Backtracking(index + 1, first - matchsticks[index], second, third, side4th);
            if (second - matchsticks[index] >= 0) side2 = Backtracking(index + 1, first, second - matchsticks[index], third, side4th);
            if (third - matchsticks[index] >= 0) side3 = Backtracking(index + 1, first, second, third - matchsticks[index], side4th);
            if (side4th - matchsticks[index] >= 0) side4 = Backtracking(index + 1, first, second, third, side4th - matchsticks[index]);

            return side1 || side2 || side3 || side4;
        }

        return Backtracking(0, firstSide, secondSide, thirdSide, side4thSide);
    }
}