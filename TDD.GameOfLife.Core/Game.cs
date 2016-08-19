using System;
using System.Linq;
using Utils;

namespace TDD.GameOfLife.Core
{
    public class Game
    {
        public Game(Boolean [,] grid)
        {
            if (grid == null)
            {
                throw new ArgumentNullException(nameof(grid));
            }
            else
            {
                Generation = 0;

                Grid = new Boolean[grid.GetLength(0), grid.GetLength(1)];

                Array.Copy(grid, Grid, Grid.Length);
            }
        }

        public Game(Int32 rowCount, Int32 columnCount)
        {
            if (rowCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowCount));
            }
            else if (columnCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnCount));
            }
            else
            {
                Grid = new Boolean[rowCount, columnCount];

                var random = new Random();

                for (var x = 0; x < rowCount; x++)
                {
                    for (var y = 0; y < rowCount; y++)
                    {
                        Grid[x, y] = random.Next(0, 2) != 0;
                    }
                }
            }
        }

        public Boolean GetCellNextGenerationStatus(Int32 cellX, Int32 cellY)
        {
            var isCellAlive = Grid[cellX, cellY];

            var neigbourAliveCellCount = Grid.WalkAround(cellX, cellY).Count(item => item);

            if (isCellAlive)
            {
                return neigbourAliveCellCount.IsBetween(2, 3);

                //// isCellAlive
                //if (neigbourAliveCellCount < 2)
                //{
                //    return false;
                //}
                //else if (neigbourAliveCellCount.IsBetween(2, 3))
                //{
                //    return true;
                //}
                //else if (neigbourAliveCellCount > 3)
                //{
                //    return false;
                //}
            }
            else
            {
                return neigbourAliveCellCount == 3;
            }
        }

        public Int32 NextGeneration()
        {
            for (var x = 0; x < RowCount; x++)
            {
                for (var y = 0; y < ColumnCount; y++)
                {
                    Grid[x, y] = GetCellNextGenerationStatus(x, y);
                }
            }

            Generation++;

            return Generation;
        }

        public Int32 Generation { get; private set; }
        private Boolean[,] Grid { get; }
        public Int32 RowCount => Grid.GetLength(0);
        public Int32 ColumnCount => Grid.GetLength(1);
        public Boolean this[Int32 x, Int32 y] => Grid[x, y];
    }
}