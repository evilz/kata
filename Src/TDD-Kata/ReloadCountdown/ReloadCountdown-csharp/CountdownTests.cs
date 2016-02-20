using NUnit.Framework;

namespace ReloadCountdown
{
//When developing the class,think about names. 
//  What names feel most "natural" when testing?
//    Feel free to choose other names than Stopped, Start and Decrease,
//    if those feel awkward when testing the class.

        [TestFixture]
    public class CountdownTests
    {
            private Countdown _countdown;
            

            [SetUp]
            public void Setup()
            {
                _countdown = new Countdown();
            }

            [Test]
            public void CountdownInitialState_Should_be_Stopped_WithZeroCountdownValue()
            {
                Assert.IsTrue(_countdown.Stopped);
                Assert.AreEqual(0,_countdown.CurrentValue);
            }

            [Test]
            public void Stopped_Should_BeFalse_When_CountdownStart()
            {
                _countdown.Start(10);
                Assert.IsFalse(_countdown.Stopped);
            }

            [Test]
            public void CurrentCountdownValue_Should_BeSet_When_CallStart()
            {
                _countdown.Start(10);
                Assert.AreEqual(10, _countdown.CurrentValue);
            }

            [Test]
            public void CurrentCountdownValue_Should_BeDecrease_When_CallDecrease()
            {
                _countdown.Start(10);
                _countdown.Decrease(5);
                Assert.AreEqual(5, _countdown.CurrentValue);

                _countdown.Decrease(2);
                Assert.AreEqual(3, _countdown.CurrentValue);
            }

            [Test]
            public void CurrentCountdownValue_Could_NotBeUnderZero_After_CallDecrease()
            {
                _countdown.Start(10);
                _countdown.Decrease(12);
                Assert.AreEqual(0, _countdown.CurrentValue);
            }

            [Test]
            public void Stopped_Should_BeTrue_When_CurrentCountdownBackToZero()
            {
                _countdown.Start(10);
                _countdown.Decrease(5);
                Assert.IsFalse(_countdown.Stopped);

                _countdown.Decrease(5);
                Assert.IsTrue( _countdown.Stopped);
            }
            
    }
}
