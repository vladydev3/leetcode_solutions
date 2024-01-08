using System.Collections;

public class Solution
{
    public static void Main(string[] args)
    {
        var grid = new int[5][];
        grid[0] = [1, 0, 7];
        grid[1] = [2, 0, 6];
        grid[2] = [3, 4, 5];
        grid[3] = [0, 3, 0];
        grid[4] = [9, 0, 20];

        System.Console.WriteLine(GetMaximumGold(grid));
    }

    public static int GetMaximumGold(int[][] grid)
    {
        int maxSum = int.MinValue;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 0) continue;
                List<int> path = [];
                int sum = DFS(i, j, path, new bool[grid.Length, grid[0].Length]);
                if (sum > maxSum) maxSum = sum;
            }
        }

        int DFS(int i, int j, List<int> currPath, bool[,] mask)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] == 0 || mask[i, j])
            {
                return currPath.Sum();
            }

            currPath.Add(grid[i][j]);
            mask[i, j] = true;

            int down = DFS(i + 1, j, currPath, mask);
            int top = DFS(i - 1, j, currPath, mask);
            int left = DFS(i, j - 1, currPath, mask);
            int right = DFS(i, j + 1, currPath, mask);

            currPath.RemoveAt(currPath.Count - 1);
            mask[i, j] = false;

            return Math.Max(Math.Max(top, down), Math.Max(left, right));
        }

        if (maxSum == int.MinValue) return 0;
        return maxSum;
    }
}