using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public partial class MoneyBox : TextBox
    {
        public MoneyBox()
        {
            MaxLength = 25;
            defaultZero = true;
        }

        Int64 Numbers;
        int startSelection;
        int numbersLength;
        string TextStream;
        private bool enterToNextControl;
        private bool disableOnTextChanged;


        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (this.TextLength > 0 & !this.disableOnTextChanged)
            {
                if (GetNumbers(this.Text) != null)
                {
                    Numbers = Int64.Parse(GetNumbers(this.Text));
                    TextStream = Numbers.ToString("N0");

                    int Num = this.TextLength - numbersLength;
                    try
                    {
                        this.SelectionStart = startSelection + Num;
                    }
                    catch
                    {
                    }
                    this.Text = TextStream;
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.BackColor = defaultBackColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.BackColor = defaultBackColor;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.disableOnTextChanged = false;

            if (enterToNextControl)
            {
                if (e.KeyData == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }

            if (!this.ReadOnly)
            {
                numbersLength = this.TextLength;
                startSelection = this.SelectionStart + 1;

                if ((this.SelectionLength == this.TextLength) & (e.KeyData == Keys.Delete | e.KeyData == Keys.Back))
                {
                    TextStream = "";
                    this.Clear();
                    this.SelectionStart = 1;
                }

                if (this.TextLength == 1 & (e.KeyData == Keys.Delete | e.KeyData == Keys.Back))
                {
                    TextStream = "";
                    this.Clear();
                    this.SelectionStart = 1;
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!this.ReadOnly)
            {
                this.BackColor = defaultBackColor;

                if (!char.IsControl(e.KeyChar) && !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9+-]"))
                {
                    this.BackColor = Color.LightPink;
                    e.Handled = true;
                }

                // Accept this chars
                if (acceptedChars != null)
                {
                    if (acceptedChars.Contains(e.KeyChar.ToString()))
                    {
                        this.BackColor = defaultBackColor;
                        e.Handled = false;
                    }
                }

                if (_numberFormat == NumberFormatEnum.PositiveAndNegative | _numberFormat == NumberFormatEnum.Financial)
                {
                    if (e.KeyChar == '-')
                    {
                        this.ForeColor = Color.Red;
                        IsNegative = true;
                    }
                    if (e.KeyChar == '+')
                    {
                        this.ForeColor = Color.Green;
                        IsNegative = false;
                    }
                }

                if (e.KeyChar == '-' | e.KeyChar == '+' | e.KeyChar == '/')
                {
                    e.Handled = true;
                }
            }
        }

        public static string GetNumbers(string str)
        {
            if (str.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                foreach (char c in str)
                {
                    if (Char.IsDigit(c))
                    {
                        sb.Append(c);
                    }
                }
                if (sb.ToString().Length > 0)
                    return sb.ToString();
                else
                    return null;
            }

            return null;
        }

        public Decimal Value
        {
            get
            {
                if (GetNumbers(this.Text) != null)
                {
                    return Decimal.Parse(GetNumbers(this.Text));
                }
                else
                {
                    return -1;
                }
            }
        }

        [Description("Go to next control by ENTER key")]
        [DefaultValue(false)]
        public bool EnterToNextControl
        {
            set { enterToNextControl = value; }
            get { return enterToNextControl; }
        }

        [Description("Suport +/- chars")]
        public enum NumberFormatEnum { Amount, PositiveAndNegative, Financial };

        private NumberFormatEnum _numberFormat;
        [DefaultValue(NumberFormatEnum.Amount)]
        public NumberFormatEnum NumberFormat
        {
            get
            {
                return _numberFormat;
            }
            set
            {
                _numberFormat = value;
            }
        }

        private bool IsNegative { get; set; }

        private string acceptedChars;
        private Drawing.Color defaultBackColor;

        public string AcceptedChars
        {
            set { acceptedChars = value; }
            get { return acceptedChars; }
        }

        private bool defaultZero;
        [DefaultValue(true)]
        public bool DefaultZero
        {
            set
            {
                if (value)
                {
                    defaultZero = value;
                    TextStream = "";
                    this.Text = "0";
                }
                else
                {
                    defaultZero = value;
                    TextStream = "";
                    this.Clear();
                }
            }
            get { return defaultZero; }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BackColor = defaultBackColor;
            if (_numberFormat == NumberFormatEnum.PositiveAndNegative & this.TextLength > 0)
            {
                this.disableOnTextChanged = true;
                if (IsNegative)
                    this.Text = "-" + TextStream;
                else
                {
                    this.Text = "+" + TextStream;
                    this.ForeColor = Color.Green;
                }
            }
            if (_numberFormat == NumberFormatEnum.Financial & this.TextLength > 0 & Value > 0)
            {
                this.disableOnTextChanged = true;
                if (IsNegative)
                    this.Text = "(" + TextStream + ")";
                else
                    this.Text = TextStream;
            }

            if (defaultZero == true & this.TextLength == 0)
            {
                TextStream = "";
                this.Text = "0";
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            defaultBackColor = this.BackColor;
            if (!this.ReadOnly)
            {
                this.SelectAll();
            }
            if (defaultZero == true & this.TextLength == 0)
            {
                TextStream = "";
                this.Text = "0";
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MoneyBox
            // 
            this.ShortcutsEnabled = false;
            this.ResumeLayout(false);

        }
    }
}