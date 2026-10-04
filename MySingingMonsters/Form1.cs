namespace MySingingMonsters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += async (_, _) =>
            {
                winBox.Text = "Simulating...";
                winBox.Text = await Task.Run(() => new Wrapper().game());
            };
        }
    }
}
