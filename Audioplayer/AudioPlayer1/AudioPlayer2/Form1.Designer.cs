namespace AudioPlayer2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            playBtn = new Button();
            PauseBtn = new Button();
            volumeBar = new TrackBar();
            prevBtn = new Button();
            nextBtn = new Button();
            shuffleBtn = new Button();
            songBar = new TrackBar();
            progressBar = new ProgressBar();
            listBox = new ListBox();
            openBtn = new Button();
            deleteBtn = new Button();
            songStartLabel = new Label();
            songEndLabel = new Label();
            volumeLabel = new Label();
            curSongLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)songBar).BeginInit();
            SuspendLayout();
            // 
            // playBtn
            // 
            playBtn.AutoSize = true;
            playBtn.BackgroundImage = (Image)resources.GetObject("playBtn.BackgroundImage");
            playBtn.BackgroundImageLayout = ImageLayout.Stretch;
            playBtn.Location = new Point(111, 222);
            playBtn.Name = "playBtn";
            playBtn.Size = new Size(42, 44);
            playBtn.TabIndex = 0;
            playBtn.UseVisualStyleBackColor = true;
            // 
            // PauseBtn
            // 
            PauseBtn.AutoSize = true;
            PauseBtn.BackgroundImage = (Image)resources.GetObject("PauseBtn.BackgroundImage");
            PauseBtn.BackgroundImageLayout = ImageLayout.Stretch;
            PauseBtn.Location = new Point(159, 222);
            PauseBtn.Name = "PauseBtn";
            PauseBtn.Size = new Size(42, 44);
            PauseBtn.TabIndex = 1;
            PauseBtn.UseVisualStyleBackColor = true;
            // 
            // volumeBar
            // 
            volumeBar.Location = new Point(498, 222);
            volumeBar.Name = "volumeBar";
            volumeBar.Size = new Size(178, 56);
            volumeBar.TabIndex = 2;
            // 
            // prevBtn
            // 
            prevBtn.AutoSize = true;
            prevBtn.BackgroundImage = (Image)resources.GetObject("prevBtn.BackgroundImage");
            prevBtn.BackgroundImageLayout = ImageLayout.Stretch;
            prevBtn.Location = new Point(248, 222);
            prevBtn.Name = "prevBtn";
            prevBtn.Size = new Size(42, 44);
            prevBtn.TabIndex = 3;
            prevBtn.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            nextBtn.AutoSize = true;
            nextBtn.BackgroundImage = (Image)resources.GetObject("nextBtn.BackgroundImage");
            nextBtn.BackgroundImageLayout = ImageLayout.Stretch;
            nextBtn.Location = new Point(296, 222);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(42, 44);
            nextBtn.TabIndex = 4;
            nextBtn.UseVisualStyleBackColor = true;
            // 
            // shuffleBtn
            // 
            shuffleBtn.AutoSize = true;
            shuffleBtn.BackgroundImage = (Image)resources.GetObject("shuffleBtn.BackgroundImage");
            shuffleBtn.BackgroundImageLayout = ImageLayout.Stretch;
            shuffleBtn.Location = new Point(392, 222);
            shuffleBtn.Name = "shuffleBtn";
            shuffleBtn.Size = new Size(42, 44);
            shuffleBtn.TabIndex = 5;
            shuffleBtn.UseVisualStyleBackColor = true;
            // 
            // songBar
            // 
            songBar.Location = new Point(112, 326);
            songBar.Name = "songBar";
            songBar.Size = new Size(564, 56);
            songBar.TabIndex = 6;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(111, 388);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(565, 29);
            progressBar.TabIndex = 7;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.Location = new Point(21, 12);
            listBox.Name = "listBox";
            listBox.Size = new Size(413, 124);
            listBox.TabIndex = 8;
            // 
            // openBtn
            // 
            openBtn.Location = new Point(472, 12);
            openBtn.Name = "openBtn";
            openBtn.Size = new Size(94, 29);
            openBtn.TabIndex = 9;
            openBtn.Text = "Open";
            openBtn.UseVisualStyleBackColor = true;
            openBtn.Click += openBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(582, 12);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(94, 29);
            deleteBtn.TabIndex = 10;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // songStartLabel
            // 
            songStartLabel.AutoSize = true;
            songStartLabel.Location = new Point(86, 303);
            songStartLabel.Name = "songStartLabel";
            songStartLabel.Size = new Size(50, 20);
            songStartLabel.TabIndex = 11;
            songStartLabel.Text = "label1";
            // 
            // songEndLabel
            // 
            songEndLabel.AutoSize = true;
            songEndLabel.Location = new Point(655, 303);
            songEndLabel.Name = "songEndLabel";
            songEndLabel.Size = new Size(50, 20);
            songEndLabel.TabIndex = 12;
            songEndLabel.Text = "label2";
            // 
            // volumeLabel
            // 
            volumeLabel.AutoSize = true;
            volumeLabel.Location = new Point(692, 234);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(50, 20);
            volumeLabel.TabIndex = 13;
            volumeLabel.Text = "label3";
            // 
            // curSongLabel
            // 
            curSongLabel.Location = new Point(472, 116);
            curSongLabel.Name = "curSongLabel";
            curSongLabel.Size = new Size(204, 32);
            curSongLabel.TabIndex = 14;
            curSongLabel.Text = "label4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(curSongLabel);
            Controls.Add(volumeLabel);
            Controls.Add(songEndLabel);
            Controls.Add(songStartLabel);
            Controls.Add(deleteBtn);
            Controls.Add(openBtn);
            Controls.Add(listBox);
            Controls.Add(progressBar);
            Controls.Add(songBar);
            Controls.Add(shuffleBtn);
            Controls.Add(nextBtn);
            Controls.Add(prevBtn);
            Controls.Add(volumeBar);
            Controls.Add(PauseBtn);
            Controls.Add(playBtn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)songBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button playBtn;
        private Button PauseBtn;
        private TrackBar volumeBar;
        private Button prevBtn;
        private Button nextBtn;
        private Button shuffleBtn;
        private TrackBar songBar;
        private ProgressBar progressBar;
        private ListBox listBox;
        private Button openBtn;
        private Button deleteBtn;
        private Label songStartLabel;
        private Label songEndLabel;
        private Label volumeLabel;
        private Label curSongLabel;
    }
}
