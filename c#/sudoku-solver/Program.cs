// Write a program to solve a Sudoku puzzle by filling the empty cells.

// A sudoku solution must satisfy all of the following rules:

// Each of the digits 1-9 must occur exactly once in each row.
// Each of the digits 1-9 must occur exactly once in each column.
// Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.

// The '.' character indicates empty cells.

public class Solution
{
    public static void Main(string[] args)
    {
        char[][] sudoku = new char[][]{
            new char []{'5','3','.','.','7','.','.','.','.'},
            new char []{'6','.','.','1','9','5','.','.','.'},
            new char []{'.','9','8','.','.','.','.','6','.'},
            new char []{'8','.','.','.','6','.','.','.','3'},
            new char []{'4','.','.','8','.','3','.','.','1'},
            new char []{'7','.','.','.','2','.','.','.','6'},
            new char []{'.','6','.','.','.','.','2','8','.'},
            new char []{'.','.','.','4','1','9','.','.','5'},
            new char []{'.','.','.','.','8','.','.','7','9'},
        };

        SolveSudoku(sudoku);
    }
    static void PrintBoard(char[][] solution)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(" " + $"{solution[i][j]}" + " ");
            }
            Console.WriteLine("");
        }
    }
    public static void SolveSudoku(char[][] board)
    {
        if (SolveSudoku(board, 0, 0))
        {
            Console.WriteLine($"There is a solution");
            PrintBoard(board);
        }
        else Console.WriteLine($"There is no solution");
    }
    public static bool SolveSudoku(char[][] board, int x, int y)
    {
        if (x == 8 && y == 9) return true;

        if (y == 9)
        {
            x++;
            y = 0;
        }
        
        if (board[x][y] != '.') return SolveSudoku(board, x, y+1);

        for (int i = 1; i < 10; i++)
        {
            if (IsValid(board, x, y, Convert.ToChar(i.ToString())))
            {
                board[x][y] = Convert.ToChar(i.ToString());

                if (SolveSudoku(board, x, y+1)) return true;
            }
            board[x][y] = '.';
        }


        return false;
    }
    static bool IsValid(char[][] board, int row, int col, char num)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == num)
                return false;
        }
        for (int j = 0; j < 9; j++)
        {
            if (board[j][col] == num)
                return false;
        }

        int startRow = row - row % 3, startCol = col - col % 3;

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i + startRow][j + startCol] == num)
                    return false;

        return true;
    }
}