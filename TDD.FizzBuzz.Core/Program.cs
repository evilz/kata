﻿// 
// Program.cs
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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TDD.FizzBuzz.Core
{
    public static class Program
    {
        public static IReadOnlyList<string> FizzBuzz()
        {
            const byte itemCount = 100;
            var items = new string[itemCount];

            for (var i = 0; i < 100; i++)
            {
                var number = i + 1;
                items[i] = GetNumberString((byte)number);
            }

            return new ReadOnlyCollection<string>(items);
        }

        public const string Fizz = @"Fizz";
        public const string Buzz = @"Buzz";

        public static string GetNumberString(byte number)
        {
            var stringBuilder = new StringBuilder();

            if (number % 3 == 0)
            {
                stringBuilder.Append(Program.Fizz);
            }

            if (number % 5 == 0)
            {
                stringBuilder.Append(Program.Buzz);
            }

            return stringBuilder.ToString();
        }
    }
}