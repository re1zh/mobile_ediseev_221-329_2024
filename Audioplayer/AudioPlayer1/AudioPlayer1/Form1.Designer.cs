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
            wavePictureBox = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            nextSongLabel = new Label();
            prevSongLabel = new Label();
            currentSongLabel = new Label();
            splitContainer1 = new SplitContainer();
            speedLabel = new Label();
            comboBox1 = new ComboBox();
            tabPage2 = new TabPage();
            splitContainer3 = new SplitContainer();
            filesListBox = new ListBox();
            exportButton = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            openFilesButton = new Button();
            sortButton = new Button();
            deleteButton = new Button();
            saveButton = new Button();
            openPlaylistButton = new Button();
            sortDurButton = new Button();
            tabPage3 = new TabPage();
            label1 = new Label();
            labelPerc = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            songBar = new TrackBar();
            shuffleButton = new Button();
            splitContainer2 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wavePictureBox).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)songBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Bottom;
            playButton.BackColor = SystemColors.Window;
            playButton.BackgroundImage = Properties.Resources.play;
            playButton.BackgroundImageLayout = ImageLayout.Stretch;
            playButton.Location = new Point(425, 72);
            playButton.Margin = new Padding(3, 2, 3, 2);
            playButton.Name = "playButton";
            playButton.Size = new Size(52, 44);
            playButton.TabIndex = 0;
            playButton.UseVisualStyleBackColor = false;
            playButton.Click += playButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Anchor = AnchorStyles.Bottom;
            pauseButton.BackColor = SystemColors.Window;
            pauseButton.BackgroundImage = Properties.Resources.pause;
            pauseButton.BackgroundImageLayout = ImageLayout.Stretch;
            pauseButton.Location = new Point(368, 72);
            pauseButton.Margin = new Padding(3, 2, 3, 2);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(52, 44);
            pauseButton.TabIndex = 1;
            pauseButton.UseVisualStyleBackColor = false;
            pauseButton.Click += pauseButton_Click;
            // 
            // stopButton
            // 
            stopButton.Anchor = AnchorStyles.Bottom;
            stopButton.BackColor = SystemColors.Window;
            stopButton.BackgroundImage = (Image)resources.GetObject("stopButton.BackgroundImage");
            stopButton.BackgroundImageLayout = ImageLayout.Stretch;
            stopButton.Location = new Point(482, 72);
            stopButton.Margin = new Padding(3, 2, 3, 2);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(55, 44);
            stopButton.TabIndex = 2;
            stopButton.UseVisualStyleBackColor = false;
            stopButton.Click += stopButton_Click;
            // 
            // skipButton
            // 
            skipButton.Anchor = AnchorStyles.Bottom;
            skipButton.BackColor = SystemColors.Window;
            skipButton.BackgroundImage = (Image)resources.GetObject("skipButton.BackgroundImage");
            skipButton.BackgroundImageLayout = ImageLayout.Stretch;
            skipButton.Location = new Point(593, 72);
            skipButton.Margin = new Padding(3, 2, 3, 2);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(48, 44);
            skipButton.TabIndex = 3;
            skipButton.UseVisualStyleBackColor = false;
            skipButton.Click += skipButton_Click;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom;
            backButton.BackColor = SystemColors.Window;
            backButton.BackgroundImage = (Image)resources.GetObject("backButton.BackgroundImage");
            backButton.BackgroundImageLayout = ImageLayout.Stretch;
            backButton.Location = new Point(262, 72);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(54, 44);
            backButton.TabIndex = 4;
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(16, 22);
            progressBar.Margin = new Padding(3, 2, 3, 2);
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1054, 9);
            progressBar.TabIndex = 5;
            // 
            // progressStartLabel
            // 
            progressStartLabel.Anchor = AnchorStyles.Left;
            progressStartLabel.AutoSize = true;
            progressStartLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            progressStartLabel.Location = new Point(4, 52);
            progressStartLabel.Name = "progressStartLabel";
            progressStartLabel.Size = new Size(50, 21);
            progressStartLabel.TabIndex = 6;
            progressStartLabel.Text = "00:00";
            // 
            // progressEndLabel
            // 
            progressEndLabel.Anchor = AnchorStyles.Right;
            progressEndLabel.AutoSize = true;
            progressEndLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            progressEndLabel.Location = new Point(1025, 52);
            progressEndLabel.Name = "progressEndLabel";
            progressEndLabel.Size = new Size(50, 21);
            progressEndLabel.TabIndex = 7;
            progressEndLabel.Text = "00:00";
            // 
            // volumeBar
            // 
            volumeBar.Anchor = AnchorStyles.Bottom;
            volumeBar.Location = new Point(823, 69);
            volumeBar.Margin = new Padding(3, 2, 3, 2);
            volumeBar.Maximum = 100;
            volumeBar.Name = "volumeBar";
            volumeBar.Size = new Size(142, 45);
            volumeBar.TabIndex = 8;
            volumeBar.TickStyle = TickStyle.None;
            volumeBar.Scroll += volumeBar_Scroll;
            // 
            // volumeLabel
            // 
            volumeLabel.Anchor = AnchorStyles.Bottom;
            volumeLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            volumeLabel.Location = new Point(878, 90);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(39, 21);
            volumeLabel.TabIndex = 9;
            volumeLabel.Text = "0";
            volumeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1078, 341);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.PaleTurquoise;
            tabPage1.Controls.Add(wavePictureBox);
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1070, 313);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Главная";
            // 
            // wavePictureBox
            // 
            wavePictureBox.BackColor = Color.MintCream;
            wavePictureBox.Dock = DockStyle.Bottom;
            wavePictureBox.Location = new Point(3, 215);
            wavePictureBox.Margin = new Padding(3, 2, 3, 2);
            wavePictureBox.Name = "wavePictureBox";
            wavePictureBox.Size = new Size(1064, 96);
            wavePictureBox.TabIndex = 3;
            wavePictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(nextSongLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(prevSongLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(currentSongLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(splitContainer1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 2);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            tableLayoutPanel1.Size = new Size(1064, 229);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // nextSongLabel
            // 
            nextSongLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nextSongLabel.Location = new Point(535, 0);
            nextSongLabel.Name = "nextSongLabel";
            nextSongLabel.Size = new Size(376, 76);
            nextSongLabel.TabIndex = 1;
            nextSongLabel.Text = "Следующий:";
            nextSongLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // prevSongLabel
            // 
            prevSongLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            prevSongLabel.Location = new Point(3, 0);
            prevSongLabel.Name = "prevSongLabel";
            prevSongLabel.Size = new Size(375, 76);
            prevSongLabel.TabIndex = 2;
            prevSongLabel.Text = "Предыдущий:";
            prevSongLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // currentSongLabel
            // 
            currentSongLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            currentSongLabel.ForeColor = Color.Black;
            currentSongLabel.Location = new Point(3, 114);
            currentSongLabel.Name = "currentSongLabel";
            currentSongLabel.Size = new Size(375, 79);
            currentSongLabel.TabIndex = 0;
            currentSongLabel.Text = "Сейчас играет:";
            currentSongLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(535, 116);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(speedLabel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(comboBox1);
            splitContainer1.Size = new Size(526, 111);
            splitContainer1.SplitterDistance = 365;
            splitContainer1.TabIndex = 15;
            // 
            // speedLabel
            // 
            speedLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            speedLabel.ForeColor = Color.Black;
            speedLabel.Location = new Point(0, -2);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(364, 70);
            speedLabel.TabIndex = 5;
            speedLabel.Text = "Скорость воспроизведения:";
            speedLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(17, 47);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(80, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.PaleTurquoise;
            tabPage2.Controls.Add(splitContainer3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1070, 313);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Плейлист";
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 2);
            splitContainer3.Margin = new Padding(3, 2, 3, 2);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(filesListBox);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(exportButton);
            splitContainer3.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer3.Size = new Size(1064, 309);
            splitContainer3.SplitterDistance = 354;
            splitContainer3.TabIndex = 8;
            // 
            // filesListBox
            // 
            filesListBox.AllowDrop = true;
            filesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            filesListBox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            filesListBox.FormattingEnabled = true;
            filesListBox.ItemHeight = 19;
            filesListBox.Location = new Point(0, 0);
            filesListBox.Margin = new Padding(3, 2, 3, 2);
            filesListBox.Name = "filesListBox";
            filesListBox.Size = new Size(355, 270);
            filesListBox.TabIndex = 0;
            filesListBox.SelectedIndexChanged += filesListBox_SelectedIndexChanged;
            filesListBox.DragDrop += filesListBox_DragDrop;
            filesListBox.DragOver += filesListBox_DragOver;
            filesListBox.MouseDown += filesListBox_MouseDown;
            filesListBox.MouseMove += filesListBox_MouseMove;
            filesListBox.MouseUp += filesListBox_MouseUp;
            // 
            // exportButton
            // 
            exportButton.BackColor = Color.FromArgb(255, 192, 255);
            exportButton.Dock = DockStyle.Bottom;
            exportButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            exportButton.Location = new Point(0, 246);
            exportButton.Margin = new Padding(3, 2, 3, 2);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(706, 63);
            exportButton.TabIndex = 7;
            exportButton.Text = "Экспорт плейлиста";
            exportButton.UseVisualStyleBackColor = false;
            exportButton.Click += exportButton_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(openFilesButton, 0, 0);
            tableLayoutPanel2.Controls.Add(sortButton, 1, 2);
            tableLayoutPanel2.Controls.Add(deleteButton, 1, 0);
            tableLayoutPanel2.Controls.Add(saveButton, 1, 1);
            tableLayoutPanel2.Controls.Add(openPlaylistButton, 0, 1);
            tableLayoutPanel2.Controls.Add(sortDurButton, 0, 2);
            tableLayoutPanel2.Location = new Point(3, 2);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.Size = new Size(701, 244);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // openFilesButton
            // 
            openFilesButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openFilesButton.BackColor = Color.Lime;
            openFilesButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            openFilesButton.Location = new Point(3, 2);
            openFilesButton.Margin = new Padding(3, 2, 3, 2);
            openFilesButton.Name = "openFilesButton";
            openFilesButton.Size = new Size(344, 78);
            openFilesButton.TabIndex = 1;
            openFilesButton.Text = "Добавить треки";
            openFilesButton.UseVisualStyleBackColor = false;
            openFilesButton.Click += openFilesButton_Click;
            // 
            // sortButton
            // 
            sortButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sortButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            sortButton.Location = new Point(353, 166);
            sortButton.Margin = new Padding(3, 2, 3, 2);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(345, 76);
            sortButton.TabIndex = 3;
            sortButton.Text = "Сортировать по алфавиту";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deleteButton.BackColor = Color.FromArgb(255, 128, 128);
            deleteButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            deleteButton.Location = new Point(353, 2);
            deleteButton.Margin = new Padding(3, 2, 3, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(345, 78);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Удалить трек";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            saveButton.BackColor = Color.FromArgb(224, 224, 224);
            saveButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            saveButton.Location = new Point(353, 84);
            saveButton.Margin = new Padding(3, 2, 3, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(345, 78);
            saveButton.TabIndex = 5;
            saveButton.Text = "Сохранить плейлист";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // openPlaylistButton
            // 
            openPlaylistButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openPlaylistButton.BackColor = Color.FromArgb(224, 224, 224);
            openPlaylistButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            openPlaylistButton.Location = new Point(3, 84);
            openPlaylistButton.Margin = new Padding(3, 2, 3, 2);
            openPlaylistButton.Name = "openPlaylistButton";
            openPlaylistButton.Size = new Size(344, 78);
            openPlaylistButton.TabIndex = 6;
            openPlaylistButton.Text = "Открыть плейлист";
            openPlaylistButton.UseVisualStyleBackColor = false;
            openPlaylistButton.Click += openPlaylistButton_Click;
            // 
            // sortDurButton
            // 
            sortDurButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sortDurButton.Location = new Point(3, 166);
            sortDurButton.Margin = new Padding(3, 2, 3, 2);
            sortDurButton.Name = "sortDurButton";
            sortDurButton.Size = new Size(344, 76);
            sortDurButton.TabIndex = 4;
            sortDurButton.Text = "Сортировать по длительности";
            sortDurButton.UseVisualStyleBackColor = true;
            sortDurButton.Click += sortDurButton_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1070, 313);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "О проекте";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1070, 313);
            label1.TabIndex = 0;
            label1.Text = "Проект разработан в рамках дисциплины \r\n\"Разработка мобильных приложений\"\r\nстудентом группы 221-329 \r\nЕдисеевым Олегом Владимировичем\r\n\r\nПроект №13 - Аудиоплеер";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPerc
            // 
            labelPerc.Anchor = AnchorStyles.Bottom;
            labelPerc.AutoSize = true;
            labelPerc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelPerc.Location = new Point(928, 90);
            labelPerc.Name = "labelPerc";
            labelPerc.Size = new Size(23, 21);
            labelPerc.TabIndex = 12;
            labelPerc.Text = "%";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // songBar
            // 
            songBar.Dock = DockStyle.Top;
            songBar.Location = new Point(0, 0);
            songBar.Margin = new Padding(3, 2, 3, 2);
            songBar.Name = "songBar";
            songBar.Size = new Size(1078, 45);
            songBar.TabIndex = 13;
            songBar.Scroll += songBar_Scroll;
            // 
            // shuffleButton
            // 
            shuffleButton.Anchor = AnchorStyles.Bottom;
            shuffleButton.BackColor = SystemColors.Window;
            shuffleButton.BackgroundImage = (Image)resources.GetObject("shuffleButton.BackgroundImage");
            shuffleButton.BackgroundImageLayout = ImageLayout.Stretch;
            shuffleButton.Location = new Point(699, 72);
            shuffleButton.Margin = new Padding(3, 2, 3, 2);
            shuffleButton.Name = "shuffleButton";
            shuffleButton.Size = new Size(52, 44);
            shuffleButton.TabIndex = 14;
            shuffleButton.UseVisualStyleBackColor = false;
            shuffleButton.Click += shuffleButton_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(3, 2, 3, 2);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(labelPerc);
            splitContainer2.Panel2.Controls.Add(shuffleButton);
            splitContainer2.Panel2.Controls.Add(progressEndLabel);
            splitContainer2.Panel2.Controls.Add(progressBar);
            splitContainer2.Panel2.Controls.Add(playButton);
            splitContainer2.Panel2.Controls.Add(skipButton);
            splitContainer2.Panel2.Controls.Add(progressStartLabel);
            splitContainer2.Panel2.Controls.Add(volumeLabel);
            splitContainer2.Panel2.Controls.Add(backButton);
            splitContainer2.Panel2.Controls.Add(volumeBar);
            splitContainer2.Panel2.Controls.Add(pauseButton);
            splitContainer2.Panel2.Controls.Add(stopButton);
            splitContainer2.Panel2.Controls.Add(songBar);
            splitContainer2.Size = new Size(1078, 464);
            splitContainer2.SplitterDistance = 341;
            splitContainer2.SplitterWidth = 3;
            splitContainer2.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1078, 464);
            Controls.Add(splitContainer2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Аудиоплеер";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wavePictureBox).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)songBar).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
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
        private Button sortButton;
        private Button button2;
        private Button sortDurButton;
        private ComboBox comboBox1;
        private Label speedLabel;
        private Button exportButton;
        private Button openPlaylistButton;
        private Button saveButton;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox wavePictureBox;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
