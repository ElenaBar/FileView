using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FileView
{
    public partial class Form1 : Form
    {
        public static Bitmap MyImg;
        public static string FullNameOfImage = "\0";
        public static UInt32[,] Pixel;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = string.Format("{0}Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*", "ARG0");
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FullNameOfImage = openDialog.FileName;
                    MyImg = new Bitmap(openDialog.FileName);
                    pictureBox1.Image = MyImg;
                    
                    pictureBox1.Invalidate();

                    //получение матрицы с пикселями
                    Pixel = new UInt32[MyImg.Height, MyImg.Width];
                    for (int y = 0; y < MyImg.Height; y++)
                        for (int x = 0; x < MyImg.Width; x++)
                            Pixel[y, x] = (UInt32)(MyImg.GetPixel(x, y).ToArgb());
                }
                catch
                {
                    FullNameOfImage = "\0";
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
