using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Matriza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 45);
            Console.CursorVisible = false;
            Matrix matrix = new Matrix(Console.WindowWidth * Console.WindowHeight, Console.WindowWidth, Console.WindowHeight);

            bool isSignFall = true;
            ConsoleKey stopKey = ConsoleKey.E;

            while (isSignFall)
            {
                Console.Clear();

                if (Console.KeyAvailable && stopKey == Console.ReadKey().Key)
                {
                    isSignFall = false;
                }

                matrix.Print();
                matrix.Fall();

                Thread.Sleep(1);
            }
        }
    }

    class MatrixChar
    {
        public int Sign { get; private set; }
        public ConsoleColor ColorSign { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public MatrixChar(int sign, int x, int y, ConsoleColor colorSign)
        {
            Sign = sign;
            X = x;
            Y = y;
            ColorSign = colorSign;
        }

        public void Fall(int height)
        {
            Y++;
            if (Y >= height)
                Y = 0;
        }
    }

    class Matrix
    {
        private MatrixChar[] _signedMatrices;
        private Random _random;

        private ConsoleColor[] _matrixColor;
        private int _width;
        private int _height;
        private int _signedMatriecesCount;

        private int randomNumberColor;

        public Matrix(int signedMatriecesCount, int width, int height)
        {
            _random = new Random();
            _signedMatrices = new MatrixChar[width];
            _signedMatriecesCount = signedMatriecesCount;
            _width = width;
            _height = height;
            _matrixColor = new ConsoleColor[] { ConsoleColor.Green, ConsoleColor.DarkYellow };
            for (int i = 0; i < _signedMatrices.Length; i++)
            {
                randomNumberColor = _random.Next(0, _matrixColor.Length);
                _signedMatrices[i] = new MatrixChar(_random.Next(0, 1 + 1), _random.Next(1, _width), _random.Next(1, _height), _matrixColor[randomNumberColor]);
            }
        }

        public void Print()
        {
            foreach (var item in _signedMatrices)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.ForegroundColor = item.ColorSign;
                Console.Write(item.Sign);
            }
        }

        public void Fall()
        {
            foreach (var item in _signedMatrices)
            {
                item.Fall(_height);
            }
        }
    }
}
