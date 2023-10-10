// Given a m x n grid of characters board and a string word, return true if word exists in the grid
// Input: board = [['A','B','C','E'],  word = "ABCCED"
//                 ['S','F','C','S'],
//                 ['A','D','E','E']]
// Output: true

class Program
{
    public static void Main(string[] args)
    {
        char[,] board = {{'A','B','C','E'},
                         {'S','F','C','S'},
                         {'A','D','E','E'}
                        };
        string word = "ABCB";
        Console.WriteLine(WordSearch(board, word));
    }

    static bool WordSearch(char[,] board, string word)
    {
        bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (WordSearch(board, word, i, j, visited, 0)) return true;
            }
        }
        return false;
    }

    static bool WordSearch(char[,] board, string word, int row, int col, bool[,] visited, int pointer)
    {
        if (pointer >= word.Length) return true;
        if (row >= board.GetLength(0) || col >= board.GetLength(1) || row < 0 || col < 0) return false;
        if (board[row, col] != word[pointer]) return false;
        if (visited[row, col]) return false;

        visited[row, col] = true;

        if (WordSearch(board, word, row + 1, col, visited, pointer + 1)) return true;
        if (WordSearch(board, word, row - 1, col, visited, pointer + 1)) return true;
        if (WordSearch(board, word, row, col + 1, visited, pointer + 1)) return true;
        if (WordSearch(board, word, row, col - 1, visited, pointer + 1)) return true;

        visited[row, col] = false;

        return false;
    }
}