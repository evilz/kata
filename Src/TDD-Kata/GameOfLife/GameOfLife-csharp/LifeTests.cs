using System.Linq;
using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class LifeTests
    {
        [Test]
        public void GridOf4_8_should_Evolve()
        {

            //........
            //....*...
            //...**...
            //........
            var initGrid = new[,]
            {
             {false, false, false, false, false , false, false, false},
             {false, false, false, false, true  , false, false, false},
             {false, false, false, true , true  , false, false, false},
             {false, false, false, false, false , false, false, false}
          };

            //........
            //...**...
            //...**...
            //........
            var nextGrid = new[,]
            {
             {false, false, false, false, false , false, false, false},
             {false, false, false, true, true  , false, false, false},
             {false, false, false, true , true  , false, false, false},
             {false, false, false, false, false , false, false, false}
          };
            var life = new Life(initGrid);
            life.Evolve();


            Assert.That(life.CurrentGrid, Is.EquivalentTo(nextGrid));
        }

        [Test]
        public void CurrentGrid_SouldBe_InitGrid_When_LifeHasNotEvolve()
        {
            var initGrid = new[,] { { true, true }, { true, true } };

            var life = new Life(initGrid);

            Assert.That(life.CurrentGrid, Is.EquivalentTo(initGrid));
        }

        [Test]
        public void OneCellAlone_Sould_Die_When_Evolve()
        {
            var initGrid = new[,] { { true } };
            var nextGrid = new[,] { { false } };
            var life = new Life(initGrid);

            life.Evolve();

            Assert.That(life.CurrentGrid, Is.EquivalentTo(nextGrid));
        }

        [Test]
        public void LivingCell_Sould_Die_When_HasLessThan2NeighboursAlive()
        {
            var initGrid = new[,] { { false, false, false }, { false, false, false }, { false, false, false } };
            initGrid[1, 1] = true;

            var nextGrid = new[,] { { false, false, false }, { false, false, false }, { false, false, false } };

            var life = new Life(initGrid);

            life.Evolve();

            Assert.That(life.CurrentGrid, Is.EquivalentTo(nextGrid));

        }

        [Test]
        public void LivingCell_Sould_Die_When_HasMoreThan3NeighboursAlive()
        {
            var initGrid = new[,] { { true, true, true }, { true, true, true }, { true, true, true } };
            var nextGrid = new[,] { { true, false, true }, { false, false, false }, { true, false, true } };

            var life = new Life(initGrid);

            life.Evolve();
            Assert.That(life.CurrentGrid, Is.EquivalentTo(nextGrid));

        }

        [Test]
        public void LivingCell_Sould_GoesAlive_When_HasTwoOrThreeNeighboursAlive()
        {
            var initGrid = new[,]
            {
               { false, true , false },
               { true , true , false },
               { false, false, false }
           };
            var nextGrid = new[,]
            {
               { true, true , false },
               { true, true , false },
               { false, false , false }
           };

            var life = new Life(initGrid);

            life.Evolve();
            Assert.That(life.CurrentGrid, Is.EquivalentTo(nextGrid));
        }

        [Test]
        public void DeadCell_Sould_GoesAlive_When_HasThreeNeighboursAlive()
        {
            var initGrid = new[,]
            {
               { false, true , false },
               { true , true , false },
               { false, false, false }
           };
            var nextGrid = new[,]
            {
               { true, true , false },
               { true, true , false },
               { false, false , false }
           };

            var life = new Life(initGrid);

            life.Evolve();
            Assert.That(life.CurrentGrid, Is.EquivalentTo(nextGrid));
        }


        [Test]
        public void Cell_Sould_NotHaveNeighboursAlive()
        {
            var initGrid = new[,] { { false, false, false }, { false, true, false }, { false, false, false } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);

            Assert.That(neighbours.Count(b => b), Is.EqualTo(0));
        }

        [Test]
        public void Cell_Sould_HaveOneNeighboursAlive()
        {
            var initGrid = new[,] { { false, false, false }, { true, true, false }, { false, false, false } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);

            Assert.That(neighbours.Count(b => b), Is.EqualTo(1));
            
        }

        [Test]
        public void Cell_Sould_HaveTwoNeighboursAlive()
        {
            var initGrid = new[,] { { true, false, false }, { true, true, false }, { false, false, false } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);
            Assert.That(neighbours.Count(b => b), Is.EqualTo(2));
        }

        [Test]
        public void Cell_Sould_HaveThreeNeighboursAlive()
        {
            var initGrid = new[,] { { true, true, false }, { true, true, false }, { false, false, false } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);
            Assert.That(neighbours.Count(b => b), Is.EqualTo(3));
        }

        [Test]
        public void Cell_Sould_HaveFourNeighboursAlive()
        {
            var initGrid = new[,] { { true, true, true }, { true, true, false }, { false, false, false } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);
            Assert.That(neighbours.Count(b => b), Is.EqualTo(4));
        }

        [Test]
        public void Cell_Sould_HaveFiveNeighboursAlive()
        {
            var initGrid = new[,] { { true, true, true }, { true, true, true }, { false, false, false } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);
            Assert.That(neighbours.Count(b => b), Is.EqualTo(5));
        }

        [Test]
        public void Cell_Sould_HaveSixNeighboursAlive()
        {
            var initGrid = new[,] { { true, true, true }, { true, true, true }, { false, false, true } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);
            Assert.That(neighbours.Count(b => b), Is.EqualTo(6));
        }

        [Test]
        public void Cell_Sould_HaveSevenNeighboursAlive()
        {
            var initGrid = new[,] { { true, true, true }, { true, true, true }, { false, true, true } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);
            Assert.That(neighbours.Count(b => b), Is.EqualTo(7));
        }

        [Test]
        public void Cell_Sould_HaveEightNeighboursAlive()
        {
            var initGrid = new[,] { { true, true, true }, { true, true, true }, { true, true, true } };

            var life = new Life(initGrid);

            var neighbours = life.GetNeighboursCells(1, 1);
            Assert.That(neighbours.Count(b => b), Is.EqualTo(8));
        }
    }
}
