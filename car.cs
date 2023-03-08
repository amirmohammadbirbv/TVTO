using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using tvto.tvto2DataSetTableAdapters;

namespace tvto
{
    public partial class car : Form
    {
        public car()
        {
            InitializeComponent();
        }
        private void afterDoingAction()
        {
            txtCID.Clear();
            txtCBate.Clear();
            txtCColor.Clear();
            txtCModel.Clear();
            txtCMotor.Clear();
            txtCshahrBani.Clear();
            txtCShasi.Clear();
            txtCSystem.Clear();
            txtCID.Focus();
        }
        private void car_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvto2DataSet.Car' table. You can move, or remove it, as needed.
            this.carTableAdapter.Fill(this.tvto2DataSet.Car);

        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewX1.CurrentCell.RowIndex;
            txtCShasi.Text = dataGridViewX1.Rows[index].Cells[6].Value.ToString();
            txtCBate.Text = dataGridViewX1.Rows[index].Cells[7].Value.ToString();
            txtCModel.Text = dataGridViewX1.Rows[index].Cells[2].Value.ToString();
            txtCID.Text = dataGridViewX1.Rows[index].Cells[0].Value.ToString();
            txtCshahrBani.Text = dataGridViewX1.Rows[index].Cells[4].Value.ToString();
            txtCSystem.Text = dataGridViewX1.Rows[index].Cells[1].Value.ToString();
            txtCColor.Text = dataGridViewX1.Rows[index].Cells[3].Value.ToString();
            txtCMotor.Text = dataGridViewX1.Rows[index].Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (
                txtCBate.Text != "" &&
                txtCColor.Text != "" &&
                txtCID.Text != "" &&
                txtCModel.Text != "" &&
                txtCMotor.Text != "" &&
                txtCshahrBani.Text != "" &&
                txtCShasi.Text != "" &&
                txtCSystem.Text != ""
                )
            {
                try
                {
                    if (carTableAdapter.IsThereID(txtCID.Text)==0)
                    {
                        carTableAdapter.InsertQuery(txtCID.Text, txtCSystem.Text, txtCModel.Text, txtCColor.Text, txtCshahrBani.Text, txtCMotor.Text, txtCShasi.Text, txtCBate.Text);
                        this.carTableAdapter.Fill(this.tvto2DataSet.Car);
                        afterDoingAction();
                        MessageBox.Show("اطلاعات با موفقیت ثبت شد");
                    }
                    else MessageBox.Show("خودرویی با این آیدی وجود دارد");
                }
                catch (Exception e1)
                {
                    MessageBox.Show("اطلاعات ثبت نشد دلیل : " + e1.Message);
                }
            }
            else { MessageBox.Show("همه موارد را باید پر کنید"); }

        }

        private void cleaner_Click(object sender, EventArgs e)
        {
            txtCBate.DataBindings.Clear();
            txtCColor.DataBindings.Clear();
            txtCID.DataBindings.Clear();
            txtCModel.DataBindings.Clear();
            txtCMotor.DataBindings.Clear();
            txtCshahrBani.DataBindings.Clear();
            txtCShasi.DataBindings.Clear();
            txtCSystem.DataBindings.Clear();

            txtCBate.Clear();
            txtCColor.Clear();
            txtCID.Clear();
            txtCModel.Clear();
            txtCMotor.Clear();
            txtCshahrBani.Clear();
            txtCShasi.Clear();
            txtCSystem.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (
                txtCBate.Text != "" &&
                txtCColor.Text != "" &&
                txtCID.Text != "" &&
                txtCModel.Text != "" &&
                txtCMotor.Text != "" &&
                txtCshahrBani.Text != "" &&
                txtCShasi.Text != "" &&
                txtCSystem.Text != ""
                )
            {
                try
                {
                    if (carTableAdapter.IsThereID(txtCID.Text) == 1)
                    {
                        carTableAdapter.UpdateQuery(txtCSystem.Text,txtCModel.Text,txtCColor.Text,txtCshahrBani.Text,txtCMotor.Text,txtCShasi.Text,txtCBate.Text,txtCID.Text);
                        this.carTableAdapter.Fill(this.tvto2DataSet.Car);
                        afterDoingAction();
                        MessageBox.Show("اطلاعات با موفقیت آپدیت شد");
                    }
                    else MessageBox.Show("خودرویی با این آیدی وجود ندارد");
                }
                catch (Exception e1)
                {
                    MessageBox.Show("اطلاعات آپدیت نشد دلیل : " + e1.Message);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtCID.Text != "")
            {
                try
                {
                    if (carTableAdapter.IsThereID(txtCID.Text) != 0)
                    {
                        carTableAdapter.DeleteQuery(txtCID.Text);
                        afterDoingAction();
                        this.carTableAdapter.Fill(this.tvto2DataSet.Car);
                        MessageBox.Show("خودرو با موفقیت حذف شد");
                    }
                    else MessageBox.Show("همچین خودرویی وجود ندرد");
                }
                catch (Exception e2)
                {
                    MessageBox.Show("\nدر حذف اختلالی وجود دارد" + e2.Message);
                }
            }
            else MessageBox.Show("پاک کردن یک خودرو با توجه به آیدی آن شخص صورت میگیرد لطفا فیلد آیدی را پر کنید");
        }

        private void IDSearch_TextChanged(object sender, EventArgs e)
        {
            if (!(IDSearch.Text == ""))
            {
                try
                {
                    carTableAdapter.FillByID(tvto2DataSet.Car, IDSearch.Text);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else this.carTableAdapter.Fill(this.tvto2DataSet.Car);
        }

        private void SystemSearch_TextChanged(object sender, EventArgs e)
        {
            if (!(SystemSearch.Text == ""))
            {
                try
                {
                    carTableAdapter.FillBySystem(tvto2DataSet.Car, SystemSearch.Text);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else this.carTableAdapter.Fill(this.tvto2DataSet.Car);
        }
    }
}
