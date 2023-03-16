using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tvto.tvto2DataSetTableAdapters;

namespace tvto
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            login_Load(sender,e);
        }
        private void login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvto2DataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.tvto2DataSet.User);
            System.Globalization.PersianCalendar dtePersianCalendar = new System.Globalization.PersianCalendar();
            System.String Year, Month, Day, strResult;
            DateTime Date_Now = DateTime.Now;
            Year = dtePersianCalendar.GetYear(Date_Now).ToString();
            Month = dtePersianCalendar.GetMonth(Date_Now).ToString();
            Day = dtePersianCalendar.GetDayOfMonth(Date_Now).ToString();
            strResult = Year + "/" + Month + "/" + Day;
            buttonX1.Text = strResult;
            timer1.Start();
            if (dataGridViewX1.RowCount-1 > 0) buttonX5.Enabled = false;
            buttonX2.Text = DateTime.Now.ToLongTimeString();
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPass.Text != "")
            {
                try
                {
                    if (userTableAdapter.CanLogin(txtUserName.Text, txtPass.Text) == 1)
                    {
                        for (int i = 0; i < dataGridViewX1.RowCount; i++)
                        {
                            if (txtUserName.Text.Equals(dataGridViewX1.Rows[i].Cells[0].Value))
                            {
                                CurrentInfos.UserNameUsageUser = dataGridViewX1.Rows[i].Cells[0].Value.ToString();
                                CurrentInfos.RealNameUsageUser = dataGridViewX1.Rows[i].Cells[2].Value.ToString();
                                CurrentInfos.IMGUsageUser = dataGridViewX1.Rows[i].Cells[3].Value.ToString();
                            }
                        }
                        timer1.Stop();
                        Form1 form1 = new Form1();
                        form1.Show();
                        Hide();
                    }
                    else MessageBox.Show("نام کاربری یا رمز ورود معتبر نیست");
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else MessageBox.Show("هردو فیلد را پر کنید");
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.btnRemove.Enabled = false;
            user.ShowDialog();
        }
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxX1.Checked)
            {
                txtPass.PasswordChar = '*';
                checkBoxX1.Text = "نمایش رمز";
            }
            else
            {
                txtPass.PasswordChar = '\0';
                checkBoxX1.Text = "مخفی کردن رمز";
            }
        }
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) buttonX3_Click_1(sender, e);
        }
    }
}
