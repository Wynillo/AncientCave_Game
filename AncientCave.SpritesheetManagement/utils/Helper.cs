namespace SpritesheetManagement.utils;

public static class Helper
{
    public static bool CanAccessFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File {filePath} does not exist.");
            return false;
        }

        try
        {
            // Perform a test read for checking permission issues
            using (File.OpenRead(filePath)) 
            { 
                // Dispose the stream right after using
                // If you cannot open the file, an exception is thrown 
            }
        }
        catch (Exception)
        {
            Console.WriteLine($"Insufficient permissions to read the file: {filePath}");
            return false;
        }

        return true;
    }

}