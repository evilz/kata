using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Diamond_csharp
{
    public class diamond
    {
        private IEnumerable<char> AllLetters => Enumerable.Range('A', 'Z' - 'A').Select(i => (char)i);

        private static IEnumerable<string> AllLines(string s)
        {
            return s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        private void TestForAllLetters(Action<string,char> assert)
        {
            AllLetters.ForEach(c =>
            {
                var diamond = Diamond.Create(c);
                assert(diamond, c);
            });
        }
        
       
        [Test]
        public void Should_contain_specified_letter_twice_unless_is_A_()
        {
            TestForAllLetters((s, c) =>
            {
                if (c != 'A') // not A
                {
                    Assert.That(s, Has.Exactly(2).EqualTo(c) );
                }
            });
        }
        
        [Test]
        public void Should_contains_first_row_with_only_one_A()
        {
            TestForAllLetters((s, c) =>
            {
                var lines = s.Split(new []{Environment.NewLine},StringSplitOptions.None);
               Assert.That(lines.First(), Has.Exactly(1).EqualTo('A'));
            });

        }

        [Test]
        public void Should_contains_last_row_with_only_one_A()
        {
            TestForAllLetters((s, c) =>
            {
                var lines = s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                Assert.That(lines.Last(), Has.Exactly(1).EqualTo('A'));
            });

        }

        [Test]
        public void Should_contains_row_with_space_or_same_char()
        {
            TestForAllLetters((s, c) =>
            {
                var lines = s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var l in lines.Select(line => line.Replace(" ", string.Empty)))
                {
                    Assert.That(l, Is.All.EqualTo(l.ToCharArray().First()));
                }
            });

        }

        //[Test]
        //public void Should_has_symetric_rows()
        //{
        //    TestForAllLetters((s, c) =>
        //    {
        //        var lines = s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        //        foreach (var l in lines)
        //        {
        //            l = l.TrimStart(' ');
        //            var middle = (int)Math.Round(l.Length/2d,0,MidpointRounding.AwayFromZero) ;
        //            var left = l.Substring(0, middle);
        //            var right = l.Substring(middle - 1);

        //            var reverseRight = new string(right.Reverse().ToArray());
        //            Assert.That(left, Is.EqualTo(reverseRight));
        //        }
        //    });

        //}

        [Test]
        public void Should_have_letter_in_specific_order()
        {
            TestForAllLetters((s, c) =>
            {
                var letters = AllLines(s)
                    .Select(l => l.Replace(" ", string.Empty))
                    .Select(l => l.First())
                    .ToList();

                var except = Enumerable
                    .Range('A', c - '@')
                    .Select(i => (char) i)
                    .ToList();
                
                except.AddRange( Enumerable.Range('A', c - 'A')
                    .Reverse()
                    .Select(i => (char) i));

                Assert.That(letters, Is.EquivalentTo(except));
            });

        }
        
       [Test]
        public void left_char_should_shift_left_from_a_line_to_another_between_top_and_middle()
        {
            TestForAllLetters((s, c) =>
            {
                if (c != 'A')
                {
                    var indexes = AllLines(s)
                        .Select(x => x.IndexOfAny(AllLetters.ToArray()))
                        .ToList();

                    for (int i = 1; i < indexes.Count/2; i++)
                    {
                        Assert.That(indexes[i], Is.EqualTo(indexes[i - 1] - 1));
                    }
                }
            });
        }

        [Test]
        public void Left_char_of_next_line_should_be_on_right_of_previous_one_from_middle_to_end()
        {
            TestForAllLetters((s, c) =>
            {
                if (c != 'A')
                {
                    var indexes = AllLines(s)
                        .Select(x => x.IndexOfAny(AllLetters.ToArray()))
                        .ToList();

                    for (int i = (int)Math.Ceiling(indexes.Count / 2d); i < indexes.Count  ; i++)
                    {
                        Assert.That(indexes[i], Is.EqualTo(indexes[i - 1] + 1));
                    }
                }
            });
        }
        
        [Test]
        public void Right_char_of_next_line_should_be_on_right_of_previous_one_from_start_to_middle()
        {
            TestForAllLetters((s, c) =>
            {
                if (c != 'A')
                {
                    var indexes = AllLines(s)
                        .Select(x => x.LastIndexOfAny(AllLetters.ToArray()))
                        .ToList();

                    for (int i = 1; i < indexes.Count / 2; i++)
                    {
                        Assert.That(indexes[i], Is.EqualTo(indexes[i - 1] + 1));
                    }
                }
            });
        }

        [Test]
        public void Right_char_of_next_line_should_be_on_left_of_previous_one_from_middle_to_end()
        {
            TestForAllLetters((s, c) =>
            {
                if (c != 'A')
                {
                    var indexes = AllLines(s)
                        .Select(x => x.LastIndexOfAny(AllLetters.ToArray()))
                        .ToList();

                    for (int i = (int)Math.Ceiling(indexes.Count / 2d); i < indexes.Count; i++)
                    {
                        Assert.That(indexes[i], Is.EqualTo(indexes[i - 1] - 1));
                    }
                }
            });
        }


    }

    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> items,Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    } 
}
