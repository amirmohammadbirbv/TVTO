using System;
using System.Collections;
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
    public partial class entesab : Form
    {
        public entesab()
        {
            InitializeComponent();
        }

        private void afterDoingAction()
        {
            txtCID.Clear();
            txtDID.Clear();
            txtEID.Clear();
            txtGID.Clear();
            txtTID.Clear();
            txtUID.Clear();
            txtCID.Focus();
        }

        private void entesab_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvto2DataSet.R_car' table. You can move, or remove it, as needed.
            this.r_carTableAdapter.Fill(this.tvto2DataSet.R_car);
        }

        private void cleaner_Click(object sender, EventArgs e)
        {
            txtCID.DataBindings.Clear();
            txtDID.DataBindings.Clear();
            txtEID.DataBindings.Clear();
            txtGID.DataBindings.Clear();
            txtTID.DataBindings.Clear();
            txtUID.DataBindings.Clear();

            txtCID.Clear();
            txtDID.Clear();
            txtEID.Clear();
            txtGID.Clear();
            txtTID.Clear();
            txtUID.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCID.Text != "" && txtDID.Text != "" && txtEID.Text != "" && txtGID.Text != "" && txtTID.Text != "" && txtUID.Text != "")
            {
                try
                {
                    if (r_carTableAdapter.ScalarQuery(txtEID.Text) == 0)
                    {
                        r_carTableAdapter.InsertQuery(txtEID.Text, txtGID.Text, txtCID.Text, txtEID.Text,txtUID.Text,txtTID.Text);
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
            try
            {
                //this.r_carTableAdapter.FillBy(this.tvto2DataSet.R_car);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
