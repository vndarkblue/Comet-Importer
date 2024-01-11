using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

public class BeatmapManager
{
    public static void CreateDownloadFolder()
    {
        if (!Directory.Exists("Download"))
        {
            Directory.CreateDirectory("Download");
        }
    }

    public static void CreateExportFolder()
    {
        if (!Directory.Exists("Export"))
        {
            Directory.CreateDirectory("Export");
        }
    }

    public static List<string> GetIdsFromFolder(string folderLocation)
    {
        List<string> idSet = new List<string>();
        try
        {
            string[] subfolders = Directory.GetDirectories(folderLocation);

            foreach (string subfolder in subfolders)
            {
                string folderName = Path.GetFileName(subfolder);
                string numericPrefix = Regex.Match(folderName, @"^\d+").Value;

                if (!string.IsNullOrEmpty(numericPrefix))
                {
                    idSet.Add(numericPrefix);
                }
            }
        }
        catch (Exception)
        {
            // Handle exceptions if needed. Write a log saying can't get ids from Songs folder.
        }
        return idSet;
    }

    private static List<string> GetIdListFromFile(string filePath)
    {
        List<string> idList = new List<string>();

        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Extract number strings using regular expression
            foreach (string line in lines)
            {
                MatchCollection matches = Regex.Matches(line, @"\b\d+\b");

                foreach (Match match in matches)
                {
                    idList.Add(match.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            // Handle the exception as needed
        }

        return idList;
    }

    public static List<string> CreateDownloadList(string folderLocation, string txtFilePath)
    {
        List<string> folderIdList = GetIdsFromFolder(folderLocation);
        List<string> txtIdList = GetIdListFromFile(txtFilePath);
        return RemoveDuplicates(txtIdList, folderIdList);
    }

    private static List<string> RemoveDuplicates(List<string> txtNumbers, List<string> folderNumbers)
    {
        HashSet<string> folderNumbersSet = new HashSet<string>(folderNumbers);
        List<string> uniqueNumbers = txtNumbers.Where(txtNumber => !folderNumbersSet.Contains(txtNumber)).ToList();
        return uniqueNumbers;
    }
    
    public static void AutoTransfer(string destinationFolderPath)
    {
    string downloadFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download");

    try
    {
        // Ensure the "Download" folder exists
        CreateDownloadFolder();

        // Ensure the destination folder exists; create it if necessary
        if (!Directory.Exists(destinationFolderPath))
        {
            Directory.CreateDirectory(destinationFolderPath);
        }

        // Move all files ending with ".osz" from the "Download" folder to the destination folder
        string[] oszFiles = Directory.GetFiles(downloadFolderPath, "*.osz");
        foreach (string oszFile in oszFiles)
        {
            string fileName = Path.GetFileName(oszFile);
            string destinationPath = Path.Combine(destinationFolderPath, fileName);
            File.Move(oszFile, destinationPath);
        }

        Console.WriteLine("AutoTransfer completed successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during AutoTransfer: {ex.Message}");
    }
    } 
}
