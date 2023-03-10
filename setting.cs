using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace tvto
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Color colorFont;
        bool colorFontB;
        private void changeFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialogFont.ShowDialog() == DialogResult.OK)
            {
                colorFont = colorDialogFont.Color;
                colorFontB = true;
            }
            else { colorFontB = false; }
        }

        Font font;
        bool fontB;
        private void changeFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog.Font;
                fontB = true;
            }
            else fontB = false;
        }

        Color colorBack;
        bool colorBackB;
        private void changBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                colorBack = colorDialogBackground.Color;
                colorBackB = true;
            }
            else colorBackB = false;
        }

        string imgPath;
        bool imgPathB;
        private void changeBackImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFileDialog1.FileName;
                imgPathB = true;
            } else imgPathB = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                AppInfo appInfo = new AppInfo();
                if (colorFontB) appInfo.changeFontColor(colorFont);
                if (colorBackB) appInfo.changeBackColor(colorBack);
                if (imgPathB) appInfo.changeimg(imgPath);
                if (fontB) appInfo.changeFont(font);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
            }
            Close();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("آیا واقعا میخواهید برگردید به تنظیمات اول ؟","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
