using System;
using System.Collections.Generic;

namespace ckpath
{
    public static class PathChecker
    {
        private static IEnumerable<string> GetPath()
        {
            var path = Environment.GetEnvironmentVariable("PATH");
            if (string.IsNullOrWhiteSpace(path)) yield break;
            var pathParts = path.Split(System.IO.Path.PathSeparator);
            foreach (var pathPart in pathParts)
            {
                yield return pathPart;
            }
        }

        public static IEnumerable<string> GetMissingFolders()
        {
            foreach (var folder in GetPath())
            {
                if (!System.IO.Directory.Exists(folder.StringWithExpandedTilde()))
                {
                    yield return folder;
                }
            }
        }

        public static IEnumerable<string> GetAllFolders()
        {
            foreach (var entry in GetPath())
            {
                yield return entry;
            }
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
        }
    }
}
