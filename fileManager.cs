using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class fileManager
{
    public static void CreateDownloadFolder()
    {
        if (!Directory.Exists("Download"))
        {
            Directory.CreateDirectory("Download");
        }
    }

    private static void CreateExportFolder()
    {
        if (!Directory.Exists("Export"))
        {
            Directory.CreateDirectory("Export");
        }
    }

    private static List<string> GetIdsFromFolder(string folderLocation)
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
            // Handle exceptions if needed
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

    public static void ExportIdsToTxt(string folderPath, RichTextBox logScreen)
    {
        CreateExportFolder();
        try
        {
            List<string> ids = GetIdsFromFolder(folderPath);
            List<string> sortedIds = ids.OrderBy(id => int.Parse(id)).ToList();
            string exportDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string exportFilename = $"export_{exportDateTime}.txt";
            string exportFilePath = Path.Combine(Application.StartupPath, "Export", exportFilename);
            File.WriteAllLines(exportFilePath, sortedIds);

            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Beatmapset IDs exported to {exportFilename}\n")));
            MessageBox.Show("Export completed successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Error during export: {ex.Message}\n")));
            MessageBox.Show("Export failed. Check the log for details.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
