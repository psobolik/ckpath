using System;

namespace ckpath
{
    public static class StringExt
    {
        public static string StringWithExpandedTilde(this string str)
        {
            return str.StartsWith('~')
                ? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + str.Substring(1)
                : str;
        }
    }
}