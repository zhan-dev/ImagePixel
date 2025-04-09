using ImagePixel.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImagePixel
{
    public partial class img_form : Form
    {
        private List<Bitmap> _bitmaps = new List<Bitmap>();
        private Random _random = new Random();
        public img_form()
        {
            InitializeComponent();
            img.AllowDrop = true;
        }

        private void img_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
                dragAnddrop_lbl.Text = "отпускай";
            }
        }

        private void img_DragLeave(object sender, EventArgs e)
        {
            dragAnddrop_lbl.Text = "Перетащи картинку сюда";
        }

        private void img_DragDrop(object sender, DragEventArgs e)
        {
            dragAnddrop_lbl.Text = "Перетащи картинку сюда";
            e.Data.GetData(DataFormats.FileDrop);
        }

        private async void img_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.Filter = "Images|*.bmp;*.png;*.jpg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var sw = Stopwatch.StartNew();
                this.Enabled = false;
                img.Image = null;
                _bitmaps.Clear();
                Bitmap bitmap = new Bitmap(dlg.FileName);
                await Task.Run(() => { RunProcessing(bitmap); });
                this.Enabled = true;
                sw.Stop();
                this.Text = sw.Elapsed.ToString();
            }
        }

        private void RunProcessing(Bitmap bitmap)
        {
            var pixels = GetPixels(bitmap);
            var pixelsInStep = (bitmap.Width * bitmap.Height) / 100;
            var currentPixelsSet = new List<Pixel>(pixels.Count - pixelsInStep);

            for(int i = 1; i < img_trackBar.Maximum; i++)
            {
                for (int j = 0; j < pixelsInStep; j++)
                {
                    var index = _random.Next(pixels.Count);
                    currentPixelsSet.Add(pixels[index]);
                    pixels.RemoveAt(index);
                }
                var currentBitmap = new Bitmap(bitmap.Width, bitmap.Height);

                foreach (var pixel in currentPixelsSet)
                    currentBitmap.SetPixel(pixel.Point.X, pixel.Point.Y,pixel.Color);

                _bitmaps.Add(currentBitmap);
                
                this.Invoke(new Action(() => { this.Text = $"{i} %"; }));
            }
            _bitmaps.Add(bitmap);
        }

        private List<Pixel> GetPixels(Bitmap bitmap)
        {
            var pixels = new List<Pixel>(bitmap.Width * bitmap.Height);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    pixels.Add(new Pixel()
                    {
                        Color = bitmap.GetPixel(x, y),
                        Point = new Point() { X = x, Y = y }
                    });
                }
            }
            return pixels;
        }

        private void img_trackBar_Scroll(object sender, EventArgs e)
        {
            this.Text = img_trackBar.Value.ToString();
            if (_bitmaps == null || _bitmaps.Count == 0) 
                return;
            img.Image = _bitmaps[img_trackBar.Value-1]; 
        }












        //private async void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    await Task.Run(async () =>
        //    {
        //        Pen pen = new Pen(Color.Black, 2);
        //        for (int i = 30; i > 2; i--, await Task.Delay(50))
        //        {
        //            panel1.CreateGraphics().Clear(SystemColors.Control);
        //            pen.DashPattern = new float[] { 2, i };
        //            panel1.CreateGraphics().DrawRectangle(pen, 1, 1, panel1.Width - 2, panel1.Height - 2);
        //        }
        //    });
        //}
    }
}
