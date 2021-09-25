using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;

namespace System.Windows.Forms.CustomControls
{
    public class FilterdTextBox : TextBox
    {
        public enum FilteredEnum
        {
            AllChars, Numeric, Digits, DigitsAndOperators, EnglishChars, PersianChars, EnglishAndDigits, PersianAndDigits, EnglishAndAllChars, PersianAndAllChars, EnglishAndDigitsAndOperators, PersianAndDigitsAndOperators
        }

        public enum LanguageEnum
        {
            NoChange, Farsi, English 
        }

        private Color backColorUsed;
        private FilteredEnum typeOfInput;
        private LanguageEnum language;
        private Color backColoronErr;
        private string acceptedChars = "";
        private bool zeroDefault;
        private bool enterToNextControl;
        // Windows message constants
        const int WM_SETFOCUS = 7;
        const int WM_KILLFOCUS = 8;
        const int WM_ERASEBKGND = 14;
        const int WM_PAINT = 15;

        // private internal variables
        private bool _focusSelect = true;
        private bool _drawPrompt = true;
        private string _promptText = String.Empty;
        private Color _promptColor = Color.Gray;
        private Font _promptFont = null;

        /// <summary>
        /// When the textbox receives an OnEnter event, select all the text if any text is present
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            if (this.Text.Length > 0 && _focusSelect)
                this.SelectAll();
            if (language == LanguageEnum.Farsi)
            {
                ToFarsiLanguage();
            }
            if (language == LanguageEnum.English)
            {
                ToEnglishLanguage();
            }
            base.OnEnter(e);
        }

        /// <summary>
        /// Redraw the control when the text alignment changes
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextAlignChanged(EventArgs e)
        {
            base.OnTextAlignChanged(e);
            this.Invalidate();
        }

