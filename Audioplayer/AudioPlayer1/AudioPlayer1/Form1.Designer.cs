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
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            tabPage2 = new TabPage();
            deleteButton = new Button();
            openFilesButton = new Button();
            filesListBox = new ListBox();
            tabPage3 = new TabPage();
            label1 = new Label();
            labelPerc = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            songBar = new TrackBar();
            shuffleButton = new Button();
            loopButton = new Button();
            ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)songBar).BeginInit();
            SuspendLayout();
            // 
            // playButton
            // 
            playButton.BackgroundImage = Properties.Resources.play;
            playButton.BackgroundImageLayout = ImageLayout.Stretch;
            playButton.Location = new Point(198, 406);
            playButton.Name = "playButton";
            playButton.Size = new Size(42, 45);
            playButton.TabIndex = 0;
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.BackgroundImage = Properties.Resources.pause;
            pauseButton.BackgroundImageLayout = ImageLayout.Stretch;
            pauseButton.Location = new Point(246, 406);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(42, 45);
            pauseButton.TabIndex = 1;
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // stopButton
            // 
            stopButton.BackgroundImage = (Image)resources.GetObject("stopButton.BackgroundImage");
            stopButton.BackgroundImageLayout = ImageLayout.Stretch;
            stopButton.Location = new Point(294, 406);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(42, 45);
            stopButton.TabIndex = 2;
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // skipButton
            // 
            skipButton.BackgroundImage = (Image)resources.GetObject("skipButton.BackgroundImage");
            skipButton.BackgroundImageLayout = ImageLayout.Stretch;
            skipButton.Location = new Point(354, 406);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(42, 45);
            skipButton.TabIndex = 3;
            skipButton.UseVisualStyleBackColor = true;
            skipButton.Click += skipButton_Click;
            // 
            // backButton
            // 
            backButton.BackgroundImage = (Image)resources.GetObject("backButton.BackgroundImage");
            backButton.BackgroundImageLayout = ImageLayout.Stretch;
            backButton.Location = new Point(134, 406);
            backButton.Name = "backButton";
            backButton.Size = new Size(42, 45);
            backButton.TabIndex = 4;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(19, 384);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(759, 10);
            progressBar.TabIndex = 5;
            // 
            // progressStartLabel
            // 
            progressStartLabel.AutoSize = true;
            progressStartLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            progressStartLabel.Location = new Point(12, 400);
            progressStartLabel.Name = "progressStartLabel";
            progressStartLabel.Size = new Size(61, 28);
            progressStartLabel.TabIndex = 6;
            progressStartLabel.Text = "00:00";
            // 
            // progressEndLabel
            // 
            progressEndLabel.AutoSize = true;
            progressEndLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            progressEndLabel.Location = new Point(727, 400);
            progressEndLabel.Name = "progressEndLabel";
            progressEndLabel.Size = new Size(61, 28);
            progressEndLabel.TabIndex = 7;
            progressEndLabel.Text = "00:00";
            // 
            // volumeBar
            // 
            volumeBar.Location = new Point(559, 400);
            volumeBar.Maximum = 100;
            volumeBar.Name = "volumeBar";
            volumeBar.Size = new Size(162, 56);
            volumeBar.TabIndex = 8;
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
            tabPage1.Controls.Add(axWindowsMediaPlayer1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 313);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Главная";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(3, 3);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(759, 384);
            axWindowsMediaPlayer1.TabIndex = 0;
            axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(deleteButton);
            tabPage2.Controls.Add(openFilesButton);
            tabPage2.Controls.Add(filesListBox);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 313);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Плейлист";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(568, 6);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(194, 29);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Удалить файл";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // openFilesButton
            // 
            openFilesButton.Location = new Point(571, 257);
            openFilesButton.Name = "openFilesButton";
            openFilesButton.Size = new Size(194, 29);
            openFilesButton.TabIndex = 1;
            openFilesButton.Text = "Открыть файлы";
            openFilesButton.UseVisualStyleBackColor = true;
            openFilesButton.Click += openFilesButton_Click;
            // 
            // filesListBox
            // 
            filesListBox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            filesListBox.FormattingEnabled = true;
            filesListBox.ItemHeight = 23;
            filesListBox.Location = new Point(6, 6);
            filesListBox.Name = "filesListBox";
            filesListBox.Size = new Size(559, 280);
            filesListBox.TabIndex = 0;
            filesListBox.SelectedIndexChanged += filesListBox_SelectedIndexChanged;
            //filesListBox.DoubleClick += filesListBox_DoubleClick;
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
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(377, 289);
            label1.TabIndex = 0;
            label1.Text = "Проект разработан в рамках дисциплины \"Разработка мобильных приложений\"\r\nстудентом группы 221-329 Едисеевым Олегом Владимировичем\r\n\r\nПроект №13 - Аудиоплеер";
            label1.TextAlign = ContentAlignment.MiddleLeft;
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
            songBar.Location = new Point(-1, 360);
            songBar.Name = "songBar";
            songBar.Size = new Size(795, 56);
            songBar.TabIndex = 13;
            songBar.Scroll += songBar_Scroll;
            // 
            // shuffleButton
            // 
            shuffleButton.BackgroundImage = (Image)resources.GetObject("shuffleButton.BackgroundImage");
            shuffleButton.BackgroundImageLayout = ImageLayout.Stretch;
            shuffleButton.Location = new Point(437, 406);
            shuffleButton.Name = "shuffleButton";
            shuffleButton.Size = new Size(42, 45);
            shuffleButton.TabIndex = 14;
            shuffleButton.UseVisualStyleBackColor = true;
            shuffleButton.Click += shuffleButton_Click;
            // 
            // loopButton
            // 
            loopButton.BackgroundImage = (Image)resources.GetObject("loopButton.BackgroundImage");
            loopButton.BackgroundImageLayout = ImageLayout.Stretch;
            loopButton.Location = new Point(485, 406);
            loopButton.Name = "loopButton";
            loopButton.Size = new Size(42, 45);
            loopButton.TabIndex = 15;
            loopButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 465);
            Controls.Add(loopButton);
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
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
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
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
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
        private Button loopButton;
    }
}
