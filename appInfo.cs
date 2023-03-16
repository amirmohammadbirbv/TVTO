using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace tvto
{
    internal class AppInfo
    {
        internal AppInfo()
        {
            try
            {
                if (!File.Exists("appInfo.txt"))
                {
                    File.Create("appInfo.txt").Close();
                    File.WriteAllText("appInfo.txt", " " + "\r\n" + " " + "\r\n" + " " + "\r\n" + " ");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //set
        internal void changeFontColor(Color color)
        {
            try
            {
                string[] ARGBCodes = new string[4];
                string[] appLastInfos = new string[4];
                appLastInfos = File.ReadAllLines("appInfo.txt");
                ARGBCodes[0] = color.A.ToString();
                ARGBCodes[1] = color.R.ToString();
                ARGBCodes[2] = color.G.ToString();
                ARGBCodes[3] = color.B.ToString();
                appLastInfos[0] = ARGBCodes[0] + " " + ARGBCodes[1] + " " + ARGBCodes[2] + " " + ARGBCodes[3];
                File.WriteAllText("appInfo.txt", appLastInfos[0] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[1] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[2] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[3]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        internal void changeBackColor(Color color)
        {
            try
            {
                string[] ARGBCodes = new string[4];
                string[] appLastInfos = new string[4];
                appLastInfos = File.ReadAllLines("appInfo.txt");
                ARGBCodes[0] = color.A.ToString();
                ARGBCodes[1] = color.R.ToString();
                ARGBCodes[2] = color.G.ToString();
                ARGBCodes[3] = color.B.ToString();
                appLastInfos[1] = ARGBCodes[0] + " " + ARGBCodes[1] + " " + ARGBCodes[2] + " " + ARGBCodes[3];
                File.WriteAllText("appInfo.txt", appLastInfos[0] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[1] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[2] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[3]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        internal void changeimg(string imgPath)
        {
            try
            {
                string[] appLastInfos = new string[4];
                appLastInfos = File.ReadAllLines("appInfo.txt");
                appLastInfos[2] = imgPath;
                File.WriteAllText("appInfo.txt", appLastInfos[0] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[1] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[2] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[3]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        internal void changeFont(Font font)
        {
            try
            {
                string[] fontItems = new string[2];
                string[] appLastInfos = new string[4];
                fontItems[0] = font.Name;
                fontItems[1] = font.Size.ToString();
                appLastInfos = File.ReadAllLines("appInfo.txt");
                appLastInfos[3] = fontItems[0] + " " + fontItems[1];
                File.WriteAllText("appInfo.txt", appLastInfos[0] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[1] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[2] + "\r\n");
                File.AppendAllText("appInfo.txt", appLastInfos[3]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //get
        internal Color getFontColorByFile()
        {
            try
            {
                string[] allFile = File.ReadAllLines("appInfo.txt");
                    string[] argb = allFile[0].Split(' ');
                    return Color.FromArgb(int.Parse(argb[0]), int.Parse(argb[1]), int.Parse(argb[2]), int.Parse(argb[3]));
            }
            catch (Exception e)
            {
                return Color.FromArgb(255, 0, 0, 0);
            }
        }
        internal Color getBackColorByFile()
        {
            try
            {
                string[] allFile = File.ReadAllLines("appInfo.txt");
                    string[] argb = allFile[1].Split(' ');
                    return Color.FromArgb(int.Parse(argb[0]), int.Parse(argb[1]), int.Parse(argb[2]), int.Parse(argb[3]));
                
            }
            catch (Exception e)
            {
                return Color.FromArgb(255,255, 255, 255);
            }
        }
        internal string getImageAdress()
        {
            try
            {
                string[] allFile = File.ReadAllLines("appInfo.txt");
                    return allFile[2];
            }
            catch (Exception e)
            {
                return " ";
            }
        }
        internal Font getFont()
        {
            try
            {
                string[] allFile = File.ReadAllLines("appInfo.txt");
                    string[] font = allFile[3].Split(' ');
                    float size = float.Parse(font[font.Length - 1]);
                    string fontName = "";
                    for (int i = 0; i < font.Length - 1; i++)
                    {
                        fontName += font[i];
                    }
                    if (size > 24)
                    return new Font(fontName, 24);
                    else return new Font(fontName, size);
            }
            catch (Exception e)
            {
                return new Font("Tahoma", 13);
            }
        }
    }
}
 