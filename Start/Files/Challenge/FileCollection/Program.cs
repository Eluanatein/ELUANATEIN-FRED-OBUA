using System;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Define the directory name where files are stored
        string directoryName = "FileCollection";
        // Define the results file name where the summary will be saved
        string resultsFileName = "results.txt";

        // Create a DirectoryInfo object to access the specified directory
        DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);

        // Initialize counters and variables
        int officeFileCount = 0;
        long totalSize = 0;

        // Enumerate files
        foreach (var file in directoryInfo.GetFiles())
        {
            // Check if the file is an Office file
            if (IsOfficeFile(file.Extension))
            {
                // Update the counters and sizes
                officeFileCount++;
                totalSize += file.Length;
            }
        }

        // Write results to file
        using (StreamWriter writer = new StreamWriter(resultsFileName))
        {
            writer.WriteLine($"Number of Office files: {officeFileCount}");
            writer.WriteLine($"Total size: {totalSize} bytes");
        }
    }

    // Helper function to check if a file is an Office file based on its extension
    public static bool IsOfficeFile(string extension)
    {
        string[] officeExtensions = { ".xlsx", ".docx", ".pptx" };
        return officeExtensions.Contains(extension);
    }
}
