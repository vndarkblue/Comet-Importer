using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ExportBeatmaps
{
    private static void CreateExportFolder()
    {
        if (!Directory.Exists("Export"))
        {
            Directory.CreateDirectory("Export");
        }
    }

    public static void ExportBeatmapBatch(string folderPath, bool exportLocal, RichTextBox logScreen)
    {
        CreateExportFolder();

        try
        {
            // Export IDs to TXT file
            ExportIdsToTxt(folderPath, logScreen);

            // If exportLocal is true, also export local beatmaps
            if (exportLocal)
            {
                logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText("Creating the zip file for you. Please wait...\n")));

                // Get all folders that do not start with a strict number string
                var nonNumberFolders = Directory.GetDirectories(folderPath)
                    .Where(folder => !StartsWithNumberString(Path.GetFileName(folder)))
                    .ToList();

                // Create a unique zip file name based on the current timestamp
                string zipFileName = $"Export_{DateTime.Now:yyyyMMddHHmmss}.zip";
                string zipFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Export", zipFileName);

                // Compress the selected folders into a zip file
                if (nonNumberFolders.Any())
                {
                    ZipFile.CreateFromDirectory(folderPath, zipFilePath);
                    logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Export local beatmaps completed successfully. Zip file: {zipFilePath}")));
                }
                else
                {
                    logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText("No eligible folders for local export.\n")));
                }
            }

            // Show a message box asking if the user wants to open the "Export" folder
            DialogResult result = MessageBox.Show("Export complete. Open Export folder?", "Open Folder", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer.exe", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Export"));
            }
        }
        catch (Exception ex)
        {
            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Error during export: {ex.Message}\n")));

            if (exportLocal)
            {
                logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText("Exporting local beatmaps failed.\n")));
            }

            MessageBox.Show("Export failed. Check the log for details.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static void ExportIdsToTxt(string folderPath, RichTextBox logScreen)
    {
        try
        {
            List<string> ids = BeatmapManager.GetIdsFromFolder(folderPath);
            List<string> sortedIds = ids.OrderBy(id => int.Parse(id)).ToList();
            string exportDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string exportFilename = $"export_{exportDateTime}.txt";
            string exportFilePath = Path.Combine(Application.StartupPath, "Export", exportFilename);
            File.WriteAllLines(exportFilePath, sortedIds);

            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Beatmapset IDs exported to {exportFilename}\n")));
            DialogResult result = MessageBox.Show("Export complete. Open Export folder?", "Open Folder", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer.exe", Path.Combine(Application.StartupPath, "Export"));
            }
        }
        catch (Exception ex)
        {
            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Error during export: {ex.Message}\n")));
            MessageBox.Show("Export failed. Check the log for details.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static bool StartsWithNumberString(string value)
    {
        int i = 0;

        // Skip leading spaces
        while (i < value.Length && char.IsWhiteSpace(value[i]))
        {
            i++;
        }

        // Check if the remaining characters form a valid integer
        return i < value.Length && char.IsDigit(value[i]);
    }
}