using AudioPlayerLib;
using AxWMPLib;
using System.DirectoryServices;
using System.Numerics;
using WMPLib;
using static AudioPlayerLib.AudioPlayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AudioPlayer1
{
    public partial class Form1 : Form
    {
        private AudioPlayer player;
        private List<string> files = new List<string>();

        public Form1()
        {
            InitializeComponent();

            player = new AudioPlayer();

            player.OnTrackChanged += UpdateFilesListBoxSelection;
            player.OnTrackChanged += index => UpdateLabels();
            player.OnPlayStateChanged += HandlePlayStateChanged;

            UpdateLabels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            volumeBar.Value = 25;
            volumeLabel.Text = volumeBar.Value.ToString();
            player.SetVolume(volumeBar.Value);
        }

        private void UpdatePlaylistDisplay()
        {
            filesListBox.Items.Clear();
            foreach (var file in player.GetPlaylist())
            {
                filesListBox.Items.Add(Path.GetFileName(file));
            }
        }

        private void UpdateTrackSelection()
        {
            int currentIndex = player.GetCurrentTrackIndex();
            if (currentIndex >= 0 && currentIndex < filesListBox.Items.Count)
            {
                filesListBox.SelectedIndex = currentIndex;
            }
        }

        private void UpdateLabels()
        {
            int currentIndex = player.GetCurrentTrackIndex();
            List<string> playlist = player.GetPlaylist();

            if (playlist.Count == 0 || currentIndex == -1)
            {
                prevSongLabel.Text = "Предыдущий: Ничего";
                currentSongLabel.Text = "Сейчас играет: Ничего";
                nextSongLabel.Text = "Следующий: Ничего";
                return;
            }

            currentSongLabel.Text = $"Сейчас играет: {playlist[currentIndex]}";

            int previousIndex = (currentIndex - 1 + playlist.Count) % playlist.Count;
            prevSongLabel.Text = $"Предыдущий: {playlist[previousIndex]}";

            int nextIndex = (currentIndex + 1) % playlist.Count;
            nextSongLabel.Text = $"Следующий: {playlist[nextIndex]}";
        }

        private void UpdateProgressBar()
        {
            songBar.Maximum = (int)player.GetDuration();
            songBar.Value = (int)player.GetCurrentPosition();
        }

        private void ResetProgressBar()
        {
            songBar.Value = 0;
            progressBar.Value = 0;
            progressStartLabel.Text = "00:00";
            progressEndLabel.Text = "00:00";
        }

        private void UpdateFilesListBoxSelection(int trackIndex)
        {
            if (trackIndex >= 0 && trackIndex < filesListBox.Items.Count)
            {
                filesListBox.SelectedIndex = trackIndex;
            }
        }

        private void openFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    filesListBox.Items.Add(Path.GetFileName(file));
                    files.Add(file);
                    player.AddToPlaylist(file);
                }
            }
        }

        private void filesListBox_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = filesListBox.SelectedIndex;

            if (selectedIndex >= 0)
            {
                player.SelectTrack(selectedIndex);
                UpdatePlaylistDisplay();
            }
        }
        private void filesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = filesListBox.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < files.Count)
            {
                player.SelectTrack(selectedIndex);
                player.Play();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (files.Count > 0 && filesListBox.SelectedIndex >= 0)
            {
                player.Play();
                UpdateProgressBar();
            }
            else
            {
                MessageBox.Show("Плейлист пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            ResetProgressBar();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            player.Next();
            UpdateTrackSelection();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            player.Previous();
            UpdateTrackSelection();
        }

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            player.SetVolume(volumeBar.Value);
            volumeLabel.Text = volumeBar.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            songBar.Maximum = Convert.ToInt32(player.GetDuration());
            songBar.Value = Convert.ToInt32(player.GetCurrentPosition());

            progressStartLabel.Text = player.GetCurrentPositionString();
            progressEndLabel.Text = player.GetDurationString().ToString();

            progressBar.Maximum = Convert.ToInt32(player.GetDuration());

            if (player.isPlaying())
            {
                progressBar.Value = (int)player.GetCurrentPosition();
            }
        }

        private void HandlePlayStateChanged(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.Playing:
                    timer1.Start();
                    break;
                case PlayerState.Paused:
                    timer1.Stop();
                    break;
                case PlayerState.Stopped:
                    timer1.Stop();
                    ResetProgressBar();
                    break;
            }
        }

        private void songBar_Scroll(object sender, EventArgs e)
        {
            player.SetCurrentPosition(songBar.Value);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = filesListBox.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < files.Count)
            {
                player.RemoveFromPlaylist(selectedIndex);
                files.RemoveAt(selectedIndex);
                filesListBox.Items.RemoveAt(selectedIndex);

                if (filesListBox.Items.Count > 0)
                {
                    filesListBox.SelectedIndex = Math.Min(selectedIndex, filesListBox.Items.Count - 1);
                }
            }
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            if (filesListBox.Items.Count > 1)
            {
                player.Shuffle();

                filesListBox.Items.Clear();
                filesListBox.Items.AddRange(player.GetPlaylist().ToArray());

                if (filesListBox.Items.Count > 0)
                {
                    filesListBox.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Для перемешивания должно быть хотя бы два файла в плейлисте.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
