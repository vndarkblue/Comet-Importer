namespace beatmapCS
{
    public partial class BeatmapDownloader : Form
    {
        private int totalDownloads = 0;
        public BeatmapDownloader()
        {
            InitializeComponent();
            concurrentDownloadNumber.SelectedItem = "5";
        }

        private void browseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderLocation.Text = folderDlg.SelectedPath;
            }
        }

        private void browseTextFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog1.Title = "Select a Text File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textFileLocation.Text = openFileDialog1.FileName;
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            string folderPath = folderLocation.Text;

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                MessageBox.Show("Please enter a file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Directory.Exists(folderPath)) // Check if it's a directory, not a file
            {
                MessageBox.Show("The directory path is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fileManager.ExportIdsToTxt(folderPath, logScreen);
            }
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            string folderPath = folderLocation.Text;
            string txtFilePath = textFileLocation.Text;

            // Check if folder location is provided and is a valid directory
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("Please enter a valid folder location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if txt file location is provided and is a valid file
            if (string.IsNullOrWhiteSpace(txtFilePath) || !File.Exists(txtFilePath))
            {
                MessageBox.Show("Please enter a valid txt file location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the number of concurrent downloads from the combo box
            if (!int.TryParse(concurrentDownloadNumber.Text, out int maxConcurrentDownloads))
            {
                MessageBox.Show("Please enter a valid number for concurrent downloads.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Perform tasks if conditions are satisfied
            try
            {
                // Create download list
                List<string> downloadList = fileManager.CreateDownloadList(folderPath, txtFilePath);

                // Set totalDownloads based on the download list
                totalDownloads = downloadList.Count;

                // Update progress bar
                downloadProg.Maximum = totalDownloads;
                downloadProg.Value = 0;
                downloadProg.Step = 1;

                // Create download folder
                fileManager.CreateDownloadFolder();

                // Perform parallel downloads
                await Download.ParallelDownloadAsync(downloadList, maxConcurrentDownloads, logScreen, downloadProg);

                // Any additional tasks or handling after successful downloads
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
