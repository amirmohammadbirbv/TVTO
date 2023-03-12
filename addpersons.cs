using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace tvto
{
    public partial class addPerson : Form
    {
        public addPerson()
        {
            InitializeComponent();
        }
        private void afterDoingAction()
        {
            txtID.Clear();
            txtName.Clear();
            txtFamily.Clear();
            txtNCode.Clear();
            txtMobile.Clear();
            txtTel.Clear();
            txtAddres.Clear();
            txte_mail.Clear();
            txtName.Focus();
        }
        private bool isvalidEmail(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;

            }
            catch
            {
                MessageBox.Show(
                    Text = "ایمیل معتبر نیست",
                    Name = "مشکل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }
        private bool isValidCode()
        {
            if (txtNCode.Text.Length != 10 || txtMobile.Text.Length != 11)
            {
                MessageBox.Show(
                    Text = "کد ملی یا موبایل معتبر نیست",
                    Name = "مشکل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
            else return true;
        }
        private void addpersons_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvto2DataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.tvto2DataSet.Employee);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (
                txtAddres.Text != "" &&
                txte_mail.Text != "" &&
                txtFamily.Text != "" &&
                txtID.Text != "" &&
                txtMobile.Text != "" &&
                txtName.Text != "" &&
                txtNCode.Text != "" &&
                txtTel.Text != ""
                )
            {
                if (isvalidEmail(txte_mail.Text) && isValidCode())
                {
                    try
                    {
                        if (employeeTableAdapter.CHECKISTHERE(txtID.Text) == 0)
                        {
                            employeeTableAdapter.InsertQuery(txtID.Text, txtName.Text, txtFamily.Text, txtNCode.Text, txtMobile.Text, txtTel.Text, txtAddres.Text, txte_mail.Text);
                            this.employeeTableAdapter.Fill(this.tvto2DataSet.Employee);
                            afterDoingAction();
                            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
                        }
                        else MessageBox.Show("کاربری با این آیدی وجود دارد");
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("اطلاعات ثبت نشد دلیل : " + e1.Message);
                    }
                }

            }
            else MessageBox.Show("همه موارد را باید پر کنید");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (
                txtAddres.Text != "" &&
                txte_mail.Text != "" &&
                txtFamily.Text != "" &&
                txtID.Text != "" &&
                txtMobile.Text != "" &&
                txtName.Text != "" &&
                txtNCode.Text != "" &&
                txtTel.Text != "" &&
                isvalidEmail(txte_mail.Text) &&
                isValidCode()
                )
            {
                try
                {
                    if (employeeTableAdapter.CHECKISTHERE(txtID.Text) == 1)
                    {
                        employeeTableAdapter.UpdateQuery( txtName.Text, txtFamily.Text, txtNCode.Text, txtMobile.Text, txtTel.Text, txtAddres.Text, txte_mail.Text, txtID.Text);
                        this.employeeTableAdapter.Fill(this.tvto2DataSet.Employee);
                        afterDoingAction();
                        MessageBox.Show("اطلاعات با موفقیت آپدیت شد");
                    }
                    else MessageBox.Show("کاربری با این آیدی وجود ندارد");
                }
                catch (Exception e1)
                {
                    MessageBox.Show("اطلاعات آپدیت نشد دلیل : " + e1.Message);
                }
            }
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridEmployee.CurrentCell.RowIndex;
            txtAddres.Text = dataGridEmployee.Rows[index].Cells[6].Value.ToString();
            txte_mail.Text = dataGridEmployee.Rows[index].Cells[7].Value.ToString();
            txtFamily.Text = dataGridEmployee.Rows[index].Cells[2].Value.ToString();
            txtID.Text = dataGridEmployee.Rows[index].Cells[0].Value.ToString();
            txtMobile.Text = dataGridEmployee.Rows[index].Cells[4].Value.ToString();
            txtName.Text = dataGridEmployee.Rows[index].Cells[1].Value.ToString();
            txtNCode.Text = dataGridEmployee.Rows[index].Cells[3].Value.ToString();
            txtTel.Text = dataGridEmployee.Rows[index].Cells[5].Value.ToString();
        }

        private void cleaner_Click(object sender, EventArgs e)
        {
            txtAddres.DataBindings.Clear();
            txte_mail.DataBindings.Clear();
            txtFamily.DataBindings.Clear();
            txtID.DataBindings.Clear();
            txtMobile.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtNCode.DataBindings.Clear();
            txtTel.DataBindings.Clear();

            txtAddres.Clear();
            txte_mail.Clear();
            txtFamily.Clear();
            txtID.Clear();
            txtMobile.Clear();
            txtName.Clear();
            txtNCode.Clear();
            txtTel.Clear();
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
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

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            txtTel_KeyDown(sender,e);
        }

        private void txtNCode_KeyDown(object sender, KeyEventArgs e)
        {
            txtTel_KeyDown(sender, e);
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            txtTel_KeyDown(sender, e);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (!(codeSearch.Text == ""))
            {
                try
                {
                    employeeTableAdapter.FillByID(tvto2DataSet.Employee, codeSearch.Text);
                }
                catch (Exception e1) 
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else this.employeeTableAdapter.Fill(this.tvto2DataSet.Employee);
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            if (!(nameSearch.Text == ""))
            {
                try
                {
                    employeeTableAdapter.FillByname(tvto2DataSet.Employee, nameSearch.Text);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else this.employeeTableAdapter.Fill(this.tvto2DataSet.Employee);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                try
                {
                    if (employeeTableAdapter.CHECKISTHERE(txtID.Text) != 0)
                    {
                        employeeTableAdapter.DeleteQuery(txtID.Text);
                        afterDoingAction();
                        this.employeeTableAdapter.Fill(this.tvto2DataSet.Employee);
                        MessageBox.Show("کاربر با موفقیت حذف شد");
                    }
                    else MessageBox.Show("همچین کاربری وجود ندرد");
                }
                catch (Exception e2)
                {
                    MessageBox.Show("\nدر حذف اختلالی وجود دارد"+e2.Message);
                }
            }
            else MessageBox.Show("پاک کردن یک فرد با توجه به آیدی آن شخص صورت میگیرد لطفا فیلد آیدی را پر کنید");
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!
                (char.IsLetter((char)e.KeyCode) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Space))||
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
                (e.KeyCode == Keys.Add)||
                (e.KeyCode == Keys.OemMinus)))
                e.SuppressKeyPress = true;
        }

        private void txtFamily_KeyDown(object sender, KeyEventArgs e)
        {
            txtName_KeyDown(sender,e);
        }

        private void txte_mail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
