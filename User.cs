using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace tvto
{
    public partial class User : Form
    {
        private void afterDoingAction()
        {
            txtpass.Clear();
            txtpassrepeat.Clear();
            txtusername.Clear();
            realname.Clear();
            openFileDialog1.Reset();
            txtusername.Focus();
        }
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvto2DataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.tvto2DataSet.User);
            AppInfo appInfo = new AppInfo();
            foreach (Control c in this.Controls)
            {
                c.BackColor = appInfo.getBackColorByFile();
                c.ForeColor = appInfo.getFontColorByFile();
            }
        }
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxX1.Checked)
            {
                txtpass.PasswordChar = '*';
                txtpassrepeat.PasswordChar = '*';
                checkBoxX1.Text = "نمایش رمز";
            }
            else
            {
                txtpass.PasswordChar = '\0';
                txtpassrepeat.PasswordChar = '\0';
                checkBoxX1.Text = "مخفی کردن رمز";
            }
        }

        private void txtid_KeyDown(object sender, KeyEventArgs e)
        {
            if (
                !(char.IsDigit((char)e.KeyCode) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.NumPad0) ||
                (e.KeyCode == Keys.NumPad1) ||
                (e.KeyCode == Keys.NumPad2) ||
                (e.KeyCode == Keys.NumPad3) ||
                (e.KeyCode == Keys.NumPad4) ||
                (e.KeyCode == Keys.NumPad5) ||
                (e.KeyCode == Keys.NumPad6) ||
                (e.KeyCode == Keys.NumPad7) ||
                (e.KeyCode == Keys.NumPad8) ||
                (e.KeyCode == Keys.NumPad9))
                )
                e.SuppressKeyPress = true;
        }

        private void realname_KeyDown(object sender, KeyEventArgs e)
        {
            if (!
                (char.IsLetter((char)e.KeyCode) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Space)) ||
                ((e.KeyCode == Keys.NumPad0) ||
                (e.KeyCode == Keys.NumPad1) ||
                (e.KeyCode == Keys.NumPad2) ||
                (e.KeyCode == Keys.NumPad3) ||
                (e.KeyCode == Keys.NumPad4) ||
                (e.KeyCode == Keys.NumPad5) ||
                (e.KeyCode == Keys.NumPad6) ||
                (e.KeyCode == Keys.NumPad7) ||
                (e.KeyCode == Keys.NumPad8) ||
                (e.KeyCode == Keys.NumPad9) ||
                (e.KeyCode == Keys.Add) ||
                (e.KeyCode == Keys.OemMinus)))
                e.SuppressKeyPress = true;
        }
        string imgAddress = "";
        private void buttonX1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "ImageFile(*.BMP;*.jpg;*.PNG)|*.BMP;*.jpg;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) imgAddress = openFileDialog1.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(txtusername.Text == "" || txtpass.Text == "" || txtpassrepeat.Text == "" || realname.Text == "" || imgAddress == ""))
            {
                if (txtpass.Text.Equals(txtpassrepeat.Text))
                {
                    try
                    {
                        if (userTableAdapter.ScalarQuery(txtusername.Text) == 0)
                        {
                            userTableAdapter.InsertQuery(txtusername.Text,txtpass.Text.ToLower(),realname.Text,imgAddress);
                            MessageBox.Show("کاربر با موففیت وارد شد");
                            afterDoingAction();
                        }
                        else MessageBox.Show("این  نام کاربری وحود دارد");
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(": مشکلی وجود دارد" + e1.Message);
                    }
                }
                else MessageBox.Show("رمز را اشتباه وارد کردید");
            }
            else MessageBox.Show("لطفا همه فیلد ها را پر کنید");
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text.Length < 8)
            {
                btnAdd.Enabled = false;
            }
            else btnAdd.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "" && txtpass.Text != "")
            {
                try
                {
                    if (userTableAdapter.CanLogin(txtusername.Text, txtpass.Text.ToLower()) ==1)
                    {
                        userTableAdapter.DeleteQuery(txtusername.Text, txtpass.Text.ToLower());
                        MessageBox.Show("کاربر با موفقیت حذف شد");
                    }
                    else MessageBox.Show("نام کاربری یا رمز استباه است");
                }
                catch (Exception e1)
                {
                    MessageBox.Show(": مشکلی وجود دارد" + e1.Message);
                }
            }
            else MessageBox.Show("برای حذف کاربر باید نام کاربری و رمز کاربر را وارد کنید");
        }
    }
}
