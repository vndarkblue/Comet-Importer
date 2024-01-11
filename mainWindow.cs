namespace Comet_Importer;

public partial class mainWindow : Form
{
    private Button activeButton;
    public mainWindow()
    {
        InitializeComponent();
        activeButton = homeButton;
        SetButtonColor(homeButton);
        loadForm(new homeTab());
    }

    private void SetButtonColor(Button clickedButton)
    {
        // Reset the background color for the previously active button
        if (activeButton != null)
        {
            activeButton.BackColor = Color.FromArgb(57, 134, 172);
        }

        // Set the background color for the clicked button
        clickedButton.BackColor = Color.FromArgb(163, 207, 246);

        // Update the active button
        activeButton = clickedButton;
    }

    public void loadForm(object Form)
    {
        if (this.mainPanel.Controls.Count > 0)
            this.mainPanel.Controls.RemoveAt(0);
        Form f = Form as Form;
        f.TopLevel = false;
        f.Dock = DockStyle.Fill;
        this.mainPanel.Controls.Add(f);
        this.mainPanel.Tag = f;
        f.Show();
        f.Visible = true;
    }

    private void homeButton_Click(object sender, EventArgs e)
    {
        loadForm (new homeTab());
        SetButtonColor (homeButton);
    }

    private void downloadButton_Click(object sender, EventArgs e)
    {
        loadForm(new downloadTab());
        SetButtonColor (downloadButton);
    }

    private void exportButton_Click(object sender, EventArgs e)
    {
        loadForm(new exportTab());
        SetButtonColor(exportButton);
    }
}
