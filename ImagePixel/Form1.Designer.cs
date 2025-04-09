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
            this.dragAnddrop_lbl = new System.Windows.Forms.Label();
            this.img_trackBar = new System.Windows.Forms.TrackBar();
            this.img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.dragAnddrop_lbl);
            this.splitContainer.Panel1.Controls.Add(this.img);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.img_trackBar);
            this.splitContainer.Size = new System.Drawing.Size(774, 376);
            this.splitContainer.SplitterDistance = 711;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // dragAnddrop_lbl
            // 
            this.dragAnddrop_lbl.Location = new System.Drawing.Point(13, 9);
            this.dragAnddrop_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dragAnddrop_lbl.Name = "dragAnddrop_lbl";
            this.dragAnddrop_lbl.Size = new System.Drawing.Size(170, 16);
            this.dragAnddrop_lbl.TabIndex = 0;
            this.dragAnddrop_lbl.Text = "Перетащи картинку сюда";
            this.dragAnddrop_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // img_trackBar
            // 
            this.img_trackBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.img_trackBar.Location = new System.Drawing.Point(13, 0);
            this.img_trackBar.Margin = new System.Windows.Forms.Padding(4);
            this.img_trackBar.Maximum = 100;
            this.img_trackBar.Minimum = 1;
            this.img_trackBar.Name = "img_trackBar";
            this.img_trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.img_trackBar.Size = new System.Drawing.Size(45, 376);
            this.img_trackBar.TabIndex = 0;
            this.img_trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.img_trackBar.Value = 1;
            this.img_trackBar.Scroll += new System.EventHandler(this.img_trackBar_Scroll);
            // 
            // img
            // 
            this.img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img.Image = global::ImagePixel.Properties.Resources.upload;
            this.img.Location = new System.Drawing.Point(0, 0);
            this.img.Margin = new System.Windows.Forms.Padding(4);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(711, 376);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            this.img.DragDrop += new System.Windows.Forms.DragEventHandler(this.img_DragDrop);
            this.img.DragEnter += new System.Windows.Forms.DragEventHandler(this.img_DragEnter);
            this.img.DragLeave += new System.EventHandler(this.img_DragLeave);
            // 
            // img_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 376);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "img_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0 %";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.TrackBar img_trackBar;
        private System.Windows.Forms.Label dragAnddrop_lbl;
    }
}

