
using System;

class Program
{
    static void Main()
    {
        char[,] matrix = new char[3, 3]
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        char player = 'X';
        int moves = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("XO");
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + matrix[i, j] + " ");

                    if (j < 2)
                        Console.Write("|");
                }

                Console.WriteLine();

                if (i < 2)
                    Console.WriteLine("---+---+---");
            }

            Console.WriteLine();
            Console.WriteLine("Player " + player + ", choose a number (1-9):");

            if (!int.TryParse(Console.ReadLine(), out int number) ||
                number < 1 || number > 9)
            {
                Console.WriteLine("Invalid number!");
                Console.ReadKey();
                continue;
            }

            int row = (number - 1) / 3;
            int col = (number - 1) % 3;

            if (matrix[row, col] == 'X' ||
                matrix[row, col] == 'O')
            {
                Console.WriteLine("This cell is already taken!");
                Console.ReadKey();
                continue;
            }

            matrix[row, col] = player;
            moves++;

            bool win = false;

            for (int i = 0; i < 3; i++)
            {
                if (matrix[i, 0] == player &&
                    matrix[i, 1] == player &&
                    matrix[i, 2] == player)
                    win = true;

                if (matrix[0, i] == player &&
                    matrix[1, i] == player &&
                    matrix[2, i] == player)
                    win = true;
            }

            if (matrix[0, 0] == player &&
                matrix[1, 1] == player &&
                matrix[2, 2] == player)
                win = true;

            if (matrix[0, 2] == player &&
                matrix[1, 1] == player &&
                matrix[2, 0] == player)
                win = true;

            if (win)
            {
                Console.Clear();

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(" " + matrix[i, j] + " ");

                        if (j < 2)
                            Console.Write("|");
                    }

                    Console.WriteLine();

                    if (i < 2)
                        Console.WriteLine("---+---+---");
                }

                Console.WriteLine();
                Console.WriteLine("Player " + player + " WINS!");
                break;
            }

            if (moves == 9)
            {
                Console.WriteLine("Draw!");
                break;
            }

            player = player == 'X' ? 'O' : 'X';
        }

        Console.WriteLine("Game over!");
        Console.ReadKey();
    }
}
