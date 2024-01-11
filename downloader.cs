using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

class Downloader
{
    private static readonly SemaphoreSlim semaphoreSlim = new(1, 1);

    public static async Task DownloadFiles(List<string> ids, int concurrentDownloads, bool autoTransfer)
    {
        string downloadFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download");
        BeatmapManager.CreateDownloadFolder();

        using (HttpClient httpClient = new HttpClient())
        {
            var downloadTasks = ids
                .Select(setId => int.TryParse(setId, out int number)
                    ? DownloadFileAsync(httpClient, number, downloadFolderPath, semaphoreSlim)
                    : Task.CompletedTask)
                .ToList();

            // Limit the number of concurrent downloads using SemaphoreSlim
            var limitedConcurrency = new SemaphoreSlim(concurrentDownloads);

            await Task.WhenAll(downloadTasks);

            if (!autoTransfer)
            {
                DialogResult result = MessageBox.Show("Download complete. Open download folder?", "Open Folder", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", downloadFolderPath);
                }
            }
            else
            {
                // Call your transferBeatmap method here
                // transferBeatmap();
            }
        }
    }

    private static async Task DownloadFileAsync(HttpClient httpClient, int number, string downloadFolderPath, SemaphoreSlim semaphoreSlim)
    {
        await semaphoreSlim.WaitAsync();

        try
        {
            string url = $"https://beatconnect.io/b/{number}";
            string fileName = $"{number}.osz";
            string filePath = Path.Combine(downloadFolderPath, fileName);

            using (var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = File.Create(filePath))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
        finally
        {
            semaphoreSlim.Release();
        }
    }
}
