public class Program
{
    public static void Main()
    {
        string userName = Environment.UserName;
        WatchDirectory($"C:\\Users\\{userName}");
    }

    private static void WatchDirectory(string directoryPath)
    {
        using (var watcher = new FileSystemWatcher(directoryPath))
        {
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Created += OnFileCreated;
            watcher.Renamed += OnFileRenamed;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Watching for file/folder changes...");
            Console.WriteLine("Press 'q' to quit.");

            while (Console.Read() != 'q') ;
        }
    }

    private static void OnFileCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"File/Folder Added: {e.FullPath}");
        Check(e.FullPath);
    }
    private static void OnFileRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"File/Folder Renamed: {e.FullPath}");
        Check(e.FullPath);
    }

    private static void Check(string filename)
    {
        string name = Path.GetFileName(filename);
        if (name.StartsWith('.') && !File.GetAttributes(filename).HasFlag(FileAttributes.Hidden))
        {
            File.SetAttributes(filename, File.GetAttributes(filename) | FileAttributes.Hidden);
        }
    }
}
