namespace DataContext;

public class NorthwindContextLogger
{
    public static void WriteLine(string message)
    {
        string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "northwindlog.txt");

        StreamWriter textFile = File.AppendText(path);
        textFile.Write(message);
        textFile.Close();
    }
}