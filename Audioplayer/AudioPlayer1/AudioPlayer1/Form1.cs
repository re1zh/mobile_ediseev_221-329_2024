using AudioPlayerLib;
using AxWMPLib;
using System.DirectoryServices;
using System.Numerics;
using WMPLib;
using static AudioPlayerLib.AudioPlayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using NAudio.Wave;
using System.Drawing;
using System;

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
            comboBox1.Items.AddRange(new string[] { "0.5", "0.75", "1.0", "1.25", "1.5", "1.75", "2.0" });
            comboBox1.SelectedIndex = 2;
        }

        // Выделение трека в ListBox
        private void UpdateTrackSelection()
        {
            int currentIndex = player.GetCurrentTrackIndex();
            if (currentIndex >= 0 && currentIndex < filesListBox.Items.Count)
            {
                filesListBox.SelectedIndex = currentIndex;
            }
        }

        // Обновление текущего, след. и пред. треков
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

        // Обновление progressBar
        private void UpdateProgressBar()
        {
            songBar.Maximum = (int)player.GetDuration();
            songBar.Value = (int)player.GetCurrentPosition();
        }

        // Очистка progressBar и progressLabel
        private void ResetProgressBar()
        {
            songBar.Value = 0;
            progressBar.Value = 0;
            progressStartLabel.Text = "00:00";
            progressEndLabel.Text = "00:00";
        }

        // Обновление выбранного элемента при смене трека
        private void UpdateFilesListBoxSelection(int trackIndex)
        {
            if (trackIndex >= 0 && trackIndex < filesListBox.Items.Count)
            {
                filesListBox.SelectedIndex = trackIndex;
            }
        }

        // Открытие треков
        private void openFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Выберите аудиофайлы";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    files.Add(file);
                    string duration = player.GetTrackDuration(file);
                    filesListBox.Items.Add($"{Path.GetFileName(file),-30}\t{duration}");
                    player.AddToPlaylist(file);
                }
            }
        }

        // Выбор трека в плейлисте
        private void filesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = filesListBox.SelectedIndex;

            List<string> paths = player.GetPlaylistPaths();

            if (selectedIndex >= 0 && selectedIndex < files.Count)
            {
                string selectedPath = player.GetPlaylistPaths()[selectedIndex];
                player.SelectTrack(selectedIndex);

                DrawWaveform(selectedPath, wavePictureBox);

                player.Play();
            }
        }

        // Проигрывание трека
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

        // Пауза
        private void pauseButton_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        // Стоп
        private void stopButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            ResetProgressBar();
        }

        // Следующий трек
        private void skipButton_Click(object sender, EventArgs e)
        {
            player.Next();
            UpdateTrackSelection();
        }

        // Предыдущий трек
        private void backButton_Click(object sender, EventArgs e)
        {
            player.Previous();
            UpdateTrackSelection();
        }

        // Громкость трека
        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            player.SetVolume(volumeBar.Value);
            volumeLabel.Text = volumeBar.Value.ToString();
        }

        // Таймер для того, чтобы работала перемотка и обновлялся progressBar
        private void timer1_Tick(object sender, EventArgs e)
        {
            songBar.Maximum = Convert.ToInt32(player.GetDuration());
            songBar.Value = Convert.ToInt32(player.GetCurrentPosition());

            progressBar.Maximum = Convert.ToInt32(player.GetDuration());

            progressStartLabel.Text = player.GetCurrentPositionString();
            progressEndLabel.Text = player.GetDurationString().ToString();

            if (player.isPlaying())
            {
                progressBar.Value = songBar.Value;
            }

            //UpdateWaveProgress(wavePictureBox, songBar.Value);
        }

        // Обработчик изменения состояния плеера для работы таймера
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

        // Перемотка трека
        private void songBar_Scroll(object sender, EventArgs e)
        {
            player.SetCurrentPosition(songBar.Value);
            progressBar.Value = songBar.Value;

            //UpdateWaveProgress(wavePictureBox, songBar.Value);
        }

        // Удаление трека из плейлиста
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
            else
            {
                MessageBox.Show("Выберите трек для удаления.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Перемешивание плейлиста
        private void shuffleButton_Click(object sender, EventArgs e)
        {
            if (filesListBox.Items.Count > 1)
            {
                player.Shuffle();

                filesListBox.Items.Clear();
                var playlist = player.GetPlaylist();
                var playlistPaths = player.GetPlaylistPaths();

                for (int i = 0; i < playlist.Count; i++)
                {
                    string duration = player.GetTrackDuration(playlistPaths[i]);
                    filesListBox.Items.Add($"{playlist[i],-30}\t{duration}");
                }


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

        // Перетаскивание мышкой треков в плейлисте
        private int dragIndex = -1;
        private bool isDragging = false;
        private void filesListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void filesListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = filesListBox.PointToClient(new Point(e.X, e.Y));
            int dropIndex = filesListBox.IndexFromPoint(point);

            if (dropIndex < 0) dropIndex = filesListBox.Items.Count - 1;

            if (dragIndex >= 0 && dragIndex != dropIndex)
            {
                var item = filesListBox.Items[dragIndex];
                filesListBox.Items.RemoveAt(dragIndex);
                filesListBox.Items.Insert(dropIndex, item);

                var track = files[dragIndex];
                files.RemoveAt(dragIndex);
                files.Insert(dropIndex, track);

                player.MoveTrack(dragIndex, dropIndex);

                filesListBox.SelectedIndex = dropIndex;
            }
        }
        private void filesListBox_MouseDown(object sender, MouseEventArgs e)
        {
            dragIndex = filesListBox.IndexFromPoint(e.Location);
            isDragging = false;
        }
        private void filesListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragIndex >= 0)
            {
                isDragging = true;
                filesListBox.DoDragDrop(filesListBox.Items[dragIndex], DragDropEffects.Move);
            }
        }
        private void filesListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDragging && dragIndex >= 0)
            {
                filesListBox.SelectedIndex = dragIndex;

                player.SelectTrack(dragIndex);
                player.Play();
            }

            dragIndex = -1;
        }

        // Реализация звуковой дорожки
        private void DrawWaveform(string filePath, PictureBox waveformBox)
        {
            waveformBox.Image = null;
            try
            {
                using var reader = new AudioFileReader(filePath);

                int width = waveformBox.Width;
                int height = waveformBox.Height;

                var samplesPerPixel = (int)(reader.Length / reader.WaveFormat.BlockAlign / width);

                var amplitudes = new List<float>();
                float[] buffer = new float[samplesPerPixel];
                int bytesRead;

                while ((bytesRead = reader.Read(buffer, 0, samplesPerPixel)) > 0)
                {
                    float maxAmplitude = buffer.Take(bytesRead).Max(Math.Abs);
                    amplitudes.Add(maxAmplitude);
                }

                int count = amplitudes.Count;
                float scaleX = (float)width / count;
                float scaleY = height / 2f;

                var bitmap = new Bitmap(width, height);

                using (var g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.White);

                    var pen = new Pen(Color.BlueViolet, 1);

                    for (int x = 0; x < width && x < count; x++)
                    {
                        float amplitude = amplitudes[x];
                        float y = scaleY - (amplitude * scaleY);
                        float y2 = scaleY + (amplitude * scaleY);

                        g.DrawLine(pen, x, y, x, y2);
                    }
                }

                waveformBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отрисовке waveform: {ex.Message}");
            }
        }

        // Сортировка по алфавиту
        private bool isAscendingSort = true;
        private void sortButton_Click(object sender, EventArgs e)
        {
            if (filesListBox.Items.Count > 1)
            {
                player.SortAlphabet(isAscendingSort);

                filesListBox.Items.Clear();
                var playlist = player.GetPlaylist();
                var playlistPaths = player.GetPlaylistPaths();

                for (int i = 0; i < playlist.Count; i++)
                {
                    string duration = player.GetTrackDuration(playlistPaths[i]);
                    filesListBox.Items.Add($"{playlist[i],-30}\t{duration}");
                }

                if (filesListBox.Items.Count > 0)
                {
                    filesListBox.SelectedIndex = 0;
                }

                if (isAscendingSort)
                {
                    isAscendingSort = false;
                }
                else
                {
                    isAscendingSort = true;
                }
            }
            else
            {
                MessageBox.Show("Для сортировки должно быть хотя бы два файла в плейлисте.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Сортировка по длительности трека
        private bool isAscendingDur = true;
        private void sortDurButton_Click(object sender, EventArgs e)
        {
            if (filesListBox.Items.Count > 1)
            {
                player.SortDuration(isAscendingDur);

                filesListBox.Items.Clear();
                var playlist = player.GetPlaylist();
                var playlistPaths = player.GetPlaylistPaths();

                for (int i = 0; i < playlist.Count; i++)
                {
                    string duration = player.GetTrackDuration(playlistPaths[i]);
                    filesListBox.Items.Add($"{playlist[i],-30}\t{duration}");
                }

                if (filesListBox.Items.Count > 0)
                {
                    filesListBox.SelectedIndex = 0;
                }

                if (isAscendingDur)
                {
                    isAscendingDur = false;
                }
                else
                {
                    isAscendingDur = true;
                }
            }
            else
            {
                MessageBox.Show("Для сортировки должно быть хотя бы два файла в плейлисте.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            try
            {
                string selectedValue = comboBox1.SelectedItem.ToString().Trim();
                float speed = float.Parse(selectedValue, System.Globalization.CultureInfo.InvariantCulture);

                player.SetRate(speed);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат скорости воспроизведения.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    player.SavePlaylist(saveFileDialog.FileName);
                    MessageBox.Show("Плейлист успешно сохранен!", 
                        "Сохранение плейлиста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void openPlaylistButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string result = player.LoadPlaylist(openFileDialog.FileName);

                    filesListBox.Items.Clear();

                    var playlist = player.GetPlaylist();
                    var playlistPaths = player.GetPlaylistPaths();
                    for (int i = 0; i < playlist.Count; i++)
                    {
                        string duration = player.GetTrackDuration(playlistPaths[i]);
                        files.Add(playlistPaths[i]);
                        filesListBox.Items.Add($"{playlist[i],-30}\t{duration}");
                    }

                    MessageBox.Show(result,
                        result.StartsWith("Ошибка") ? "Ошибка" : "Успех",
                        MessageBoxButtons.OK,
                        result.StartsWith("Ошибка") ? MessageBoxIcon.Error : MessageBoxIcon.Information);

                    if (filesListBox.Items.Count > 0)
                    {
                        filesListBox.SelectedIndex = 0;

                        string firstFilePath = player.GetPlaylistPaths()[0];
                        DrawWaveform(firstFilePath, wavePictureBox);
                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (filesListBox.Items.Count == 0)
            {
                MessageBox.Show("Плейлист пуст. Нечего экспортировать.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = folderBrowser.SelectedPath;

                    string result = player.ExportPlaylist(destinationPath);

                    MessageBox.Show(result,
                        result.StartsWith("Ошибка") ? "Ошибка" : "Успех",
                        MessageBoxButtons.OK,
                        result.StartsWith("Ошибка") ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                }
            }
        }
    }
}
