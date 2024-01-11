namespace Comet_Importer;

partial class downloadTab
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        textFileLocation = new TextBox();
        browseTextFile = new Button();
        transferToggle = new ReaLTaiizor.Controls.ForeverToggle();
        label2 = new Label();
        downloadButton = new ReaLTaiizor.Controls.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 12F);
        label1.Location = new Point(25, 89);
        label1.Name = "label1";
        label1.Size = new Size(164, 21);
        label1.TabIndex = 4;
        label1.Text = "Select import file (.txt):";
        // 
        // textFileLocation
        // 
        textFileLocation.Anchor = AnchorStyles.None;
        textFileLocation.Font = new Font("Segoe UI", 12F);
        textFileLocation.Location = new Point(227, 86);
        textFileLocation.MaxLength = 1000;
        textFileLocation.Name = "textFileLocation";
        textFileLocation.Size = new Size(310, 29);
        textFileLocation.TabIndex = 6;
        // 
        // browseTextFile
        // 
        browseTextFile.Anchor = AnchorStyles.None;
        browseTextFile.Location = new Point(542, 85);
        browseTextFile.Name = "browseTextFile";
        browseTextFile.Size = new Size(90, 30);
        browseTextFile.TabIndex = 5;
        browseTextFile.Text = "Browse";
        browseTextFile.UseVisualStyleBackColor = true;
        browseTextFile.Click += browseTextFile_Click;
        // 
        // transferToggle
        // 
        transferToggle.Anchor = AnchorStyles.None;
        transferToggle.BackColor = Color.Transparent;
        transferToggle.BaseColor = Color.FromArgb(35, 168, 109);
        transferToggle.BaseColorRed = Color.FromArgb(220, 85, 96);
        transferToggle.BGColor = Color.FromArgb(190, 190, 190);
        transferToggle.Checked = false;
        transferToggle.Font = new Font("Segoe UI", 10F);
        transferToggle.Location = new Point(227, 139);
        transferToggle.Name = "transferToggle";
        transferToggle.Options = ReaLTaiizor.Controls.ForeverToggle._Options.Style1;
        transferToggle.Size = new Size(76, 33);
        transferToggle.TabIndex = 9;
        transferToggle.Text = "foreverToggle1";
        transferToggle.TextColor = Color.FromArgb(243, 243, 243);
        transferToggle.ToggleColor = Color.FromArgb(45, 47, 49);
        transferToggle.CheckedChanged += transferToggle_CheckedChanged;
        transferToggle.Click += transferToggle_CheckedChanged;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.None;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 12F);
        label2.Location = new Point(25, 146);
        label2.Name = "label2";
        label2.Size = new Size(103, 21);
        label2.TabIndex = 8;
        label2.Text = "Auto Transfer";
        // 
        // downloadButton
        // 
        downloadButton.Anchor = AnchorStyles.None;
        downloadButton.BackColor = Color.Transparent;
        downloadButton.BorderColor = Color.FromArgb(32, 34, 37);
        downloadButton.EnteredBorderColor = Color.FromArgb(42, 42, 130);
        downloadButton.EnteredColor = Color.FromArgb(32, 34, 37);
        downloadButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        downloadButton.Image = null;
        downloadButton.ImageAlign = ContentAlignment.MiddleLeft;
        downloadButton.InactiveColor = Color.FromArgb(32, 34, 37);
        downloadButton.Location = new Point(25, 256);
        downloadButton.Name = "downloadButton";
        downloadButton.PressedBorderColor = Color.FromArgb(61, 77, 92);
        downloadButton.PressedColor = Color.FromArgb(42, 42, 130);
        downloadButton.Size = new Size(120, 40);
        downloadButton.TabIndex = 12;
        downloadButton.Text = "Download";
        downloadButton.TextAlignment = StringAlignment.Center;
        // 
        // downloadTab
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(670, 330);
        Controls.Add(downloadButton);
        Controls.Add(transferToggle);
        Controls.Add(label2);
        Controls.Add(textFileLocation);
        Controls.Add(browseTextFile);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.None;
        Name = "downloadTab";
        Text = "downloadTab";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox textFileLocation;
    private Button browseTextFile;
    private ReaLTaiizor.Controls.ForeverToggle transferToggle;
    private Label label2;
    private ReaLTaiizor.Controls.Button downloadButton;
}