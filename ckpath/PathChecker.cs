namespace ckpath
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PathChecker
    {
        public static IEnumerable<string> GetPath()
        {
            var path = Environment.GetEnvironmentVariable("PATH");
            if (!String.IsNullOrWhiteSpace(path))
            {
                var pathParts = path.Split(System.IO.Path.PathSeparator);
                foreach (string pathPart in pathParts)
                {
                    yield return pathPart;
                }
            }
            yield break;
        }

        public static IEnumerable<string> GetMissingFolders()
        {
            foreach (var folder in GetPath())
            {
                if (!System.IO.Directory.Exists(folder))
                {
                    yield return folder;
                }
            }
            yield break;
        }

        public static IEnumerable<string> GetAllFolders()
        {
            foreach (var entry in GetPath())
            {
                yield return entry;
            }
            yield break;
        }

        public static IEnumerable<string> GetDuplicateFolders()
        {
            var uniqueFolders = new List<string>();
            var duplicateFolders = new List<string>();

            foreach (var folder in GetPath())
            {
                if (uniqueFolders.Contains(folder))
                {
                    if (!duplicateFolders.Contains(folder))
                    {
                        duplicateFolders.Add(folder);
                        yield return folder;
                    }
                }
                else
                {
                    uniqueFolders.Add(folder);
                }
            }
            yield break;
        }
    }
}
