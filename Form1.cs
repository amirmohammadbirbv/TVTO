using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static tvto.tvto2DataSet;

namespace tvto
{
    public partial class Form1 : Form
    {
        AppInfo appInfo = new AppInfo();
        public Form1()
        {
            InitializeComponent();
        }
        //open forms
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            new addPerson().ShowDialog();
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            new car().ShowDialog();
        }
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            new entesab().ShowDialog();
        }
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //make Customize
        bool isSuccesFontDialog = false;
        bool isSuccesFontColorDialog = false;
        bool isSuccesBackColorDialog = false;
        bool isSuccesImageDialog = false;
        private void btnchangeFontColor_Click(object sender, EventArgs e)
        {
            if (colorFontDialog.ShowDialog() == DialogResult.OK) isSuccesFontColorDialog = true;
        }
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (colorBackDialog.ShowDialog() == DialogResult.OK) isSuccesBackColorDialog = true;
        }
        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK) isSuccesFontDialog = true;
        }
        private void btnBackImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "ImageFile(*.BMP;*.jpg;*.PNG)|*.BMP;*.jpg;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) isSuccesImageDialog = true;
        }
        private void buttonItem9_Click(object sender, EventArgs e)
        {
            CurrentInfos.IsTheme = false;
                appInfo = new AppInfo();
            if (isSuccesFontDialog) appInfo.changeFont(fontDialog1.Font);
            if (isSuccesFontColorDialog) appInfo.changeFontColor(colorFontDialog.Color);
            if (isSuccesBackColorDialog) appInfo.changeBackColor(colorBackDialog.Color);
            if (isSuccesImageDialog) appInfo.changeimg(openFileDialog1.FileName);
            Form1_Load(sender, e);
        }
        private void buttonItem10_Click(object sender, EventArgs e)
        {
            CurrentInfos.IsTheme = true;
            File.WriteAllText("appInfo.txt", " "+"\r\n"+" " + "\r\n" + " " + "\r\n" + " ");
            openFileDialog1.Reset();
            colorBackDialog.Color = Color.FromArgb(255,255, 255, 255);
            colorFontDialog.Reset();
            fontDialog1.Reset();
            Form1_Load(sender, e);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ribbonPanel1.Style.BackColor = appInfo.getBackColorByFile();
                label1.ForeColor = appInfo.getFontColorByFile();
                label3.ForeColor = appInfo.getFontColorByFile();
                label1.BackColor = appInfo.getBackColorByFile();
                label3.BackColor = appInfo.getBackColorByFile();
                if (!appInfo.getImageAdress().Equals(" ")) ribbonPanel1.Style.BackgroundImage = Image.FromFile(appInfo.getImageAdress());
                label1.Font = appInfo.getFont();
                label3.Font = appInfo.getFont();
            }
            catch(Exception e1){ }

            label1.Text = CurrentInfos.RealNameUsageUser;
            label3.Text = CurrentInfos.UserNameUsageUser;
            pictureBox1.ImageLocation = CurrentInfos.IMGUsageUser;
        }

        //change compolete style
        private void Office2007Silver_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver;
            CurrentInfos.IsTheme = true;
        }
        private void Office2007Blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            CurrentInfos.IsTheme = true;
        }
        private void Office2007Black_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            CurrentInfos.IsTheme = true;
        }
        private void Office2007VistaGlass_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            CurrentInfos.IsTheme = true;
        }
        private void Office2010Silver_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            CurrentInfos.IsTheme = true;
        }
        private void Office2010Blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            CurrentInfos.IsTheme = true;

        }
        private void Windows7Blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue;
            CurrentInfos.IsTheme = true;
        }
        private void VisualStudio2010Blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2010Blue;
            CurrentInfos.IsTheme = true;
        }
        private void Metro_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            CurrentInfos.IsTheme = true;
        }
        private void VisualStudio2012Light_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light;
            CurrentInfos.IsTheme = true;

        }
        private void Office2016_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            CurrentInfos.IsTheme = true;
        }
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            new User().ShowDialog();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
