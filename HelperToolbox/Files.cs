using System.IO;

namespace HelperToolbox;
public static class Files
{
    public static bool FileNotExists(this string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        return !File.Exists(path);
    }

    public static void DeleteFileIfExists(this string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static bool DirectoryNotExists(this string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        return !Directory.Exists(path);
    }

    public static void CreateDirectoryIfNotExists(this string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (DirectoryNotExists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public static string GetFileName(this string path)
    {
        if (string.IsNullOrEmpty(path)) { return ""; }
        FileInfo file = new(path);
        return file.Name;
    }

    public static string GetDirectoryName(this string path)
    {
        if (string.IsNullOrEmpty(path)) { return ""; }
        FileInfo file = new(path);

        if (file.DirectoryName == null) 
        { 
            throw new ArgumentNullException(nameof(path)); 
        }

        return file.DirectoryName;
    }

    public static bool IsFileLocked(this string path)
    {
        FileInfo file = new(path);
        return file.IsLocked();
    }

    public static bool IsFileNotLocked(this string path)
    {
        FileInfo file = new(path);
        return !file.IsLocked();
    }

    public static bool IsNotLocked(this FileInfo file)
    {
        return !file.IsLocked();
    }

    public static bool IsLocked(this FileInfo file)
    {
        try
        {
            using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Close();
        }
        catch
        {
            return true;
        }
        return false;
    }
}