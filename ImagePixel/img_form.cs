using ImagePixel.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            save_pb.MouseHover += (sender, e) => { save_pb.Cursor = Cursors.Hand; };
            save_pb.MouseLeave += (sender, e) => { save_pb.Cursor = Cursors.Default; };
        }

        private void img_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void img_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop); //получение пути к файлу
            if (filePaths != null && filePaths.Length > 0)
            {
                string filePath = filePaths[0];
                if (new[] { ".bmp", ".png", ".jpg" }.Contains(Path.GetExtension(filePath).ToLower()))
                    ImgLoad(filePath);
            }
        }

        private void img_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "Images|*.bmp;*.png;*.jpg"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                ImgLoad(dlg.FileName);
        }

        ImgInfo imgInfo = new ImgInfo();

        private async void ImgLoad(string dlgFileName)
        {
            var sw = Stopwatch.StartNew();
            img_trackBar.Enabled = false;
            img.Enabled = false;
            save_pb.Enabled = false;
            img.Image = null;
            img_trackBar.Value = 1;
            _bitmaps.Clear();
            Bitmap bitmap = new Bitmap(dlgFileName);
            await Task.Run(() => { RunProcessing(bitmap); });
            img_trackBar.Enabled = true;
            img.Enabled = true;
            save_pb.Enabled = true;
            sw.Stop();
            TimeSpan elapsed = sw.Elapsed;
            this.Text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                                      elapsed.Hours,
                                      elapsed.Minutes,
                                      elapsed.Seconds,
                                      elapsed.Milliseconds);

            imgInfo.Name = dlgFileName;
        }

        private void RunProcessing(Bitmap bitmap)
        {
            var pixels = GetPixels(bitmap);

            var pixelsInStep = (bitmap.Width * bitmap.Height) / img_trackBar.Maximum;
            var currentPixelsSet = new List<Pixel>(pixels.Count - pixelsInStep);
            var usedIndices = new HashSet<int>();

            for (int i = 1; i <= img_trackBar.Maximum; i++)
            {
                for (int j = 0; j < pixelsInStep; j++)
                {
                    int index;
                    do index = _random.Next(pixels.Count);
                    while (usedIndices.Contains(index));

                    usedIndices.Add(index);
                    currentPixelsSet.Add(pixels[index]);
                }
                var currentBitmap = new Bitmap(bitmap.Width, bitmap.Height);

                foreach (var pixel in currentPixelsSet)
                    currentBitmap.SetPixel(pixel.Point.X, pixel.Point.Y, pixel.Color);

                _bitmaps.Add(currentBitmap);

                this.Invoke(new Action(() => 
                {
                    this.Text = $"{i} %"; 
                    img_trackBar.Value = i;
                    img.Image = _bitmaps[img_trackBar.Value - 1];
                    imgInfo.scroll_Percentage = img_trackBar.Value;
                }));
            }
            _bitmaps.Add(bitmap);
            ////////////////////////////////////////////////////////////////////

            //for (int i = 1; i < img_trackBar.Maximum; i++)
            //{
            //    for (int j = 0; j < pixelsInStep; j++)
            //    {
            //        var index = _random.Next(pixels.Count);
            //        currentPixelsSet.Add(pixels[index]);
            //        pixels.RemoveAt(index);
            //    }
            //    var currentBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            //    foreach (var pixel in currentPixelsSet)
            //        currentBitmap.SetPixel(pixel.Point.X, pixel.Point.Y, pixel.Color);

            //    _bitmaps.Add(currentBitmap);

            //    this.Invoke(new Action(() => { this.Text = $"{i} %"; img_trackBar.Value = i; }));
            //}
            //_bitmaps.Add(bitmap);
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
            this.Text = $"{img_trackBar.Value.ToString()} %";
            if (_bitmaps == null || _bitmaps.Count == 0) 
                return;
            img.Image = _bitmaps[img_trackBar.Value-1];

            imgInfo.scroll_Percentage = img_trackBar.Value;
        }

        private void img_form_Shown(object sender, EventArgs e)
        {
            Application.Idle += OnApplicationIdle;
        }

        private async void OnApplicationIdle(object sender, EventArgs e)
        {
            Application.Idle -= OnApplicationIdle; // Удаляем обработчик, чтобы он вызвался только один раз

            var sw = Stopwatch.StartNew();
            img_trackBar.Enabled = false;
            save_pb.Enabled = false;
            img.Enabled = false;
            img_trackBar.Value = 1;
            _bitmaps.Clear();

            Bitmap originalBitmap = img.Image as Bitmap;
            // Клонируем оригинальный Bitmap без изменения DPI
            Bitmap bitmap = originalBitmap.Clone(new Rectangle(0, 0,
                originalBitmap.Width, originalBitmap.Height), originalBitmap.PixelFormat);
            await Task.Run(() => { RunProcessing(bitmap); });

            img_trackBar.Enabled = true;
            img.Enabled = true;
            save_pb.Enabled = true;
            sw.Stop();
            TimeSpan elapsed = sw.Elapsed;
            this.Text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                                      elapsed.Hours,
                                      elapsed.Minutes,
                                      elapsed.Seconds,
                                      elapsed.Milliseconds);

            imgInfo.Name = "sample.jpg";
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (img.Image != null)
            {
                try
                {
                    string folderName = "Saved Images";
                    string fileName = $"{imgInfo.scroll_Percentage}% {Path.GetFileName(imgInfo.Name)}";

                    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string filePath = Path.Combine(folderPath, fileName);
                    img.Image.Save(filePath);

                    //string fileExt = Path.GetExtension(imgInfo.Name).ToLower();
                    //ImageFormat format;
                    //switch (fileExt.ToLower())
                    //{
                    //    case ".png":
                    //        format = ImageFormat.Png;
                    //        break;
                    //    case ".jpeg":
                    //    case ".jpg":
                    //        format = ImageFormat.Jpeg;
                    //        break;
                    //    default:
                    //        throw new ArgumentException($"Формат '{fileExt}' не поддерживается.");
                    //}
                    //img.Image.Save(filePath, format);

                    DialogResult result = MessageBox.Show($"Изображение сохранено \n \n Открываем папку с файлом?", "Результат",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                        Process.Start("explorer.exe", Path.GetDirectoryName(filePath));
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка сохранения изображения: {ex.Message}"); }
            }
            else { MessageBox.Show("В PictureBox отсутствует изображение."); }
        }

        private void img_MouseHover(object sender, EventArgs e)
        {
            //HoverAnimation();
        }

        //private async void HoverAnimation()
        //{
        //    await Task.Run(async () =>
        //    {
        //        Pen pen = new Pen(Color.Black, 2);
        //        for (int i = 30; i > 2; i--, await Task.Delay(50))
        //        {
        //            save_pb.CreateGraphics().Clear(SystemColors.Control);
        //            pen.DashPattern = new float[] { 2, i };
        //            save_pb.CreateGraphics().DrawRectangle(pen, 1, 1, save_pb.Width - 2, save_pb.Height - 2);
        //        }
        //    });
        //}
    }
}
