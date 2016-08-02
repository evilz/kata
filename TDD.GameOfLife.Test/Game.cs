using System;

namespace TDD.GameOfLife.Test
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
                this.Generation = 0;

                this.Grid = new Boolean[grid.GetLength(0), grid.GetLength(1)];

                Array.Copy(grid, this.Grid, this.Grid.Length);
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
                this.Grid = new Boolean[rowCount, columnCount];

                var random = new Random();

                for (var x = 0; x < rowCount; x++)
                {
                    for (var y = 0; y < rowCount; y++)
                    {
                        this.Grid[x, y] = random.Next(0, 2) != 0;
                    }
                }
            }
        }

        public Boolean GetCellNextGenerationStatus(Int32 cellX, Int32 cellY)
        {

            // var neigbourAliveCellCount = this.Grid.WalkAround(cellX, cellY).Count();
            return true;
        }

        private Int32 CountAliveCells(Int32 cellX, Int32 cellY)
        {
            var aliveCellCount = 0;

            for (var x = Math.Max(0, cellX - 1); x <= Math.Min(cellX + 1, this.RowCount); x++)
            {
                for (var y = Math.Max(0, cellY - 1); y <= Math.Min(cellY + 1, this.ColumnCount); y++)
                {
                    if ((x != cellX) || (y != cellY))
                    {
                        if (this.Grid[x, y])
                        {
                            aliveCellCount++;
                        }
                    }
                }
            }

            return aliveCellCount;
        }

        public void NextGeneration()
        {
            for (var x = 0; x < this.RowCount; x++)
            {
                for (var y = 0; y < this.ColumnCount; y++)
                {
                    this.Grid[x, y] = this.GetCellNextGenerationStatus(x, y);
                }
            }

            this.Generation++;
        }

        public Int32 Generation { get; private set; }
        private Boolean[,] Grid { get; }
        public Int32 RowCount => this.Grid.GetLength(0);
        public Int32 ColumnCount => this.Grid.GetLength(1);
        public Boolean this[Int32 x, Int32 y] => this.Grid[x, y];
    }
}