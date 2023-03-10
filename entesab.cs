using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using tvto.tvto2DataSetTableAdapters;

namespace tvto
{
    public partial class entesab : Form
    {
        public entesab()
        {
            InitializeComponent();
        }
        private void afterDoingAction()
        {
            comboBoxCar.Text = "";
            txtDID.Clear();
            txtEID.Clear();
            comboBoxGiven.Text = "";
            comboBoxTaken.Text = "";
            comboBoxUser.Text = "";
            txtEID.Focus();
        }

        private void entesab_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvto2DataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.tvto2DataSet.User);
            // TODO: This line of code loads data into the 'tvto2DataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.tvto2DataSet.Employee);
            // TODO: This line of code loads data into the 'tvto2DataSet.Car' table. You can move, or remove it, as needed.
            this.carTableAdapter.Fill(this.tvto2DataSet.Car);
            // TODO: This line of code loads data into the 'tvto2DataSet.R_car' table. You can move, or remove it, as needed.
            this.r_carTableAdapter.Fill(this.tvto2DataSet.R_car);

                for (int i = 0; i < dataGridViewCar.Rows.Count - 1; i++)
                    comboBoxCar.Items.Add(dataGridViewCar.Rows[i].Cells[0].Value.ToString()+" "+ dataGridViewCar.Rows[i].Cells[1].Value.ToString());

                for (int i = 0; i < dataGridViewE.Rows.Count - 1; i++)
                    comboBoxTaken.Items.Add(dataGridViewE.Rows[i].Cells[0].Value.ToString() + " " + dataGridViewE.Rows[i].Cells[1].Value.ToString());

                for (int i = 0; i < dataGridViewE.Rows.Count - 1; i++)
                    comboBoxGiven.Items.Add(dataGridViewE.Rows[i].Cells[0].Value.ToString() + " " + dataGridViewE.Rows[i].Cells[1].Value.ToString());

            for (int i = 0; i < dataGridViewU.Rows.Count - 1; i++)
                comboBoxUser.Items.Add(dataGridViewE.Rows[i].Cells[0].Value.ToString() + " " + dataGridViewE.Rows[i].Cells[3].Value.ToString());
        }

        private void cleaner_Click(object sender, EventArgs e)
        {
            comboBoxCar.DataBindings.Clear();
            txtDID.DataBindings.Clear();
            txtEID.DataBindings.Clear();
            comboBoxGiven.DataBindings.Clear();
            comboBoxTaken.DataBindings.Clear();
            comboBoxUser.DataBindings.Clear();

            comboBoxCar.Text = "";
            txtDID.Clear();
            txtEID.Clear();
            comboBoxGiven.Text = "";
            comboBoxTaken.Text = "";
            comboBoxUser.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            comboBoxCar.Text = dataGridViewCar.Rows[comboBoxCar.SelectedIndex].Cells[0].Value.ToString();
            if (comboBoxCar.Text != "" && txtDID.Text != "" && txtEID.Text != "" && comboBoxGiven.Text != "" && comboBoxTaken.Text != "" && comboBoxUser.Text != "")
            {
                try
                {
                    if (r_carTableAdapter.ScalarQuery(txtEID.Text) == 0)
                    {
                        r_carTableAdapter.InsertQuery(txtEID.Text, comboBoxGiven.Text, comboBoxCar.Text, txtEID.Text, comboBoxUser.Text, comboBoxTaken.Text);
                        this.r_carTableAdapter.Fill(this.tvto2DataSet.R_car);
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
            else MessageBox.Show("همه موارد را باید پر کنید");
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewrCar.CurrentCell.RowIndex;
            txtDID.Text = dataGridViewrCar.Rows[index].Cells[2].Value.ToString();
            txtEID.Text = dataGridViewrCar.Rows[index].Cells[0].Value.ToString();
            comboBoxCar.Text = dataGridViewrCar.Rows[index].Cells[1].Value.ToString();
            comboBoxGiven.Text = dataGridViewrCar.Rows[index].Cells[4].Value.ToString();
            comboBoxTaken.Text = dataGridViewrCar.Rows[index].Cells[5].Value.ToString();
            comboBoxUser.Text = dataGridViewrCar.Rows[index].Cells[3].Value.ToString();
        }

    }
}
