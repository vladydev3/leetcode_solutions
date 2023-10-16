public class Solution
{
    public static void Main(string[] args)
    {
        var res = SolveNQueens(5);

        foreach (var item in res)
        {
            foreach (var i in item)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"----------------------");

        }
    }
    public static IList<IList<string>> SolveNQueens(int n)
    {
        List<string[]> result = new List<string[]>();
        List<string> board = new(n);
        for (int i = 0; i < n; i++)
        {
            string temp = "";
            for (int j = 0; j < n; j++)
            {
                temp += ".";
            }
            board.Add(temp);
        }
        NQueens(board, result, n, 0, 0);
        return result.ToArray();
    }
    static void NQueens(List<string> board, List<string[]> result, int N, int x, int y)
    {
        if (x == N)
        {
            result.Add(board.ToArray());
            return;
        }

        for (int i = 0; i < N; i++)
        {
            if (IsValidBoard(board, N, x, i))
            {
                string temp = "";
                for (int j = 0; j < N; j++)
                {
                    if (j == i) temp += "Q";
                    else temp += ".";
                }

                board[x] = temp;

                NQueens(board, result, N, x + 1, i);

                temp = "";
                for (int j = 0; j < N; j++)
                {
                    temp += ".";
                }
                board[x] = temp;
            }
        }

        return;
    }
    static bool IsValidBoard(List<string> board, int N, int x, int y)
    {
        for (int i = 0; i < N; i++)
        {
            if (i != x)
            {
                if (board[i][y] == 'Q') return false;
            }
        }
        for (int i = x, j = y; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i][j] == 'Q') return false;
        }
        for (int i = x, j = y; i >= 0 && j < N; i--, j++)
        {
            if (board[i][j] == 'Q') return false;
        }
        return true;
    }
}