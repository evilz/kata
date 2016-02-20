using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FileSystem_csharp
{
    public class FileSystemTests
    {

        public KataFolder TestFileSystemStructure
        {
            get
            {
                var container = new KataFolder("Root");

                container.Add(new KataFile("a.txt"));
                container.Add(new KataFile("d.txt"));
                container.Add(new KataFile("c.jpg"));

                container.Add(new KataFolder("Sub1"));
                var sub2 = new KataFolder("Sub2");
                container.Add(sub2);
                sub2.Add(new KataFile("dd.txt"));
                sub2.Add(new KataFile("hh.txt"));
                sub2.Add(new KataFile("aa.jpg"));

                container.Add(new KataFolder("Sub3"));


                return container;
            }
        }

        [Test]
        public void Folder_should_have_a_name()
        {
            var folder = new KataFolder("MyFolder");
            Assert.AreEqual("MyFolder", folder.Name);
        }

        [Test]
        public void File_should_have_a_name()
        {
            var file = new KataFile("MyFile");
            Assert.AreEqual("MyFile", file.Name);
        }

        [Test]
        public void Folder_can_be_added_in_folder()
        {
            var container = new KataFolder("Parent");
            var child = new KataFolder("Child");
            container.Add(child);
            var child2 = new KataFolder("Child2");
            container.Add(child2);

            CollectionAssert.AreEquivalent(new List<IFileSystemNode> { child, child2 }, container.Items);

        }

        [Test]
        public void File_can_be_added_in_folder()
        {
            var container = new KataFolder("Parent");
            var child = new KataFile("Child.txt");
            container.Add(child);
            var child2 = new KataFile("Child2.txt");
            container.Add(child2);

            CollectionAssert.AreEquivalent(new List<IFileSystemNode> { child, child2 }, container.Items);

        }

        [Test]
        public void File_Folder_can_be_added_in_folder()
        {
            var container = new KataFolder("Parent");
            var child = new KataFile("Child.txt");
            container.Add(child);
            var child2 = new KataFolder("ChildFolder");
            container.Add(child2);

            CollectionAssert.AreEquivalent(new List<IFileSystemNode> { child, child2 }, container.Items);
        }


        [Test]
        public void GetTree_should_return_root_folder_name_When_it_s_empty()
        {
            var result = new KataFolder("Root").GetTree();
            Assert.AreEqual("Root" + Environment.NewLine, result);
        }

        [Test]
        public void GetTree_should_return_items_names_on_new_line()
        {
           
            var result = TestFileSystemStructure.GetTree();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual(11, lines.Count()); // plus empty line
        }

        [Test]
        public void GetTree_should_return_items_name_preceded_by_tab_for_each_depth()
        {
            
            var result = TestFileSystemStructure.GetTree();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual(1, lines[1].Count(c => c == '\t'));
            Assert.AreEqual(1, lines[2].Count(c => c == '\t'));
        }


        [Test]
        public void GetTree_should_return_items_name_in_alphabetic_order()
        {

            var result = TestFileSystemStructure.GetTree();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var items = new List<string>
            {
                "Root",
                    "Sub1",
                    "Sub2",
                        "aa.jpg",
                        "dd.txt",
                        "hh.txt",
                    "Sub3",
                    "a.txt",
                    "c.jpg",
                    "d.txt",
            };

            for (var i = 0; i < lines.Length - 1; i++)
            {
                StringAssert.Contains(items[i], lines[i]);
            }

        }
    }
}
