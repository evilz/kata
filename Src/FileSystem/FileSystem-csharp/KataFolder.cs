using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem_csharp
{
    public class KataFolder : IFileSystemNode
    {
        private readonly List<IFileSystemNode> _items;

        public string Name { get; }

        public IEnumerable<IFileSystemNode> Items => _items;

        private IEnumerable<KataFolder> Folders
        {
            get
            {
                return Items
                        .Where(node => node is KataFolder)
                        .OrderBy(node => node.Name)
                        .Cast<KataFolder>();
            }
        }

        private IEnumerable<KataFile> Files
        {
            get
            {
                return Items
                        .Where(node => node is KataFile)
                        .OrderBy(node => node.Name)
                        .Cast<KataFile>();
            }
        }


        public KataFolder(string name)
        {
            Name = name;
            _items = new List<IFileSystemNode>();
        }

        public string GetTree(int currentDepth = 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine(new string('\t', currentDepth) + Name);
            foreach (var folder in Folders)
            {
                sb.Append(folder.GetTree(currentDepth + 1));
            }
            foreach (var file in Files)
            {
                sb.AppendLine(new string('\t', currentDepth + 1) + file.Name);
            }

            return sb.ToString();
        }

        public void Add(IFileSystemNode folder)
        {
            _items.Add(folder);
        }
    }
}