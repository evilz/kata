// 
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TDD.FooBarQix.Core
{
    public static class Program
    {
        public const String Foo = @"Foo";
        public const String Bar = @"Bar";
        public const String Qix = @"Qix";

        public static IReadOnlyList<String> FooBarQix()
        {
            const Byte itemCount = 100;
            var items = new String[itemCount];

            for (var i = 0; i < 100; i++)
            {
                var number = i + 1;
                items[i] = Program.GetNumberString((Byte)number);
            }

            return new ReadOnlyCollection<String>(items);
        }

        public static String GetNumberString(Byte number)
        {
            var numberString = number.ToString();

            var stringBuilder = new StringBuilder();

            if ((number % 3) == 0)
            {
                stringBuilder.Append(Program.Foo);
            }
            if ((number % 5) == 0)
            {
                stringBuilder.Append(Program.Bar);
            }
            if ((number % 7) == 0)
            {
                stringBuilder.Append(Program.Qix);
            }

            foreach (var character in numberString)
            {
                switch (character)
                {
                    case '3': stringBuilder.Append(Program.Foo); break;
                    case '5': stringBuilder.Append(Program.Bar); break;
                    case '7': stringBuilder.Append(Program.Qix); break;
                }
            }

            return stringBuilder.Length > 0 ? stringBuilder.ToString() : numberString;
        }
    }
}