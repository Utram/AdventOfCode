namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/7
    internal class Day7 : Day
    {
        public Day7() : base(7)
        {
        }

        protected override void RunLogic(string[] input)
        {
            var root = InitializeDirectory(input);
            var deflatedDirectories = DeflateDirectories(root);

            // Part 1
            var sum = deflatedDirectories.Where(x => x.DirectorySize <= 100000)
                                         .Sum(x => x.DirectorySize);

            Console.WriteLine($"Size of all directories with at most 100000: {sum}");

            // Part 2
            //               48518336
            var totalSpace = 70000000;
            var updateRequiredSpace = 30000000;

            var unusedSpace = totalSpace - root.DirectorySize;
            var requiredSpace = updateRequiredSpace - unusedSpace;

            var smallestPossibleDirectory = deflatedDirectories.Where(x => x.DirectorySize >= requiredSpace)
                                                               .OrderBy(x => x.DirectorySize)
                                                               .First();

            Console.WriteLine($"Size of smallest directory needed to delete: {smallestPossibleDirectory.DirectorySize}");
        }

        private List<AoCDirectory> DeflateDirectories(AoCDirectory directory)
        {
            var list = new List<AoCDirectory>();

            foreach (var subDirectory in directory.SubDirectories)
            {
                list.Add(subDirectory);

                if (subDirectory.SubDirectories.Count > 0)
                {
                    list.AddRange(DeflateDirectories(subDirectory));
                }
            }

            return list;
        }

        // Initializes the directory structure according to the commands of the input
        private AoCDirectory InitializeDirectory(string[] input)
        {
            var root = new AoCDirectory("/");
            var currentDirectory = root;

            for (int i = 1; i < input.Length; i++)
            {
                var commandProperties = input[i].Split(" ");

                // Navigation Command
                if (commandProperties[1] == "cd")
                {
                    if (commandProperties[2] == "..")
                    {
                        currentDirectory = currentDirectory?.ParentDirectory;
                    }
                    else
                    {
                        currentDirectory = currentDirectory?.SubDirectories.Where(x => x.Name == commandProperties[2]).First();
                    }

                    continue;
                }

                // Listing Command
                if (commandProperties[1] == "ls")
                {
                    i += ExtractDirectoryContent(input, i + 1, currentDirectory);
                }
            }

            return root;
        }

        // Detects if the input string is a directory or file and fills the current directory
        // with all elements inside of it.
        private int ExtractDirectoryContent(string[] input, int skip, AoCDirectory currentDirectory)
        {
            var directoryContent = input.Skip(skip)
                                        .TakeWhile(x => x.StartsWith("$ cd") == false)
                                        .ToArray();

            for (int i = skip; i < directoryContent.Length + skip; i++)
            {
                var itemProperties = input[i].Split(' ');

                if (uint.TryParse(itemProperties[0], out uint fileSize))
                {
                    var file = new AoCFile(itemProperties[1], fileSize, currentDirectory);
                    currentDirectory.Files.Add(file);
                }

                if (input[i].StartsWith("dir"))
                {
                    var subdirectory = new AoCDirectory(itemProperties[1], currentDirectory);
                    currentDirectory.SubDirectories.Add(subdirectory);
                }
            }

            return directoryContent.Length;
        }
    }

    class AoCDirectory
    {
        public AoCDirectory? ParentDirectory { get; set; }
        public List<AoCDirectory> SubDirectories { get; set; }
        public List<AoCFile> Files { get; set; }
        public string Name { get; set; }
        public long DirectorySize => Files.Sum(x => x.FileSize) + SubDirectories.Sum(x => x.DirectorySize);

        public AoCDirectory()
        {
            SubDirectories = new List<AoCDirectory>();
            Files = new List<AoCFile>();
            Name = string.Empty;
        }

        public AoCDirectory(string name)
        {
            SubDirectories = new List<AoCDirectory>();
            Files = new List<AoCFile>();
            Name = name;
        }

        public AoCDirectory(string name, AoCDirectory parent)
        {
            ParentDirectory = parent;
            SubDirectories = new List<AoCDirectory>();
            Files = new List<AoCFile>();
            Name = name;
        }
    }

    class AoCFile
    {
        public AoCDirectory ParentDirectory { get; set; }
        public uint FileSize { get; set; }
        public string Name { get; set; }

        public AoCFile(string name, uint size, AoCDirectory parentDirectory)
        {
            FileSize = 0;
            ParentDirectory = parentDirectory;
            Name = name;
            FileSize = size;
        }
    }
}