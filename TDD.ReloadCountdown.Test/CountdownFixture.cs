// 
// CountdownFixture.cs
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
using TDD.ReloadCountdown.Core;

namespace TDD.ReloadCountdown.Test
{
    [TestFixture]
    public class CountdownFixture
    {
        private Countdown CheckIsCountdownStopped(bool expected, uint addedSeconds, uint removedSeconds)
        {
            var countdown = GetCountdownAfterAddingAndDecreasingSeconds(addedSeconds, removedSeconds);

            var actual = countdown.IsStopped;
            Assert.AreEqual(expected, actual);

            return countdown;
        }

        private Countdown GetCountdownAfterAddingAndDecreasingSeconds(uint addedSeconds, uint removedSeconds)
        {
            var countdown = new Countdown();
            countdown.Start(addedSeconds);
            countdown.Decrease(removedSeconds);

            return countdown;
        }

        [TestCase(42u, 42u)]
        [TestCase(23u, 67u)]
        public void Should_return_stopped_if_countdown_has_stopped(uint addedSeconds, uint removeSeconds)
        {
            CheckIsCountdownStopped(true, addedSeconds, removeSeconds);
        }

        [TestCase(32u, 12u)]
        [TestCase(57u, 0u)]
        public void Should_not_return_stopped_if_countdown_is_started(uint addedSeconds, uint removeSeconds)
        {
            CheckIsCountdownStopped(false, addedSeconds, removeSeconds);
        }

        [TestCase(2u, 1u)]
        [TestCase(90u, 27u)]
        public void Should_throw_exception_if_start_and_non_stopped(uint addedSeconds, uint removedSeconds)
        {
            var countdown = CheckIsCountdownStopped(false, addedSeconds, removedSeconds);
            Assert.Throws<InvalidOperationException>(() => countdown.Start(addedSeconds));
        }

        [TestCase(2u, 2u)]
        [TestCase(90u, 100u)]
        public void Should_throw_exception_if_decrease_and_already_stopped(uint addedSeconds, uint removedSeconds)
        {
            var countdown = CheckIsCountdownStopped(true, addedSeconds, removedSeconds);
            Assert.Throws<InvalidOperationException>(() => countdown.Decrease(removedSeconds));
        }
    }
}