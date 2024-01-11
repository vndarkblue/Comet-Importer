using System.Reflection.Emit;

namespace Comet_Importer;

partial class exportTab
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
        label2 = new Label();
        foreverToggle1 = new ReaLTaiizor.Controls.ForeverToggle();
        label3 = new Label();
        exportButton = new ReaLTaiizor.Controls.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 12F);
        label1.Location = new Point(98, 27);
        label1.Name = "label1";
        label1.Size = new Size(277, 21);
        label1.TabIndex = 4;
        label1.Text = "Export your beatmapset IDs to a txt file";
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.None;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 12F);
        label2.Location = new Point(98, 48);
        label2.Name = "label2";
        label2.Size = new Size(390, 21);
        label2.TabIndex = 4;
        label2.Text = "You can also back up your local beatmaps into a zip file";
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
        foreverToggle1.Location = new Point(228, 136);
        foreverToggle1.Name = "foreverToggle1";
        foreverToggle1.Options = ReaLTaiizor.Controls.ForeverToggle._Options.Style1;
        foreverToggle1.Size = new Size(76, 33);
        foreverToggle1.TabIndex = 9;
        foreverToggle1.Text = "foreverToggle1";
        foreverToggle1.TextColor = Color.FromArgb(243, 243, 243);
        foreverToggle1.ToggleColor = Color.FromArgb(45, 47, 49);
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.None;
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 12F);
        label3.Location = new Point(25, 140);
        label3.Name = "label3";
        label3.Size = new Size(162, 21);
        label3.TabIndex = 8;
        label3.Text = "Export local beatmaps";
        // 
        // exportButton
        // 
        exportButton.Anchor = AnchorStyles.None;
        exportButton.BackColor = Color.Transparent;
        exportButton.BorderColor = Color.FromArgb(32, 34, 37);
        exportButton.EnteredBorderColor = Color.FromArgb(42, 42, 130);
        exportButton.EnteredColor = Color.FromArgb(32, 34, 37);
        exportButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        exportButton.Image = null;
        exportButton.ImageAlign = ContentAlignment.MiddleLeft;
        exportButton.InactiveColor = Color.FromArgb(32, 34, 37);
        exportButton.Location = new Point(25, 256);
        exportButton.Name = "exportButton";
        exportButton.PressedBorderColor = Color.FromArgb(61, 77, 92);
        exportButton.PressedColor = Color.FromArgb(42, 42, 130);
        exportButton.Size = new Size(120, 40);
        exportButton.TabIndex = 13;
        exportButton.Text = "Export";
        exportButton.TextAlignment = StringAlignment.Center;
        // 
        // exportTab
        // 
        ClientSize = new Size(670, 330);
        Controls.Add(exportButton);
        Controls.Add(foreverToggle1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.None;
        Name = "exportTab";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label5;
    private Label label1;
    private ReaLTaiizor.Controls.ForeverToggle foreverToggle1;
    private Label label2;
    private ReaLTaiizor.Controls.Button exportButton;
}