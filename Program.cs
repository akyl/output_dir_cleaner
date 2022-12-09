using Utility.CommandLine;

namespace cleaner
{
    public class Program
    {

        private static string[] folderNames = new[] { "bin", "obj" };

        [Argument('h', "Help", "Show all parameters")]
        private static string Help { get; set; }

        [Argument('C', "Clean", "Run clean tool")]
        private static string Clean { get; set; }

        public static void Main()
        {
            Console.WriteLine("Output folders clean tool");
            Arguments.Populate();

            if (Help == null && Clean == null)
            {
                Console.WriteLine("Please, use --Help command to see usage");
                return;
            }

            if (Help != null)
            {
                var helpAttributes = Arguments.GetArgumentInfo(typeof(Program));
                ParametersHelper.ShowHelpAttributes(helpAttributes);
                return;
            }

            if (Clean == null)
            {
                Console.WriteLine("Please, use --Help command to see usage");
                return;
            }

            Console.WriteLine($"Root foldert to clean is  {Clean}");
            CleanFolder(Clean);

            Console.WriteLine("\nCleaning finished. Press Enter to exit");
            Console.ReadLine();
        }

        private static void CleanFolder(string path)
        {
            var directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                if (folderNames.Contains(dir.Split('\\').Last()))
                {
                    Console.WriteLine($"Folder {dir} cleaned");
                    Directory.Delete(dir, true);
                }
                else
                {
                    CleanFolder(dir);
                }
            }
        }
    }
}