// 
// GameFixture.cs
// 
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
// 
// Copyright (c) 2016 Ehouarn Perret
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using NUnit.Framework;
using TDD.GameOfLife.Core;

namespace TDD.GameOfLife.Test
{
    [TestFixture]
    public class GameFixture
    {
        private void CheckGameCell(Boolean[,] grid, Int32 cellX, Int32 cellY, Boolean expected)
        {
            var game = new Game(grid);
            var actual = game.GetCellNextGenerationStatus(cellX, cellY);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Should_return_game_next_generation()
        {
            var game = new Game(2, 3);
            var expected = 1;
            var actual = game.NextGeneration();
            Assert.AreEqual(expected, actual);
        }

        // Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        [TestCase]
        public void Should_return_alive_cell_dead_because_of_underpopulation()
        {
            var grid = new[,]
            {
                { false, true, false },
                { false, false, false}
            };

            CheckGameCell(grid, 0, 1, false);
        }

        // Any live cell with more than three live neighbours dies, as if by overcrowding.
        [TestCase]
        public void Should_return_alive_cell_dead_because_of_overcrowding()
        {
            var grid = new[,]
            {
                { true, true, true },
                { true, true, false}
            };

            CheckGameCell(grid, 1, 1, false);
        }

        // Any live cell with two or three live neighbours lives on to the next generation.
        [TestCase]
        public void Should_return_alive_cell_alive_because_of_proper_surrounding()
        {
            var grid = new[,]
            {
                { true, false, true},
                { true, true, false}
            };

            CheckGameCell(grid, 1, 0, true);
        }

        // Any dead cell with exactly three live neighbours becomes a live cell.
        [TestCase]
        public void Should_return_dead_cell_alive_because_of_3_alive_cells_around_it()
        {
            var grid = new[,]
            {
                { true, false, true },
                { true, false, false}
            };

            CheckGameCell(grid, 0, 1, true);
        }
    }
}