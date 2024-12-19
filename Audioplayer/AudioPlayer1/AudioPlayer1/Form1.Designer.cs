namespace AudioPlayer1
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            playButton = new Button();
            pauseButton = new Button();
            stopButton = new Button();
            skipButton = new Button();
            backButton = new Button();
            progressBar = new ProgressBar();
            progressStartLabel = new Label();
            progressEndLabel = new Label();
            volumeBar = new TrackBar();
            volumeLabel = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            comboBox1 = new ComboBox();
            wavePictureBox = new PictureBox();
            prevSongLabel = new Label();
            nextSongLabel = new Label();
            currentSongLabel = new Label();
            speedLabel = new Label();
            tabPage2 = new TabPage();
            sortDurButton = new Button();
            sortButton = new Button();
            deleteButton = new Button();
            openFilesButton = new Button();
            filesListBox = new ListBox();
            tabPage3 = new TabPage();
            label1 = new Label();
            labelPerc = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            songBar = new TrackBar();
            shuffleButton = new Button();
            saveButton = new Button();
            openPlaylistButton = new Button();
            exportButton = new Button();
            ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wavePictureBox).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)songBar).BeginInit();
            SuspendLayout();
            // 
            // playButton
            // 
            playButton.BackColor = SystemColors.Window;
            playButton.BackgroundImage = Properties.Resources.play;
            playButton.BackgroundImageLayout = ImageLayout.Stretch;
            playButton.Location = new Point(195, 408);
            playButton.Name = "playButton";
            playButton.Size = new Size(45, 45);
            playButton.TabIndex = 0;
            playButton.UseVisualStyleBackColor = false;
            playButton.Click += playButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.BackColor = SystemColors.Window;
            pauseButton.BackgroundImage = Properties.Resources.pause;
            pauseButton.BackgroundImageLayout = ImageLayout.Stretch;
            pauseButton.Location = new Point(246, 408);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(45, 45);
            pauseButton.TabIndex = 1;
            pauseButton.UseVisualStyleBackColor = false;
            pauseButton.Click += pauseButton_Click;
            // 
            // stopButton
            // 
            stopButton.BackColor = SystemColors.Window;
            stopButton.BackgroundImage = (Image)resources.GetObject("stopButton.BackgroundImage");
            stopButton.BackgroundImageLayout = ImageLayout.Stretch;
            stopButton.Location = new Point(297, 408);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(45, 45);
            stopButton.TabIndex = 2;
            stopButton.UseVisualStyleBackColor = false;
            stopButton.Click += stopButton_Click;
            // 
            // skipButton
            // 
            skipButton.BackColor = SystemColors.Window;
            skipButton.BackgroundImage = (Image)resources.GetObject("skipButton.BackgroundImage");
            skipButton.BackgroundImageLayout = ImageLayout.Stretch;
            skipButton.Location = new Point(361, 408);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(45, 45);
            skipButton.TabIndex = 3;
            skipButton.UseVisualStyleBackColor = false;
            skipButton.Click += skipButton_Click;
            // 
            // backButton
            // 
            backButton.BackColor = SystemColors.Window;
            backButton.BackgroundImage = (Image)resources.GetObject("backButton.BackgroundImage");
            backButton.BackgroundImageLayout = ImageLayout.Stretch;
            backButton.Location = new Point(134, 408);
            backButton.Name = "backButton";
            backButton.Size = new Size(45, 45);
            backButton.TabIndex = 4;
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(13, 390);
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(775, 10);
            progressBar.TabIndex = 5;
            // 
            // progressStartLabel
            // 
            progressStartLabel.AutoSize = true;
            progressStartLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            progressStartLabel.Location = new Point(12, 403);
            progressStartLabel.Name = "progressStartLabel";
            progressStartLabel.Size = new Size(61, 28);
            progressStartLabel.TabIndex = 6;
            progressStartLabel.Text = "00:00";
            // 
            // progressEndLabel
            // 
            progressEndLabel.AutoSize = true;
            progressEndLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            progressEndLabel.Location = new Point(727, 403);
            progressEndLabel.Name = "progressEndLabel";
            progressEndLabel.Size = new Size(61, 28);
            progressEndLabel.TabIndex = 7;
            progressEndLabel.Text = "00:00";
            // 
            // volumeBar
            // 
            volumeBar.Location = new Point(559, 408);
            volumeBar.Maximum = 100;
            volumeBar.Name = "volumeBar";
            volumeBar.Size = new Size(162, 56);
            volumeBar.TabIndex = 8;
            volumeBar.TickStyle = TickStyle.None;
            volumeBar.Scroll += volumeBar_Scroll;
            // 
            // volumeLabel
            // 
            volumeLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            volumeLabel.Location = new Point(615, 431);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(45, 28);
            volumeLabel.TabIndex = 9;
            volumeLabel.Text = "0";
            volumeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 346);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.PaleTurquoise;
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(wavePictureBox);
            tabPage1.Controls.Add(prevSongLabel);
            tabPage1.Controls.Add(nextSongLabel);
            tabPage1.Controls.Add(currentSongLabel);
            tabPage1.Controls.Add(speedLabel);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 313);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Главная";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(671, 25);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(91, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // wavePictureBox
            // 
            wavePictureBox.BackColor = Color.MintCream;
            wavePictureBox.Location = new Point(-3, 232);
            wavePictureBox.Name = "wavePictureBox";
            wavePictureBox.Size = new Size(776, 85);
            wavePictureBox.TabIndex = 3;
            wavePictureBox.TabStop = false;
            // 
            // prevSongLabel
            // 
            prevSongLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            prevSongLabel.Location = new Point(6, 170);
            prevSongLabel.Name = "prevSongLabel";
            prevSongLabel.Size = new Size(489, 55);
            prevSongLabel.TabIndex = 2;
            prevSongLabel.Text = "Предыдущий:";
            prevSongLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nextSongLabel
            // 
            nextSongLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nextSongLabel.Location = new Point(6, 115);
            nextSongLabel.Name = "nextSongLabel";
            nextSongLabel.Size = new Size(489, 55);
            nextSongLabel.TabIndex = 1;
            nextSongLabel.Text = "Следующий:";
            nextSongLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // currentSongLabel
            // 
            currentSongLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            currentSongLabel.ForeColor = Color.Black;
            currentSongLabel.Location = new Point(6, 6);
            currentSongLabel.Name = "currentSongLabel";
            currentSongLabel.Size = new Size(441, 57);
            currentSongLabel.TabIndex = 0;
            currentSongLabel.Text = "Сейчас играет:";
            currentSongLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // speedLabel
            // 
            speedLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            speedLabel.ForeColor = Color.Black;
            speedLabel.Location = new Point(479, 19);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(226, 38);
            speedLabel.TabIndex = 5;
            speedLabel.Text = "Скорость воспроизведения:";
            speedLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.PaleTurquoise;
            tabPage2.Controls.Add(exportButton);
            tabPage2.Controls.Add(openPlaylistButton);
            tabPage2.Controls.Add(saveButton);
            tabPage2.Controls.Add(sortDurButton);
            tabPage2.Controls.Add(sortButton);
            tabPage2.Controls.Add(deleteButton);
            tabPage2.Controls.Add(openFilesButton);
            tabPage2.Controls.Add(filesListBox);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 313);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Плейлист";
            // 
            // sortDurButton
            // 
            sortDurButton.Location = new Point(196, 238);
            sortDurButton.Name = "sortDurButton";
            sortDurButton.Size = new Size(194, 48);
            sortDurButton.TabIndex = 4;
            sortDurButton.Text = "Сортировать по длительности";
            sortDurButton.UseVisualStyleBackColor = true;
            sortDurButton.Click += sortDurButton_Click;
            // 
            // sortButton
            // 
            sortButton.Location = new Point(6, 238);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(194, 48);
            sortButton.TabIndex = 3;
            sortButton.Text = "Сортировать по алфавиту";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.FromArgb(255, 128, 128);
            deleteButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            deleteButton.Location = new Point(580, 6);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(182, 43);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Удалить трек";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // openFilesButton
            // 
            openFilesButton.BackColor = Color.Lime;
            openFilesButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            openFilesButton.Location = new Point(396, 6);
            openFilesButton.Name = "openFilesButton";
            openFilesButton.Size = new Size(185, 43);
            openFilesButton.TabIndex = 1;
            openFilesButton.Text = "Добавить треки";
            openFilesButton.UseVisualStyleBackColor = false;
            openFilesButton.Click += openFilesButton_Click;
            // 
            // filesListBox
            // 
            filesListBox.AllowDrop = true;
            filesListBox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            filesListBox.FormattingEnabled = true;
            filesListBox.ItemHeight = 23;
            filesListBox.Location = new Point(6, 6);
            filesListBox.Name = "filesListBox";
            filesListBox.Size = new Size(384, 280);
            filesListBox.TabIndex = 0;
            filesListBox.SelectedIndexChanged += filesListBox_SelectedIndexChanged;
            filesListBox.DragDrop += filesListBox_DragDrop;
            filesListBox.DragOver += filesListBox_DragOver;
            filesListBox.MouseDown += filesListBox_MouseDown;
            filesListBox.MouseMove += filesListBox_MouseMove;
            filesListBox.MouseUp += filesListBox_MouseUp;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(768, 313);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "О проекте";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(750, 289);
            label1.TabIndex = 0;
            label1.Text = "Проект разработан в рамках дисциплины \r\n\"Разработка мобильных приложений\"\r\nстудентом группы 221-329 \r\nЕдисеевым Олегом Владимировичем\r\n\r\nПроект №13 - Аудиоплеер";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPerc
            // 
            labelPerc.AutoSize = true;
            labelPerc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelPerc.Location = new Point(666, 431);
            labelPerc.Name = "labelPerc";
            labelPerc.Size = new Size(29, 28);
            labelPerc.TabIndex = 12;
            labelPerc.Text = "%";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // songBar
            // 
            songBar.Location = new Point(-2, 360);
            songBar.Name = "songBar";
            songBar.Size = new Size(800, 56);
            songBar.TabIndex = 13;
            songBar.Scroll += songBar_Scroll;
            // 
            // shuffleButton
            // 
            shuffleButton.BackColor = SystemColors.Window;
            shuffleButton.BackgroundImage = (Image)resources.GetObject("shuffleButton.BackgroundImage");
            shuffleButton.BackgroundImageLayout = ImageLayout.Stretch;
            shuffleButton.Location = new Point(466, 408);
            shuffleButton.Name = "shuffleButton";
            shuffleButton.Size = new Size(45, 45);
            shuffleButton.TabIndex = 14;
            shuffleButton.UseVisualStyleBackColor = false;
            shuffleButton.Click += shuffleButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(224, 224, 224);
            saveButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            saveButton.Location = new Point(396, 189);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(185, 43);
            saveButton.TabIndex = 5;
            saveButton.Text = "Сохранить плейлист";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // openPlaylistButton
            // 
            openPlaylistButton.BackColor = Color.FromArgb(224, 224, 224);
            openPlaylistButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            openPlaylistButton.Location = new Point(580, 189);
            openPlaylistButton.Name = "openPlaylistButton";
            openPlaylistButton.Size = new Size(185, 43);
            openPlaylistButton.TabIndex = 6;
            openPlaylistButton.Text = "Открыть плейлист";
            openPlaylistButton.UseVisualStyleBackColor = false;
            openPlaylistButton.Click += openPlaylistButton_Click;
            // 
            // exportButton
            // 
            exportButton.BackColor = Color.FromArgb(255, 192, 255);
            exportButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            exportButton.Location = new Point(494, 238);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(185, 43);
            exportButton.TabIndex = 7;
            exportButton.Text = "Экспорт плейлиста";
            exportButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(798, 465);
            Controls.Add(shuffleButton);
            Controls.Add(labelPerc);
            Controls.Add(tabControl1);
            Controls.Add(volumeLabel);
            Controls.Add(progressEndLabel);
            Controls.Add(progressStartLabel);
            Controls.Add(backButton);
            Controls.Add(skipButton);
            Controls.Add(stopButton);
            Controls.Add(pauseButton);
            Controls.Add(playButton);
            Controls.Add(volumeBar);
            Controls.Add(progressBar);
            Controls.Add(songBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Аудиоплеер";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wavePictureBox).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)songBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button playButton;
        private Button pauseButton;
        private Button stopButton;
        private Button skipButton;
        private Button backButton;
        private ProgressBar progressBar;
        private Label progressStartLabel;
        private Label progressEndLabel;
        private TrackBar volumeBar;
        private Label volumeLabel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button openFilesButton;
        private ListBox filesListBox;
        private TabPage tabPage3;
        private Label label1;
        private Label labelPerc;
        private System.Windows.Forms.Timer timer1;
        private TrackBar songBar;
        private Button deleteButton;
        private Button shuffleButton;
        private Label currentSongLabel;
        private Label prevSongLabel;
        private Label nextSongLabel;
        private PictureBox wavePictureBox;
        private Button sortButton;
        private Button button2;
        private Button sortDurButton;
        private ComboBox comboBox1;
        private Label speedLabel;
        private Button exportButton;
        private Button openPlaylistButton;
        private Button saveButton;
    }
}
