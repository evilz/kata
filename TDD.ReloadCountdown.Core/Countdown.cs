// 
// Countdown.cs
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

namespace TDD.ReloadCountdown.Core
{
    public class Countdown
    {
        public Countdown()
        {
            IsStopped = true;
            _secondCount = 0;
        }

        public bool IsStopped { get; private set; }

        private uint _secondCount;

        public void Start(uint seconds)
        {
            if (!IsStopped)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (seconds > 0)
                {
                    _secondCount = seconds;
                    IsStopped = false;
                }
            }
        }

        public void Decrease(uint seconds)
        {
            if (IsStopped)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (_secondCount <= seconds)
                {
                    _secondCount = uint.MinValue;
                    IsStopped = true;
                }
                else
                {
                    _secondCount -= seconds;
                }
            }
        }
    }
}