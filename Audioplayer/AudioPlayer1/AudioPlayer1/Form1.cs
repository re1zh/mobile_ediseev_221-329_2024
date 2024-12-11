using AudioPlayerLib;
using System.DirectoryServices;

namespace AudioPlayer1
{
    public partial class Form1 : Form
    {
        //private readonly AudioPlayer audioPlayer = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private List<string> paths = new List<string>();
        private List<string> files = new List<string>();

        //private void UpdatePlaylistDisplay()
        //{
        //    filesListBox.Items.Clear();
        //    for (int i = 0; i < audioPlayer.GetPlaylist().Count; i++)
        //    {
        //        string prefix = i == audioPlayer.GetCurrentTrackIndex() ? "-> " : "   ";
        //        filesListBox.Items.Add($"{prefix}{audioPlayer.GetPlaylist()[i]}");
        //    }
        //}

        private void openFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK && ofd.FileName != null)
            {
                string[] newFiles = ofd.SafeFileNames;
                string[] newPaths = ofd.FileNames;

                //Player.AddFiles(newFiles, newPaths);

                for (int i = 0; i < newPaths.Length; i++)
                {
                    //if (!paths.Contains(newPaths[i]))
                    //{

                    //}

                    filesListBox.Items.Add(newFiles[i]);
                    paths.Add(newPaths[i]);
                    files.Add(newFiles[i]);
                }
            }

            //if (ofd.ShowDialog() == DialogResult.OK && ofd.FileNames.Length > 0)
            //{
            //    foreach (var file in ofd.FileNames)
            //    {
            //        audioPlayer.AddToPlaylist(file);
            //    }
            //    UpdatePlaylistDisplay();
            //}

            var startVolume = 50;
            volumeBar.Value = startVolume;
            volumeLabel.Text = volumeBar.Value.ToString();
        }

        //private void filesListBox_DoubleClick(object sender, EventArgs e)
        //{
        //    int selectedIndex = filesListBox.SelectedIndex;
        //    if (selectedIndex >= 0)
        //    {
        //        audioPlayer.SelectTrack(selectedIndex);
        //        UpdatePlaylistDisplay();
        //    }
        //}

        private void filesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = filesListBox.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < paths.Count)
            {
                axWindowsMediaPlayer1.URL = paths[selectedIndex];
            }
            else
            {
                axWindowsMediaPlayer1.URL = null;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //audioPlayer.Play();
            //UpdatePlaylistDisplay();

            if (paths.Count > 0 && filesListBox.SelectedIndex >= 0)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = null;
                MessageBox.Show("Плейлист пуст. Добавьте файлы для воспроизведения."
                    , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (paths.Count > 0 && filesListBox.SelectedIndex >= 0)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = null;
                MessageBox.Show("Плейлист пуст. Добавьте файлы для воспроизведения."
                    , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (paths.Count > 0 && filesListBox.SelectedIndex >= 0)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = null;
                MessageBox.Show("Плейлист пуст. Добавьте файлы для воспроизведения."
                    , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            if (paths.Count > 0 && filesListBox.SelectedIndex >= 0)
            {
                if (filesListBox.SelectedIndex < filesListBox.Items.Count - 1)
                {
                    filesListBox.SelectedIndex = filesListBox.SelectedIndex + 1;
                }
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = null;
                MessageBox.Show("Плейлист пуст. Добавьте файлы для воспроизведения."
                    , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (paths.Count > 0 && filesListBox.SelectedIndex >= 0)
            {
                if (filesListBox.SelectedIndex > 0)
                {
                    filesListBox.SelectedIndex = filesListBox.SelectedIndex - 1;
                }
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = null;
                MessageBox.Show("Плейлист пуст. Добавьте файлы для воспроизведения."
                    , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = volumeBar.Value;

            volumeLabel.Text = volumeBar.Value.ToString();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                progressBar.Value = 0;

                progressStartLabel.Text = "00:00";
                progressEndLabel.Text = "00:00";

                songBar.Value = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            songBar.Maximum = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration);
            songBar.Value = Convert.ToInt32(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);

            progressStartLabel.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            progressEndLabel.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }
        }

        private void songBar_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = songBar.Value;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (paths.Count > 0 && filesListBox.SelectedIndex >= 0)
            {
                int selectedIndex = filesListBox.SelectedIndex;

                if (selectedIndex >= 0 && selectedIndex < filesListBox.Items.Count)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();

                    files.RemoveAt(selectedIndex);
                    paths.RemoveAt(selectedIndex);

                    filesListBox.Items.RemoveAt(selectedIndex);

                    if (filesListBox.Items.Count > 0)
                    {
                        int newIndex = Math.Min(selectedIndex, filesListBox.Items.Count - 1);
                        filesListBox.SelectedIndex = newIndex;

                        axWindowsMediaPlayer1.URL = paths[newIndex];
                    }
                    else
                    {
                        axWindowsMediaPlayer1.URL = null;
                    }
                }
            }
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            if (files.Count > 1)
            {
                Random rand = new Random();

                for (int i = paths.Count - 1; i > 0; i--)
                {
                    int j = rand.Next(i + 1);

                    string tempPath = paths[i];
                    paths[i] = paths[j];
                    paths[j] = tempPath;

                    string tempFile = files[i];
                    files[i] = files[j];
                    files[j] = tempFile;
                }

                filesListBox.Items.Clear();
                filesListBox.Items.AddRange(files.ToArray());

                if (filesListBox.Items.Count > 0)
                {
                    filesListBox.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Для перемешивания должен быть хотя бы один файл в плейлисте.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
