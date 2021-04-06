using System;

namespace Tictactoa
{
    class XOBoard
    {
        private int boardSize;


        public int BoardSize
        {
            get { return boardSize; }
            set { boardSize = value; }
        }


        char[,] gameBoard;

        public XOBoard()
        {
        }

        public XOBoard(int size)
        {
            this.BoardSize = size;
            gameBoard = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    gameBoard[i, j] = '-';
                }
            }
        }


        //position = where to put X or O 
        public bool Put(int[] position, int player)
        {
            char x_or_o;
            if (player % 2 == 1)
                x_or_o = 'X';
            else
                x_or_o = '0';
            if (gameBoard[position[0] - 1, position[1] - 1] == '-')
            {
                gameBoard[position[0] - 1, position[1] - 1] = x_or_o;
                return true;
            }
            return false;

        }

        public string Status(int countMoves)
        {
            //check - rows
            int rows = 0, count_same_char;
            char first;
            first = gameBoard[rows, 0];
            if (first != '-')
            {
                while (rows < boardSize)
                {
                    count_same_char = 0;
                    for (int index = 1; index < boardSize; index++)
                    {
                        if (first != gameBoard[rows, index])
                            index = boardSize;
                        else
                            count_same_char++;
                    }
                    if (count_same_char == boardSize - 1)
                        return first + " WIN!! Row: " + (rows + 1);
                    else
                        rows++;
                }
            }
            //check columns:
            int col = 0;
            first = gameBoard[0, col];
            if (first == '-')
            {
                while (col < boardSize)
                {
                    count_same_char = 0;

                    for (int index = 1; index < boardSize; index++)
                    {
                        if (first != gameBoard[index, col])
                            index = boardSize;
                        else
                            count_same_char++;
                    }
                    if (count_same_char == boardSize - 1)
                        return first + " WIN!! coloumn: " + col + 1;
                    else
                        col++;
                }
            }
            //Main diagonal
            first = gameBoard[0, 0];
            if (first != '-')
            {
                count_same_char = 0;
                for (int i = 1; i < boardSize; i++)
                {
                    if (first != gameBoard[i, i])
                        i = boardSize;
                    else
                        count_same_char++;

                }
                if (count_same_char == BoardSize - 1)
                    return first + " WIN!! Main diagonal ";
            }

            //Secondary diagonal
            first = gameBoard[0, boardSize - 1];
            if (first != '-')
            {
                int second = boardSize - 2;
                count_same_char = 0;
                for (int i = 1; i < boardSize; i++)
                {
                    if (first != gameBoard[i, second])
                        i = boardSize;
                    else
                    {
                        second--;
                        count_same_char++;
                    }
                }
                if (count_same_char == BoardSize - 1)
                    return first + " WIN!! Secondary diagonal ";
            }
            if (countMoves == BoardSize * boardSize)
            {
                int countDraw = 0;
                //CHECK IF DRAW:
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        if (gameBoard[i, j] == '-')
                            countDraw++;
                    }
                }
                if (countDraw == 0)
                    return "DRAW!";
            }
                return "NONE";
        }

        public void Draw()
        {
            Console.WriteLine("\n\n");
            for (int i = 0; i < BoardSize; i++)
            {
                Console.Write("|");
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write("     " + gameBoard[i, j]);
                }
                Console.WriteLine("     |");
            }
            Console.WriteLine("\n\n");
        }


    }
}
