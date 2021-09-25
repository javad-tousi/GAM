using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Review
{
    public partial class dlgAddFx : DevExpress.XtraEditors.XtraForm
    {
        public string Formula { set; get; }

        public dlgAddFx()
        {
            InitializeComponent();
            txtBox1.Select();
        }

        private void EditValueChanged(object sender, EventArgs e)
        {
            double txt1 = Numeral.AnyToDouble(txtBox1.Text);
            double txt2 = Numeral.AnyToDouble(txtBox2.Text);
            double txt4 = Numeral.AnyToDouble(txtBox4.Text);
            double txt5 = Numeral.AnyToDouble(txtBox5.Text);
            double txt7 = Numeral.AnyToDouble(txtBox7.Text);

            txtBox3.Text = (txt1 - txt2).ToString();
            txtBox6.Text = (((txt4 * txt5) > (double)25000000000) ? (double)25000 : (double)(txt4 * txt5)/1000000).ToString();
           
            double txt6 = Numeral.AnyToDouble(txtBox6.Text);
            txtBox8.Text = (txt6 - txt7).ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (radioButton1.Checked)
            {
                this.Formula = txtBox3.Text + "=" + txtBox2.Text + "-" + txtBox1.Text;
            }
            if (radioButton2.Checked)
            {
                this.Formula = txtBox8.Text + "=(" + txtBox7.Text + "-" + txtBox6.Text + ")=" + txtBox5.Text + "×" + txtBox4.Text;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = !radioButton1.Checked;
            panel3.Enabled = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
            panel4.Enabled = radioButton2.Checked;
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
