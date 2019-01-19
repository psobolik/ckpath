namespace ckpath
{
    class Program
    {
        static void Main(string[] args)
        {
            // DumpAllFolders();
            DumpMissingFolders();
            DumpDuplicateFolders();
        }
        private static void DumpAllFolders()
        {
            foreach (var folder in PathChecker.GetAllFolders())
            {
                System.Console.WriteLine(folder);
            }
        }

        private static void WriteHeader(string header)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine(header);
            System.Console.ResetColor();
        }

        private static void DumpMissingFolders()
        {
            WriteHeader("Missing folders in PATH:");
            foreach (var folder in PathChecker.GetMissingFolders())
            {
                System.Console.WriteLine(folder);
            }
        }

        private static void DumpDuplicateFolders()
        {
            WriteHeader("Duplicate folders in PATH:");
            foreach (var folder in PathChecker.GetDuplicateFolders())
            {
                System.Console.WriteLine(folder);
            }
        }
    }
}
