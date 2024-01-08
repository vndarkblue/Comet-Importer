using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Download
{

    private static async Task DownloadBeatmapsetAsync(string setId, HttpClient client, List<string> failedDownloads, RichTextBox logScreen, ProgressBar progressBar)
    {
        string url = $"https://beatconnect.io/b/{setId}";
        string filePath = Path.Combine("Download", $"{setId}.osz");

        try
        {
            using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            using (Stream contentStream = await response.Content.ReadAsStreamAsync())
            {
                response.EnsureSuccessStatusCode();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    int bytesRead;
                    byte[] buffer = new byte[8192];

                    long? contentLength = response.Content.Headers.ContentLength;

                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                    }
                }

                // Invoke for updating logScreen on the UI thread
                // Increment the number of completed downloads
                progressBar.Invoke((MethodInvoker)(() => progressBar.PerformStep()));
                logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Finished downloading beatmapsetID {setId}\n")));
            }
        }
        catch (Exception e)
        {
            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText($"Error in download: {e}")));
            failedDownloads.Add(setId);
        }
    }

    public static async Task ParallelDownloadAsync(List<string> idList, int maxConcurrentDownloads, RichTextBox logScreen, ProgressBar progressBar)
    {
        List<string> failedDownloads = new List<string>();
        List<Task> downloadTasks = new List<Task>();

        using (HttpClient client = new HttpClient())
        {
            // Limit the number of concurrent downloads
            SemaphoreSlim semaphore = new SemaphoreSlim(maxConcurrentDownloads);

            foreach (string number in idList)
            {
                // Wait until a slot is available in the semaphore
                await semaphore.WaitAsync();

                downloadTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        await DownloadBeatmapsetAsync(number, client, failedDownloads, logScreen, progressBar);
                    }
                    finally
                    {
                        // Release the semaphore slot
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(downloadTasks);
        }

        // Handle failed downloads or show completion message
        if (failedDownloads.Count > 0)
        {
            MessageBox.Show("Some downloads failed. Check the console for details.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText("List of numbers whose download failed:")));
            logScreen.Invoke((MethodInvoker)(() => logScreen.AppendText(string.Join(", ", failedDownloads))));
        }
        else
        {
            MessageBox.Show("All downloads completed successfully!", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