        /// <summary>
        /// Redraw the control with the prompt
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>This event will only fire if ControlStyles.UserPaint is set to true in the constructor</remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Only draw the prompt in the OnPaint event and when the Text property is empty
            if (_drawPrompt && this.Text.Length == 0)
                DrawTextPrompt(e.Graphics);
        }


        /// <summary>
        /// Overrides the default WndProc for the control
        /// </summary>
        /// <param name="m">The Windows message structure</param>
        /// <remarks>
        /// This technique is necessary because the OnPaint event seems to be doing some
        /// extra processing that I haven't been able to figure out.
        /// </remarks>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_SETFOCUS:
                    _drawPrompt = false;
                    break;

                case WM_KILLFOCUS:
                    _drawPrompt = true;
                    break;
            }

            base.WndProc(ref m);
            // Only draw the prompt on the WM_PAINT event and when the Text property is empty
            if (m.Msg == WM_PAINT && _drawPrompt && this.Text.Length == 0 && !this.GetStyle(ControlStyles.UserPaint))
                DrawTextPrompt();

        }

        /// <summary>
        /// Overload to automatically create the Graphics region before drawing the text prompt
        /// </summary>
        /// <remarks>The Graphics region is disposed after drawing the prompt.</remarks>
        protected virtual void DrawTextPrompt()
        {
            using (Graphics g = this.CreateGraphics())
            {
                DrawTextPrompt(g);
            }
        }

        /// <summary>
        /// Draws the PromptText in the TextBox.ClientRectangle using the PromptFont and PromptForeColor
        /// </summary>
        /// <param name="g">The Graphics region to draw the prompt on</param>
        protected virtual void DrawTextPrompt(Graphics g)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.Top | TextFormatFlags.EndEllipsis;
            Rectangle rect = this.ClientRectangle;
            // Offset the rectangle based on the HorizontalAlignment, 
            // otherwise the display looks a little strange


            if (this.RightToLeft == RightToLeft.Yes)
            {
                flags = flags | TextFormatFlags.Right;
                rect.Offset(-7, 1);
            }
            else if (this.RightToLeft == RightToLeft.No)
            {
                flags = flags | TextFormatFlags.Left;
                rect.Offset(4, 1);
            }

            // Draw the prompt text using TextRenderer
            TextRenderer.DrawText(g, _promptText, _promptFont, rect, _promptColor, this.BackColor, flags);
        }

        string inputText = "";
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            inputText = this.Text;
            if (!this.ReadOnly)
            {
                this.BackColor = backColorUsed;
                if (zeroDefault)
                {
                    if (this.Text == "")
                    {
                        this.Text = "0";
                        this.SelectionStart = this.TextLength;
                    }
                }
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!this.ReadOnly)
            {
                this.BackColor = backColorUsed;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!this.ReadOnly)
            {
                if (ZeroDefault & this.Text == "0" & e.KeyChar != (char)13)
                {
                    this.Clear();
                }

                if (typeOfInput == FilteredEnum.Numeric)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[0-9.]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    if (this.Text == "0" & e.KeyChar != (char)13)
                    {
                        this.Clear();
                    }

                    // not allowed zero on first char
                    if ((e.KeyChar == '0') && ((this as TextBox).SelectionStart == 0))
                    {
                        e.Handled = true;
                    }

                    // only allow one decimal point
                    if ((e.KeyChar == '.') && ((this as TextBox).Text.IndexOf('.') > -1))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    // not allowed decimal point to first char
                    if ((e.KeyChar == '.') && ((this as TextBox).TextLength == 0))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.Digits)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[0-9]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.DigitsAndOperators)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[0-9+-^/*=%]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    // only allow one decimal point
                    if ((e.KeyChar == '.') && ((this as TextBox).Text.IndexOf('.') > -1))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    // not allowed decimal point to first char
                    if ((e.KeyChar == '.') && ((this as TextBox).TextLength == 0))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.EnglishChars)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[a-z A-Z]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }

                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.PersianChars)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[ \u0600-\u06FF\uFB8A\u067E\u0686\u06AF]"))
                    {
                        UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(e.KeyChar);
                        if (unicodeCategory == UnicodeCategory.NonSpacingMark)
                        {
                            this.BackColor = backColoronErr;
                            e.Handled = true;
                        }
                        else
                        {
                            this.BackColor = backColoronErr;
                            e.Handled = true;
                        }
                    }

                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.EnglishAndDigits)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[a-z A-Z0-9]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }
                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.PersianAndDigits)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[0-9 \u0600-\u06FF\uFB8A\u067E\u0686\u06AF]"))
                    {
                        UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(e.KeyChar);
                        if (unicodeCategory == UnicodeCategory.NonSpacingMark)
                        {
                            this.BackColor = backColoronErr;
                            e.Handled = true;
                        }
                        else
                        {
                            this.BackColor = backColoronErr;
                            e.Handled = true;
                        }
                    }
                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.EnglishAndAllChars)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[a-z A-Z0-9^`~!@#$%^&*()_+|\-=\\{}\[\]:"";'<>?,./]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }
                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.PersianAndAllChars)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[ \u0600-\u06FF\uFB8A\u067E\u0686\u06AF 0-9^`~!@#$%^&*()_+|\-=\\{}\[\]:"";'<>?,./]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }
                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.EnglishAndDigitsAndOperators)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[a-z A-Z0-9+-^/*=%]"))
                    {
                        this.BackColor = backColoronErr;
                        e.Handled = true;
                    }
                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.PersianAndDigitsAndOperators)
                {
                    if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"[0-9+-^/*=% \u0600-\u06FF\uFB8A\u067E\u0686\u06AF]"))
                    {
                        UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(e.KeyChar);
                        if (unicodeCategory == UnicodeCategory.NonSpacingMark)
                        {
                            this.BackColor = backColoronErr;
                            e.Handled = true;
                        }
                        else
                        {
                            this.BackColor = backColoronErr;
                            e.Handled = true;
                        }
                    }
                    // Accept this chars
                    if (acceptedChars != null)
                    {
                        if (acceptedChars.Contains(e.KeyChar.ToString()))
                        {
                            this.BackColor = backColorUsed;
                            e.Handled = false;
                        }
                    }
                }

                if (typeOfInput == FilteredEnum.AllChars)
                {
                    e.Handled = false;
                }

                if (enterToNextControl)
                {
                    if (e.KeyChar == (char)Keys.Return)
                        SendKeys.Send("{TAB}");
                }
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("The prompt text to display when there is nothing in the Text property.")]
        public string PromptText
        {
            get { return _promptText; }
            set { _promptText = value.Trim(); this.Invalidate(); }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("The ForeColor to use when displaying the PromptText.")]
        public Color PromptForeColor
        {
            get { return _promptColor; }
            set { _promptColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("The Font to use when displaying the PromptText.")]
        public Font PromptFont
        {
            get { return _promptFont; }
            set { _promptFont = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Behavior")]
        [Description("Automatically select the text when control receives the focus.")]
        public bool SelectAllFocused
        {
            get { return _focusSelect; }
            set { _focusSelect = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("Change backColor when entering the invalid chars")]
        public Color BackColorOnErr
        {
            set { backColoronErr = value; }
            get
            {
                if (backColoronErr == Color.Empty)
                {
                    return Color.Pink;
                }
                else
                {
                    return backColoronErr;
                }
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Filter")]
        [Description("Numeric > 0-9 (Not allowed zero on first char)\nDigits > 0-9\nDigitsAndOperators > 0-9+-^/*=%\nEnglishChars > a-z A-Z\nEnglishAndDigits > a-z A-Z0-9\nEnglishAndAllChars > a - z A - Z0 - 9 ^`~!@#$%^&*()_+|\"-=\\{}" + "[]:" + ";'<>?,./" + "\nAnyKeys > *.*")]
        [DefaultValue(FilteredEnum.AllChars)]
        public FilteredEnum FilterChars
        {
            set { typeOfInput = value; }
            get { return typeOfInput; }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Focus")]
        [Description("Change language system windows when focused")]
        [DefaultValue(LanguageEnum.NoChange)]
        public LanguageEnum TextLanguage
        {
            set { language = value; }
            get { return language; }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Filter")]
        [Description("Let these chars from filter")]
        public string AcceptedChars
        {
            set { acceptedChars = value; }
            get { return acceptedChars; }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Behavior")]
        [Description("In numeric filter mode you can using [ZeroDefault] property When text length is zero")]
        [DefaultValue(false)]
        public bool ZeroDefault
        {
            set
            {
                zeroDefault = value;
                if (value)
                {
                    this.Text = "0";
                }
                else
                {
                    this.Clear();
                }

            }
            get { return zeroDefault; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Focus")]
        [Description("Go to next control by ENTER key")]
        [DefaultValue(false)]
        public bool EnterToNextControl
        {
            set { enterToNextControl = value; }
            get { return enterToNextControl; }
        }

        [Category("Appearance")]
        public Color BackColorUsed
        {
            set { backColorUsed = value; }
            get
            {
                if (backColorUsed == Color.Empty)
                {
                    return Color.White;
                }
                else
                {
                    return backColorUsed;
                }
            }
        }

        private void ToFarsiLanguage()
        {
            try
            {
                var myCurrentLanguage = new System.Globalization.CultureInfo("fa-IR", true);
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCurrentLanguage);
            }
            catch { }
        }
        private void ToEnglishLanguage()
        {
            try
            {
                var myCurrentLanguage = new System.Globalization.CultureInfo("en-US", true);
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(myCurrentLanguage);
            }
            catch { }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}