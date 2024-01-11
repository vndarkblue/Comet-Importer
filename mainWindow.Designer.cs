namespace Comet_Importer;

partial class mainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
        sidebar = new Panel();
        exportButton = new Button();
        homeButton = new Button();
        downloadButton = new Button();
        mainPanel = new Panel();
        downloadProg = new ProgressBar();
        logScreen = new RichTextBox();
        sidebar.SuspendLayout();
        SuspendLayout();
        // 
        // sidebar
        // 
        sidebar.BackColor = Color.FromArgb(112, 142, 169);
        sidebar.Controls.Add(exportButton);
        sidebar.Controls.Add(homeButton);
        sidebar.Controls.Add(downloadButton);
        sidebar.Dock = DockStyle.Left;
        sidebar.Location = new Point(0, 0);
        sidebar.Margin = new Padding(3, 3, 0, 3);
        sidebar.Name = "sidebar";
        sidebar.Size = new Size(200, 601);
        sidebar.TabIndex = 0;
        // 
        // exportButton
        // 
        exportButton.BackColor = Color.FromArgb(57, 134, 172);
        exportButton.FlatAppearance.BorderSize = 0;
        exportButton.FlatStyle = FlatStyle.Flat;
        exportButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        exportButton.ForeColor = Color.White;
        exportButton.Image = (Image)resources.GetObject("exportButton.Image");
        exportButton.ImageAlign = ContentAlignment.MiddleLeft;
        exportButton.Location = new Point(0, 296);
        exportButton.Margin = new Padding(0);
        exportButton.Name = "exportButton";
        exportButton.Size = new Size(200, 60);
        exportButton.TabIndex = 1;
        exportButton.Text = "Export";
        exportButton.UseVisualStyleBackColor = false;
        exportButton.Click += exportButton_Click;
        // 
        // homeButton
        // 
        homeButton.BackColor = Color.FromArgb(57, 134, 172);
        homeButton.FlatAppearance.BorderSize = 0;
        homeButton.FlatStyle = FlatStyle.Flat;
        homeButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        homeButton.ForeColor = Color.White;
        homeButton.Image = (Image)resources.GetObject("homeButton.Image");
        homeButton.ImageAlign = ContentAlignment.MiddleLeft;
        homeButton.Location = new Point(0, 176);
        homeButton.Margin = new Padding(0);
        homeButton.Name = "homeButton";
        homeButton.Size = new Size(200, 60);
        homeButton.TabIndex = 1;
        homeButton.Text = "Home";
        homeButton.UseVisualStyleBackColor = false;
        homeButton.Click += homeButton_Click;
        // 
        // downloadButton
        // 
        downloadButton.BackColor = Color.FromArgb(57, 134, 172);
        downloadButton.FlatAppearance.BorderSize = 0;
        downloadButton.FlatStyle = FlatStyle.Flat;
        downloadButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        downloadButton.ForeColor = Color.White;
        downloadButton.Image = (Image)resources.GetObject("downloadButton.Image");
        downloadButton.ImageAlign = ContentAlignment.MiddleLeft;
        downloadButton.Location = new Point(0, 236);
        downloadButton.Margin = new Padding(0);
        downloadButton.Name = "downloadButton";
        downloadButton.Size = new Size(200, 60);
        downloadButton.TabIndex = 1;
        downloadButton.Text = "Download";
        downloadButton.UseVisualStyleBackColor = false;
        downloadButton.Click += downloadButton_Click;
        // 
        // mainPanel
        // 
        mainPanel.Location = new Point(200, 0);
        mainPanel.Margin = new Padding(0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new Size(684, 338);
        mainPanel.TabIndex = 1;
        // 
        // downloadProg
        // 
        downloadProg.Location = new Point(200, 338);
        downloadProg.Margin = new Padding(0);
        downloadProg.Name = "downloadProg";
        downloadProg.Size = new Size(684, 23);
        downloadProg.TabIndex = 2;
        // 
        // logScreen
        // 
        logScreen.BorderStyle = BorderStyle.FixedSingle;
        logScreen.Location = new Point(200, 361);
        logScreen.Margin = new Padding(0);
        logScreen.Name = "logScreen";
        logScreen.Size = new Size(684, 240);
        logScreen.TabIndex = 3;
        logScreen.Text = "";
        // 
        // mainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 601);
        Controls.Add(logScreen);
        Controls.Add(downloadProg);
        Controls.Add(mainPanel);
        Controls.Add(sidebar);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "mainWindow";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Comet Importer";
        sidebar.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel sidebar;
    private Button homeButton;
    private Button downloadButton;
    private Button exportButton;
    private Panel mainPanel;
    private ProgressBar downloadProg;
    private RichTextBox logScreen;
}
