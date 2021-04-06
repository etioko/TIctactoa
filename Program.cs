using System;
using System.Linq;

namespace Tictactoa
{
    class Program
    {

        static int player, countMoves, boarderSize;
        static int[] answerPlayer = new int[2];
        static bool startOver = true;
        static XOBoard board;

        static void Main(string[] args)
        {
            while (startOver == true)
            {
                Console.Clear();
                player = 1;
                countMoves = 0;
                boarderSize = 0;
                Console.WriteLine("Welcome to tictactoa game!\n");
                createBoard();
                Console.WriteLine("Do you want to play again ? [yes|no]");
                string again = Console.ReadLine();
                if (again == "NO" || again == "No" || again == "no")
                    startOver = false;
            }
        }

        private static void createBoard()
        {
            int size = -1;
            while (size <= 1)
            {
                Console.WriteLine("please enter number that will be the board size(numberXnumber)");
                size = checkAnswer(Console.ReadLine()); //return -1 if the answer is wrong

            }
            board = new XOBoard(size);
            boarderSize = size;

            board.Draw();
            Console.WriteLine("Player1:X and Player2:O \n");
            startGame();
        }

        private static void startGame()
        {
            string answer = "";
            Console.WriteLine("Please answer in the following format: N,N");

            if (player % 2 == 0)
            {
                Console.Write("Player 2 Chance: ");
            }
            else
            {
                Console.Write("Player 1 Chance: ");
            }
            bool flag = false;
            while (flag == false)
            {
                Console.WriteLine("In which ROW,COLUMN do you put your answer");
                answer = Console.ReadLine();
                flag = rowColumn(answer); //where to put your char
                if (flag == true && !board.Put(answerPlayer, player))
                {
                    Console.WriteLine("this place is already taken");
                    flag = false;
                }

            }
            board.Draw();
            countMoves++;

            if (countMoves > boarderSize)
            {
                string win = board.Status(countMoves);
                if (win == "NONE")
                {
                    if (player % 2 == 0) player = 1;
                    else
                        player = 2;
                    startGame();
                }
                else
                    Console.WriteLine("#### " + win + "####");

            }
            else
            {

                if (player % 2 == 0) player = 1;
                else
                    player = 2;
                startGame();
            }
        }

        private static bool rowColumn(string answer)
        {
            string[] splits = answer.Split(',');
            if (splits.Length < 2) //check that you entered only two numbers
            {
                return false;
            }
            for (int i = 0; i < splits.Length; i++)
            {
                int num = checkAnswer(splits[i]);
                if (num == -1)
                    return false;
                if (!Enumerable.Range(1, boarderSize).Contains(num))
                    return false;
                else
                    answerPlayer[i] = num;

            }
            return true;
        }

        private static int checkAnswer(string numberStr)
        {
            try
            {
                int num = Int16.Parse(numberStr);
                return num;
            }
            catch (FormatException)
            {
                Console.WriteLine("The format of '{0}' is invalid.", numberStr);
                return -1;

            }
        }
    }
}
