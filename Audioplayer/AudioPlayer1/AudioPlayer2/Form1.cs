using AudioPlayerLib;

namespace AudioPlayer2
{
    public partial class Form1 : Form
    {
        private readonly AudioPlayer player = new AudioPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK && ofd.FileName != null)
            {
                string[] newFiles = ofd.SafeFileNames;
                string[] newPaths = ofd.FileNames;

                for (int i = 0; i < newPaths.Length; i++)
                {
                    player.AddToPlaylist(newPaths[i]);
                    listBox.Items.Add(newFiles[i]);
                }
            }
        }
    }
}
