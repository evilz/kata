using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Minesweeper_csharp
{
    public class Field
    {
        private const int MINE = -1;
        private const int CLEAR = 0;

        private readonly int[,] _innerMatrix;
        private static Func<char, bool> _isMine = c => c == '*';

        public static Field ParseField(TextReader reader)
        {
            var size = reader
                .ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var height = size[0];
            var width = size[1];

            var matrix = ParseMatrix(reader, height, width);

            return new Field(matrix);
        }

        private static int[,] ParseMatrix(TextReader reader, int height, int width)
        {
            var matrix = new int[height, width];

           for (int i = 0; i < height; i++)
            {
                var line = reader
                    .ReadLine()
                    .Select(MapCharToInt)
                    .ToArray();

                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            return matrix;
        }

        public int Height => _innerMatrix.GetLength(0);
        public int Width => _innerMatrix.GetLength(1);

        public static Func<char, bool> IsMine
        {
            get { return _isMine; }
            set { _isMine = value; }
        }

        public bool IsValid => Height > 0 && Width > 0;

        public string GetSolution()
        {
            var outputMatrix = (int[,])_innerMatrix.Clone();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (outputMatrix[i, j] == -1)
                    {
                        outputMatrix = IncNeighboursOf(i, j, outputMatrix);
                    }

                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (outputMatrix[i, j] == -1)
                        sb.Append("*");
                    else
                    {
                        sb.Append(outputMatrix[i, j]);
                    }

                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private Field(int[,] matrix)
        {
            _innerMatrix = matrix;
        }

        private static int MapCharToInt(char c)
        {
            return IsMine(c) ? MINE:CLEAR;
        }
        
        private int[,] IncNeighboursOf(int line, int col, int[,] outputMatrix)
        {
            var point = new Point(col,line);
            GetNeighboursOf(point)
                .Where(IsValidNeighboursInMatrix)
                .Where(IsNotMine)
                .ToList()
                .ForEach(position => outputMatrix[position.Y,position.X]++ );
              
            return outputMatrix;
        }

        private bool IsNotMine(Point position)
        {
            return _innerMatrix[position.Y, position.X] != MINE;
        }

        private bool IsValidNeighboursInMatrix(Point point)
        {
            return point.X >= 0 && point.X < Width && point.Y >= 0 && point.Y < Height;
        }
        
        private IEnumerable<Point> GetNeighboursOf(Point center)
        {
            yield return new Point(center.X - 1, center.Y - 1);
            yield return new Point(center.X - 1, center.Y);
            yield return new Point(center.X - 1, center.Y + 1);
            yield return new Point(center.X, center.Y - 1);
            yield return new Point(center.X, center.Y + 1);
            yield return new Point(center.X+1, center.Y - 1);
            yield return new Point(center.X+1, center.Y);
            yield return new Point(center.X + 1, center.Y + 1);
        }
        
    }
}