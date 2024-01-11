using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comet_Importer;
public partial class homeTab : Form
{
    public homeTab()
    {
        InitializeComponent();
    }

    private void homeTab_Load(object sender, EventArgs e)
    {
        // Create a list of integers from 1 to 10
        List<int> values = Enumerable.Range(1, 10).ToList();

        // Clear existing items and bind the list to the ComboBox
        concurrentDownloadNumber.Items.Clear();
        concurrentDownloadNumber.DataSource = values;

        // Load the saved setting "concurrent" from settings
        int defaultConcurrent = Properties.Settings.Default.concurrent;

        // Set the default value from the loaded setting or default to 5 if it's outside the range
        concurrentDownloadNumber.SelectedItem = values.Contains(defaultConcurrent) ? defaultConcurrent : 5;

        // Load the saved folder path from settings
        folderLocation.Text = Properties.Settings.Default.songFolder;

    }

    private void concurrentDownloadNumber_Click(object sender, EventArgs e)
    {
        if (concurrentDownloadNumber.SelectedItem != null)
        {
            // Check if the selected item can be converted to an integer
            if (int.TryParse(concurrentDownloadNumber.SelectedItem.ToString(), out int selectedValue))
            {
                // Check if the selected value is within a valid range (1 to 10 in this case)
                if (selectedValue >= 1 && selectedValue <= 10)
                {
                    // Save the selected value to settings
                    Properties.Settings.Default.concurrent = selectedValue;
                }
                else
                {
                    // Save "5" to the settings if the selected value is out of range
                    Properties.Settings.Default.concurrent = 5;
                }

                // Save the settings
                Properties.Settings.Default.Save();
            }
        }
    }

    private void browseFolder_Click(object sender, EventArgs e)
    {
        using FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        if (folderDialog.ShowDialog() == DialogResult.OK)
        {
            // Set the selected folder path to the TextBox
            folderLocation.Text = folderDialog.SelectedPath;

            // Save the selected folder path to settings
            Properties.Settings.Default.songFolder = folderDialog.SelectedPath;
            Properties.Settings.Default.Save();
        }
    }
}
