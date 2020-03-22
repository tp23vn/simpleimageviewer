using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class PhotoViewer : Form
    {
        private double _scaleRatio;
        public PhotoViewer()
        {
            _scaleRatio = 1.0;

            InitializeComponent();
        }

        private void PhotoViewer_Load(object sender, EventArgs e)
        {
            this.ptbViewer.MouseWheel += this.ptbViewer_MouseWheel;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpeg, *.jpg, *.bmp)|*.png;*.jpg;*.jpeg;*.bmp|PNG (*.png)|*.png|JPEG (*.jpeg)|*.jpeg|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbViewer.Image = Image.FromFile(openFileDialog.FileName);
                ptbViewer.Width = ptbViewer.Image.Width;
                ptbViewer.Height = ptbViewer.Image.Height;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptbViewer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_scaleRatio >= 0.125 && _scaleRatio <= 4)
            {
                if (e.Delta > 0)
                {
                    if (_scaleRatio < 4)
                    {
                        _scaleRatio *= 2;
                        Zoom();
                    }
                }
                else
                {
                    if (_scaleRatio > 0.125)
                    {
                        _scaleRatio /= 2;
                        Zoom();
                    }
                }
            }
        }

        private void Zoom() {
            ptbViewer.Width = (int)(ptbViewer.Image.Width * _scaleRatio);
            ptbViewer.Height = (int)(ptbViewer.Image.Height * _scaleRatio);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Developed by Tai Phung\nEmail: taiphungdinh@gmail.com";
            MessageBox.Show(message, "About", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
