namespace TicTacToe
{
    class Program
    {
        public static char[][] field = new char[3][];

        public static int index = 0;
        public static int row = 0;

        public static char mode = 'X';

        public static bool isGameWin = false;

        public static Dictionary<int, bool> isTie = new Dictionary<int, bool>
        {
            { 0, false },
            { 1, false },
            { 2, false }
        };

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "TicTacToe";
            Console.SetWindowSize(20, 15);
            Console.SetBufferSize(20, 15);

            for(int i = 0; i < 3; i++)
                field[i] = new char[] { '-', '-', '-' };
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                    Console.Write(field[i][j]);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write('-');
            Console.ResetColor();

            Console.ResetColor();
            Console.SetCursorPosition(4, 1);
            Console.Write(mode);

            Console.SetCursorPosition(index, row);

            Run();
        }

        public static void Run()
        {
            while(true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                ConsoleKey keyPressed = cki.Key;
                switch(keyPressed)
                {
                    case ConsoleKey.RightArrow:
                        if(!isGameWin)
                        {
                            Console.ResetColor();
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);

                            index = ++index >= 3 ? 0 : index;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);
                            Console.ResetColor();
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if(!isGameWin)
                        {
                            Console.ResetColor();
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);

                            index = --index < 0 ? 2 : index;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);
                            Console.ResetColor();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (!isGameWin)
                        {
                            Console.ResetColor();
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);

                            row = --row < 0 ? 2 : row;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(!isGameWin)
                        {
                            Console.ResetColor();
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);
                            Console.ResetColor();

                            row = ++row >= 3 ? 0 : row;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(index, row);
                            Console.Write(field[row][index]);
                            Console.SetCursorPosition(index, row);
                            Console.ResetColor();
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (field[row][index] == '-')
                        {
                            Console.SetCursorPosition(index, row);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(mode);
                            field[row][index] = mode;

                            if (isWin())
                            {
                                Console.ResetColor();
                                Console.SetCursorPosition(4, 0);
                                Console.Write("Winner is " + mode);
                            }

                            mode = mode == 'X' ? '0' : 'X';

                            Console.ResetColor();
                            Console.SetCursorPosition(4, 1);
                            Console.Write(mode);

                            if (!field[0].Contains('-'))
                                isTie[0] = true;
                            if (!field[1].Contains('-'))
                                isTie[1] = true;
                            if (!field[2].Contains('-'))
                                isTie[2] = true;

                            if (isTie[0] && isTie[1] && isTie[2])
                            {
                                Console.ResetColor();
                                Console.SetCursorPosition(4, 0);
                                Console.Write("Tie");
                                isGameWin = true;
                            }

                            Console.SetCursorPosition(index, row);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.ResetColor();
                        Console.SetCursorPosition(4, 0);
                        for(int i = 0; i < 11; i++) Console.Write(' ');
                        Console.SetCursorPosition(0, 0);
                        for (int i = 0; i < 3; i++)
                            field[i] = new char[] { '-', '-', '-' };
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                                Console.Write(field[i][j]);
                            Console.WriteLine();
                        }
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write('-');
                        
                        mode = 'X';

                        Console.ResetColor();
                        Console.SetCursorPosition(4, 1);
                        Console.Write(mode);

                        Console.SetCursorPosition(0, 0);

                        index = 0;
                        row = 0;
                        isGameWin = false;
                        isTie[0] = false;
                        isTie[1] = false;
                        isTie[2] = false;

                        break;
                }
            }
        }

        public static bool isWin()
        {
            if (
                   (
                       (field[0][0] == mode && field[0][1] == mode && field[0][2] == mode)
                    || (field[1][0] == mode && field[1][1] == mode && field[1][2] == mode)
                    || (field[2][0] == mode && field[0][1] == mode && field[0][2] == mode)
                    )
                || (
                       (field[0][0] == mode && field[1][0] == mode && field[2][0] == mode)
                    || (field[0][1] == mode && field[1][1] == mode && field[2][1] == mode)
                    || (field[0][2] == mode && field[1][2] == mode && field[2][2] == mode)
                    )
                || (
                       (field[0][0] == mode && field[1][1] == mode && field[2][2] == mode)
                    || (field[0][2] == mode && field[1][1] == mode && field[2][0] == mode)
                    )
            )
            {
                isGameWin = true;
                return true;
            }
            return false;
        }
    }
}