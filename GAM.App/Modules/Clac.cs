using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Calc : System.Windows.Forms.Form
{
    string operation = string.Empty;
    bool DivideByZero = false;
    bool ModuludOfZero = false;
    public string ResultValue { get; set; }
    private Button btnModules;
    private Button btnEquals;
    public Calc()
    {
        InitializeComponent();
    }


    private void btn0_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "0";
    }

    private void btn1_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "1";
    }

    private void btn2_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "2";
    }

    private void btn3_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "3";
    }

    private void btn6_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "6";
    }

    private void btn5_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "5";
    }

    private void btn4_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "4";
    }

    private void btn9_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "9";
    }

    private void btn8_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "8";
    }

    private void btn7_Click(object sender, EventArgs e)
    {
        txtResult.Text = txtResult.Text + "7";
    }

    private void btnPoint_Click(object sender, EventArgs e)
    {
        int counter = 0;
        if (txtResult.Text != "")
        {
            //Calculations();
            if (txtResult.Text[txtResult.Text.Length - 1] != '.')
            {
                char[] signs = { '/', '*', '-', '+', '%' };
                foreach (char c in signs)
                {
                    if (txtResult.Text.Contains(c))
                    {
                        //int index = txtResult.Text.LastIndexOf(c);
                        string[] SignSplitted = txtResult.Text.Split(c);
                        //if (!txtResult.Text.Substring(index, txtResult.Text.Length - 1).Contains('.'))
                        //{
                        counter++;
                        if (!SignSplitted[1].Contains('.'))
                            txtResult.Text = txtResult.Text + ".";
                        //}
                    }
                }
                if (counter == 0)
                {
                    if (!txtResult.Text.Contains('.'))
                        txtResult.Text = txtResult.Text + ".";
                }
            }
        }
        else
        {
            txtResult.Text = txtResult.Text + "0.";
        }
    }

    private void btnPlus_Click(object sender, EventArgs e)
    {
        string bkp = string.Empty;
        if (txtResult.Text != string.Empty)
        {
            if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("+"))
            {
                Calculations();
                if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("-") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                {
                    bkp = RemoveLastChar(txtResult.Text);
                    txtResult.Text = bkp + "+";
                }
                else
                {
                    if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "+";
                }
            }
        }
        operation = "plus";
    }

    private void btnMinus_Click(object sender, EventArgs e)
    {
        string bkp = string.Empty;
        if (txtResult.Text != string.Empty)
        {
            //  num1 = float.Parse(txtResult.Text);
            if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("-"))
            {
                Calculations();
                if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                {
                    bkp = RemoveLastChar(txtResult.Text);
                    txtResult.Text = bkp + "-";
                }
                else
                {
                    if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "-";
                    //txtExpression.Text = txtExpression.Text + txtResult.Text;
                }
            }
            operation = "minus";
        }
    }

    private void btnMultiply_Click(object sender, EventArgs e)
    {
        string bkp = string.Empty;
        if (txtResult.Text != string.Empty)
        {
            Calculations();
            if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("*"))
            {
                if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("-") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                {
                    bkp = RemoveLastChar(txtResult.Text);
                    txtResult.Text = bkp + "*";
                }
                else
                {
                    if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "*";
                    //txtExpression.Text = txtExpression.Text + txtResult.Text;
                }
            }
        }
        operation = "multiply";
    }

    private void btnDivide_Click(object sender, EventArgs e)
    {
        string bkp = string.Empty;
        if (txtResult.Text != string.Empty)
        {
            Calculations();
            if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("/"))
            {
                if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                {
                    bkp = RemoveLastChar(txtResult.Text);
                    txtResult.Text = bkp + "/";
                }
                else
                {
                    if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "/";
                    //txtExpression.Text = txtExpression.Text + txtResult.Text;
                }
            }
        }
        operation = "divide";
    }

    private void btnEquals_Click(object sender, EventArgs e)
    {
        Calculations();
        this.ResultValue = txtResult.Text;
        this.Close();
    }

    private void btnC_Click(object sender, EventArgs e)
    {
        txtResult.Text = string.Empty;
    }

    private void btnBkpSpace_Click(object sender, EventArgs e)
    {
        string bkp = RemoveLastChar(txtResult.Text);
        txtResult.Text = bkp;
    }

    public string RemoveLastChar(string fulltext)
    {
        string bkp = string.Empty;
        char[] text = fulltext.ToCharArray();
        for (int i = 0; i < text.Length - 1; i++)
        {
            bkp += text[i];
        }
        return bkp;
    }

    private void btnModules_Click(object sender, EventArgs e)
    {
        string bkp = string.Empty;
        if (txtResult.Text != "")
        {
            Calculations();
            if (txtResult.Text[txtResult.Text.Length - 1] != '%')
            {
                if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("-") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+"))
                {
                    bkp = RemoveLastChar(txtResult.Text);
                    txtResult.Text = bkp + "%";
                }
                else
                {
                    if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "%";
                    //txtExpression.Text = txtExpression.Text + txtResult.Text;
                }
            }
        }
        operation = "modulus";
    }

    public long CalculateIntegerResult(string operation, long num1, long num2)
    {
        long resut = 0;
        try
        {
            if (txtResult.Text.Contains("+") || txtResult.Text.Contains("-") || txtResult.Text.Contains("*") || txtResult.Text.Contains("/") || txtResult.Text.Contains("%"))
            {
                switch (operation)
                {
                    case "plus":
                        resut = num1 + num2;
                        break;
                    case "minus":
                        resut = num1 - num2;
                        break;
                    case "multiply":
                        resut = num1 * num2;
                        break;
                    case "divide":
                        resut = num1 / num2;
                        break;
                    case "modulus":
                        resut = num1 % num2;
                        break;
                    default:
                        break;
                }
            }
            return resut;
        }
        catch
        {
            return resut;
        }
    }

    public float CalculateFloatResult(string operation, float num1, float num2)
    {
        float resut = 0;
        try
        {
            if (txtResult.Text.Contains("+") || txtResult.Text.Contains("-") || txtResult.Text.Contains("*") || txtResult.Text.Contains("/") || txtResult.Text.Contains("%"))
            {
                switch (operation)
                {
                    case "plus":
                        resut = num1 + num2;
                        break;
                    case "minus":
                        resut = num1 - num2;
                        break;
                    case "multiply":
                        resut = num1 * num2;
                        break;
                    case "divide":
                        resut = num1 / num2;
                        break;
                    case "modulus":
                        if (num2 != 0.0)
                            resut = num1 % num2;
                        else
                            MessageBox.Show("Cannot find Modulus of Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            return resut;
        }
        catch
        {
            return resut;
        }
    }

    public void Calculations()
    {
        try
        {
            if (txtResult.Text.Contains('+'))
            {
                string[] splitted = txtResult.Text.Split('+');
                if (splitted[1] != "")
                {
                    if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                    {
                        float floatResult = CalculateFloatResult("plus", float.Parse(splitted[0]), float.Parse(splitted[1]));
                        txtResult.Text = Convert.ToString(floatResult);
                    }
                    else
                    {
                        long rr = CalculateIntegerResult("plus", long.Parse(splitted[0]), long.Parse(splitted[1]));
                        txtResult.Text = Convert.ToString(rr);
                    }
                }
            }
            if (txtResult.Text.Contains('-'))
            {
                string[] splitted = txtResult.Text.Split('-');
                if (splitted[1] != "")
                {
                    if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                    {
                        float floatResult = CalculateFloatResult("minus", float.Parse(splitted[0]), float.Parse(splitted[1]));
                        txtResult.Text = Convert.ToString(floatResult);
                    }
                    else
                    {
                        long rr = CalculateIntegerResult("minus", long.Parse(splitted[0]), long.Parse(splitted[1]));
                        txtResult.Text = Convert.ToString(rr);
                    }
                }
            }
            if (txtResult.Text.Contains('*'))
            {
                string[] splitted = txtResult.Text.Split('*');
                if (splitted[1] != "")
                {
                    if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                    {
                        float floatResult = CalculateFloatResult("multiply", float.Parse(splitted[0]), float.Parse(splitted[1]));
                        txtResult.Text = Convert.ToString(floatResult);
                    }
                    else
                    {
                        long rr = CalculateIntegerResult("multiply", long.Parse(splitted[0]), long.Parse(splitted[1]));
                        txtResult.Text = Convert.ToString(rr);
                    }
                }
            }
            if (txtResult.Text.Contains('/'))
            {
                string[] splitted = txtResult.Text.Split('/');
                if (splitted[1] != "")
                {
                    if (!splitted[1].Contains('.'))
                    {
                        if (Convert.ToInt32(splitted[1]) != 0)
                        {
                            if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                            {
                                float floatResult = CalculateFloatResult("divide", float.Parse(splitted[0]), float.Parse(splitted[1]));
                                txtResult.Text = Convert.ToString(floatResult);
                            }
                            else
                            {
                                long rr = CalculateIntegerResult("divide", long.Parse(splitted[0]), long.Parse(splitted[1]));
                                txtResult.Text = Convert.ToString(rr);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DivideByZero = true;
                        }
                    }
                    else
                    {
                        if (float.Parse(splitted[1]) != 0)
                        {
                            if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                            {
                                float floatResult = CalculateFloatResult("divide", float.Parse(splitted[0]), float.Parse(splitted[1]));
                                txtResult.Text = Convert.ToString(floatResult);
                            }
                            else
                            {
                                long rr = CalculateIntegerResult("divide", long.Parse(splitted[0]), long.Parse(splitted[1]));
                                txtResult.Text = Convert.ToString(rr);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DivideByZero = true;
                        }
                    }
                }
            }
            if (txtResult.Text.Contains('%'))
            {
                string[] splitted = txtResult.Text.Split('%');
                if (splitted[1] != "")
                {
                    if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                    {
                        float floatResult = CalculateFloatResult("modulus", float.Parse(splitted[0]), float.Parse(splitted[1]));
                        txtResult.Text = Convert.ToString(floatResult);
                    }
                    else
                    {
                        if (Convert.ToInt32(splitted[1]) == 0)
                        {
                            MessageBox.Show("Cannot find Modulus of Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ModuludOfZero = true;
                        }
                        else
                        {
                            long rr = CalculateIntegerResult("modulus", long.Parse(splitted[0]), long.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(rr);
                        }
                    }
                }
            }
        }
        catch
        {

        }
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnBkpSpace = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnPoint = new System.Windows.Forms.Button();
            this.btnModules = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(3, 174);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(35, 35);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(44, 174);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(35, 35);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(85, 174);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(35, 35);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(3, 133);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(35, 35);
            this.btn4.TabIndex = 4;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(44, 133);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(35, 35);
            this.btn5.TabIndex = 5;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(85, 133);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(35, 35);
            this.btn6.TabIndex = 6;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(3, 92);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(35, 35);
            this.btn7.TabIndex = 7;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(44, 92);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(35, 35);
            this.btn8.TabIndex = 8;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(85, 92);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(35, 35);
            this.btn9.TabIndex = 9;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Location = new System.Drawing.Point(126, 53);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(35, 35);
            this.btnPlus.TabIndex = 10;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinus.Location = new System.Drawing.Point(126, 92);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(35, 35);
            this.btnMinus.TabIndex = 11;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiply.Location = new System.Drawing.Point(126, 133);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(35, 35);
            this.btnMultiply.TabIndex = 12;
            this.btnMultiply.Text = "X";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivide.Location = new System.Drawing.Point(126, 174);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(35, 35);
            this.btnDivide.TabIndex = 13;
            this.btnDivide.Text = "÷";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // btnC
            // 
            this.btnC.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.btnC.Location = new System.Drawing.Point(85, 54);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(35, 35);
            this.btnC.TabIndex = 15;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(3, 215);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(35, 35);
            this.btn0.TabIndex = 16;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btnBkpSpace
            // 
            this.btnBkpSpace.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.btnBkpSpace.Location = new System.Drawing.Point(3, 54);
            this.btnBkpSpace.Name = "btnBkpSpace";
            this.btnBkpSpace.Size = new System.Drawing.Size(76, 35);
            this.btnBkpSpace.TabIndex = 18;
            this.btnBkpSpace.Text = "Backspace";
            this.btnBkpSpace.UseVisualStyleBackColor = true;
            this.btnBkpSpace.Click += new System.EventHandler(this.btnBkpSpace_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtResult);
            this.panel1.Location = new System.Drawing.Point(3, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 38);
            this.panel1.TabIndex = 20;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Menu;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResult.Enabled = false;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(3, 8);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(154, 19);
            this.txtResult.TabIndex = 19;
            // 
            // btnPoint
            // 
            this.btnPoint.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoint.Location = new System.Drawing.Point(44, 215);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(35, 35);
            this.btnPoint.TabIndex = 21;
            this.btnPoint.Text = ".";
            this.btnPoint.UseVisualStyleBackColor = true;
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // btnModules
            // 
            this.btnModules.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModules.Location = new System.Drawing.Point(123, 216);
            this.btnModules.Name = "btnModules";
            this.btnModules.Size = new System.Drawing.Size(35, 35);
            this.btnModules.TabIndex = 22;
            this.btnModules.Text = "%";
            this.btnModules.UseVisualStyleBackColor = true;
            this.btnModules.Visible = false;
            this.btnModules.Click += new System.EventHandler(this.btnModules_Click);
            // 
            // btnEquals
            // 
            this.btnEquals.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquals.Location = new System.Drawing.Point(85, 215);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(76, 35);
            this.btnEquals.TabIndex = 23;
            this.btnEquals.Text = "=";
            this.btnEquals.UseVisualStyleBackColor = true;
            this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
            // 
            // Calc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 254);
            this.ControlBox = false;
            this.Controls.Add(this.btnEquals);
            this.Controls.Add(this.btnModules);
            this.Controls.Add(this.btnPoint);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBkpSpace);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.MaximizeBox = false;
            this.Name = "Calc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btn1;
    private System.Windows.Forms.Button btn2;
    private System.Windows.Forms.Button btn3;
    private System.Windows.Forms.Button btn4;
    private System.Windows.Forms.Button btn5;
    private System.Windows.Forms.Button btn6;
    private System.Windows.Forms.Button btn7;
    private System.Windows.Forms.Button btn8;
    private System.Windows.Forms.Button btn9;
    private System.Windows.Forms.Button btnPlus;
    private System.Windows.Forms.Button btnMinus;
    private System.Windows.Forms.Button btnMultiply;
    private System.Windows.Forms.Button btnDivide;
    private System.Windows.Forms.Button btnC;
    private System.Windows.Forms.Button btn0;
    private System.Windows.Forms.Button btnBkpSpace;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnPoint;
    private System.Windows.Forms.TextBox txtResult;

}