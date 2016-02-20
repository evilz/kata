namespace FileSystem_csharp
{
    public class KataFile : IFileSystemNode
    {
        public KataFile(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}