namespace ImagePixel
{
    partial class img_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.img = new System.Windows.Forms.PictureBox();
            this.save_pb = new System.Windows.Forms.PictureBox();
            this.img_trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.img);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.save_pb);
            this.splitContainer.Panel2.Controls.Add(this.img_trackBar);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(665, 565);
            this.splitContainer.SplitterDistance = 608;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // img
            // 
            this.img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img.Image = global::ImagePixel.Properties.Resources.upload;
            this.img.Location = new System.Drawing.Point(0, 0);
            this.img.Margin = new System.Windows.Forms.Padding(4);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(608, 565);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            this.img.DragDrop += new System.Windows.Forms.DragEventHandler(this.img_DragDrop);
            this.img.DragEnter += new System.Windows.Forms.DragEventHandler(this.img_DragEnter);
            this.img.MouseHover += new System.EventHandler(this.img_MouseHover);
            // 
            // save_pb
            // 
            this.save_pb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_pb.BackgroundImage = global::ImagePixel.Properties.Resources.File_DownloadPng;
            this.save_pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.save_pb.Location = new System.Drawing.Point(4, 3);
            this.save_pb.Name = "save_pb";
            this.save_pb.Size = new System.Drawing.Size(44, 28);
            this.save_pb.TabIndex = 2;
            this.save_pb.TabStop = false;
            this.save_pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // img_trackBar
            // 
            this.img_trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img_trackBar.Location = new System.Drawing.Point(5, 31);
            this.img_trackBar.Margin = new System.Windows.Forms.Padding(4);
            this.img_trackBar.Maximum = 100;
            this.img_trackBar.Minimum = 1;
            this.img_trackBar.Name = "img_trackBar";
            this.img_trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.img_trackBar.Size = new System.Drawing.Size(45, 534);
            this.img_trackBar.TabIndex = 0;
            this.img_trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.img_trackBar.Value = 1;
            this.img_trackBar.Scroll += new System.EventHandler(this.img_trackBar_Scroll);
            // 
            // img_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 565);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "img_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.img_form_Shown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.TrackBar img_trackBar;
        private System.Windows.Forms.PictureBox save_pb;
    }
}

