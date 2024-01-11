namespace Comet_Importer;

partial class homeTab
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
        folderLocation = new TextBox();
        browseFolder = new Button();
        label2 = new Label();
        label3 = new Label();
        concurrentDownloadNumber = new ComboBox();
        foreverToggle1 = new ReaLTaiizor.Controls.ForeverToggle();
        label4 = new Label();
        label5 = new Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 12F);
        label1.Location = new Point(25, 124);
        label1.Name = "label1";
        label1.Size = new Size(161, 21);
        label1.TabIndex = 3;
        label1.Text = "Your osu! Songs path:";
        // 
        // folderLocation
        // 
        folderLocation.Anchor = AnchorStyles.None;
        folderLocation.Font = new Font("Segoe UI", 12F);
        folderLocation.Location = new Point(228, 124);
        folderLocation.MaxLength = 1000;
        folderLocation.Name = "folderLocation";
        folderLocation.Size = new Size(310, 29);
        folderLocation.TabIndex = 5;
        // 
        // browseFolder
        // 
        browseFolder.Anchor = AnchorStyles.None;
        browseFolder.Location = new Point(543, 124);
        browseFolder.Name = "browseFolder";
        browseFolder.Size = new Size(90, 30);
        browseFolder.TabIndex = 4;
        browseFolder.Text = "Browse";
        browseFolder.UseVisualStyleBackColor = true;
        browseFolder.Click += browseFolder_Click;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.None;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 12F);
        label2.Location = new Point(25, 174);
        label2.Name = "label2";
        label2.Size = new Size(90, 21);
        label2.TabIndex = 3;
        label2.Text = "Dark mode:";
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.None;
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 12F);
        label3.Location = new Point(25, 222);
        label3.Name = "label3";
        label3.Size = new Size(138, 21);
        label3.TabIndex = 3;
        label3.Text = "Parallel Download:";
        // 
        // concurrentDownloadNumber
        // 
        concurrentDownloadNumber.Anchor = AnchorStyles.None;
        concurrentDownloadNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        concurrentDownloadNumber.FormattingEnabled = true;
        concurrentDownloadNumber.Location = new Point(228, 219);
        concurrentDownloadNumber.Name = "concurrentDownloadNumber";
        concurrentDownloadNumber.Size = new Size(90, 29);
        concurrentDownloadNumber.TabIndex = 6;
        concurrentDownloadNumber.Click += concurrentDownloadNumber_Click;
        // 
        // foreverToggle1
        // 
        foreverToggle1.Anchor = AnchorStyles.None;
        foreverToggle1.BackColor = Color.Transparent;
        foreverToggle1.BaseColor = Color.FromArgb(35, 168, 109);
        foreverToggle1.BaseColorRed = Color.FromArgb(220, 85, 96);
        foreverToggle1.BGColor = Color.FromArgb(157, 162, 166);
        foreverToggle1.Checked = false;
        foreverToggle1.Font = new Font("Segoe UI", 10F);
        foreverToggle1.Location = new Point(228, 170);
        foreverToggle1.Name = "foreverToggle1";
        foreverToggle1.Options = ReaLTaiizor.Controls.ForeverToggle._Options.Style1;
        foreverToggle1.Size = new Size(76, 33);
        foreverToggle1.TabIndex = 7;
        foreverToggle1.Text = "foreverToggle1";
        foreverToggle1.TextColor = Color.FromArgb(243, 243, 243);
        foreverToggle1.ToggleColor = Color.FromArgb(45, 47, 49);
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.None;
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label4.Location = new Point(151, 9);
        label4.Name = "label4";
        label4.Size = new Size(375, 37);
        label4.TabIndex = 3;
        label4.Text = "Welcome to Comet Importer!";
        // 
        // label5
        // 
        label5.Anchor = AnchorStyles.None;
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI", 12F);
        label5.Location = new Point(108, 55);
        label5.Name = "label5";
        label5.Size = new Size(463, 21);
        label5.TabIndex = 3;
        label5.Text = "To start using this app, please select your osu! Songs folder below";
        // 
        // homeTab
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(670, 330);
        Controls.Add(foreverToggle1);
        Controls.Add(concurrentDownloadNumber);
        Controls.Add(folderLocation);
        Controls.Add(browseFolder);
        Controls.Add(label2);
        Controls.Add(label3);
        Controls.Add(label4);
        Controls.Add(label5);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.None;
        Name = "homeTab";
        Text = "homeTab";
        Load += homeTab_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox folderLocation;
    private Button browseFolder;
    private Label label2;
    private Label label3;
    private ComboBox concurrentDownloadNumber;
    private ReaLTaiizor.Controls.ForeverToggle foreverToggle1;
    private Label label4;
    private Label label5;
}