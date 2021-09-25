using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class InputBox : DevExpress.XtraEditors.XtraForm
{
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.FlowLayoutPanel pnlBotton;
    private DevExpress.XtraEditors.SimpleButton btnOk;
    private DevExpress.XtraEditors.SimpleButton btnNo;
    private System.Windows.Forms.TextBox textValue;

    public InputBox(string msg)
    {
        InitializeComponent();
        lblMessage.Text = msg;
        textValue.Select();
    }
    public InputBox(string msg, string defaulText)
    {
        InitializeComponent();
        lblMessage.Text = msg;
        textValue.Text = defaulText;
        textValue.Select();
    }
    private string _Value;
    public string InputValue
    {
        get
        {
            return _Value;
        }
        set
        {
            _Value = value;
        }
    }

    public void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBox));
            this.lblMessage = new System.Windows.Forms.Label();
            this.textValue = new System.Windows.Forms.TextBox();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessage.Location = new System.Drawing.Point(7, 155);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMessage.Size = new System.Drawing.Size(331, 18);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textValue
            // 
            this.textValue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textValue.Location = new System.Drawing.Point(7, 12);
            this.textValue.Multiline = true;
            this.textValue.Name = "textValue";
            this.textValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textValue.Size = new System.Drawing.Size(331, 143);
            this.textValue.TabIndex = 3;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnOk);
            this.pnlBotton.Controls.Add(this.btnNo);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(0, 175);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(350, 35);
            this.pnlBotton.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(112, 3);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(233, 29);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "تایید اطلاعات";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNo
            // 
            this.btnNo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.ImageOptions.Image")));
            this.btnNo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnNo.Location = new System.Drawing.Point(7, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(99, 29);
            this.btnNo.TabIndex = 6;
            this.btnNo.Text = "انصراف";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // InputBox
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(350, 210);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.textValue);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.pnlBotton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        _Value = textValue.Text;
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void btnNo_Click(object sender, EventArgs e)
    {
        _Value = "";
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }
}


