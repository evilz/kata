using System;
using System.Drawing;
using System.Linq;

namespace GameOfLife
{
    // Bad grid readind but work cause only work on neighbour cells count
    public class Life
    {
        private bool[,] _currentGrid;

        private Point _gridSize;

        public Life(bool[,] initGrid)
        {
            _currentGrid = initGrid;
            _gridSize = new Point(_currentGrid.GetLength(0), _currentGrid.GetLength(1));
        }

        public void Evolve()
        {
            var newGrid = (bool[,])_currentGrid.Clone();
            for (int y = 0; y < _gridSize.Y; y++)
            {
                for (int x = 0; x < _gridSize.X; x++)
                {
                    var currentCell = _currentGrid[x, y];
                    bool[] neighboursCells = GetNeighboursCells(x, y);

                    //1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
                    if (currentCell && neighboursCells.Count(b => b) < 2)
                        newGrid[x, y] = false;
                    //2. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    if (currentCell && neighboursCells.Count(b => b) > 3)
                        newGrid[x, y] = false;
                    //3. Any live cell with two or three live neighbours lives on to the next generation.
                    if (currentCell && (neighboursCells.Count(b => b) == 2 || neighboursCells.Count(b => b) == 3))
                        newGrid[x, y] = true;
                    //4. Any dead cell with exactly three live neighbours becomes a live cell.
                    if (!currentCell && neighboursCells.Count(b => b) == 3)
                    {
                        Console.Write(neighboursCells);
                        newGrid[x, y] = true;
                    }
                        
                }
            }
            _currentGrid = newGrid;
        }


        private bool GetLeftCell(int x, int y)
        {
            return x > 0 && _currentGrid[x - 1, y];
        }

        private bool GetLeftTopCell(int x, int y)
        {
            return x > 0 && y > 0 && _currentGrid[x - 1, y - 1];
        }

        private bool GetTopCell(int x, int y)
        {
            return y > 0 && _currentGrid[x, y - 1];
        }

        private bool GetRightTopCell(int x, int y)
        {
            return x + 1 < _gridSize.X && y > 0 && _currentGrid[x + 1, y - 1];
        }

        private bool GetRightCell(int x, int y)
        {
            return x + 1 < _gridSize.X && _currentGrid[x + 1, y];
        }

        private bool GetRightBottomCell(int x, int y)
        {
            return x + 1 < _gridSize.X && y + 1 < _gridSize.Y && _currentGrid[x + 1, y + 1];
        }
        private bool GetBottomCell(int x, int y)
        {
            return y + 1 < _gridSize.Y && _currentGrid[x, y + 1];
        }

        private bool GetLeftBottomCell(int x, int y)
        {
            return x > 0 && y + 1 < _gridSize.Y && _currentGrid[x - 1, y + 1];
        }

        public bool[] GetNeighboursCells(int x, int y)
        {
            var neighboursCells = new bool[8];

            neighboursCells[0] = GetLeftCell(x, y);
            neighboursCells[1] = GetLeftTopCell(x, y);
            neighboursCells[2] = GetTopCell(x, y);
            neighboursCells[3] = GetRightTopCell(x, y);
            neighboursCells[4] = GetRightCell(x, y);
            neighboursCells[5] = GetRightBottomCell(x, y);
            neighboursCells[6] = GetBottomCell(x, y);
            neighboursCells[7] = GetLeftBottomCell(x, y);

            return neighboursCells;
        }

        public bool[,] CurrentGrid
        {
            get { return _currentGrid; }
        }

    }
}
