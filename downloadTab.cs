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
public partial class downloadTab : Form
{
    public downloadTab()
    {
        InitializeComponent();

        // Load the autoTransfer setting when the form loads
        transferToggle.Checked = Properties.Settings.Default.autoTransfer;
    }

    private void browseTextFile_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        openFileDialog.Title = "Select a Text File";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Get the selected file path
            string selectedFilePath = openFileDialog.FileName;

            // Perform actions with the selected file path (e.g., display it in a TextBox)
            textFileLocation.Text = selectedFilePath;
        }
    }

    private void transferToggle_CheckedChanged(object sender, EventArgs e)
    {
        // Update the autoTransfer setting when the toggle state changes
        Properties.Settings.Default.autoTransfer = transferToggle.Checked;
        Properties.Settings.Default.Save();
    }

    private void transferToggle_Click(object sender, EventArgs e)
    {
        
    }

    private void transferToggle_CheckedChanged(object sender)
    {
        // Update the autoTransfer setting when the toggle state changes
        Properties.Settings.Default.autoTransfer = transferToggle.Checked;
        Properties.Settings.Default.Save();
    }
}
