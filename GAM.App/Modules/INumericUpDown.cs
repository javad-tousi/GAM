using System;

namespace System.Windows.Forms
{
    public class INumericUpDown : NumericUpDown
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // remove scrolllines scaling, taking care of case scrolllines is 0
            int delta = e.Delta / Math.Max(Math.Abs(SystemInformation.MouseWheelScrollLines), 1);
            base.OnMouseWheel(new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, delta));
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Select(0, this.Text.Length);
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            if (this.Value > 0)
            {
                this.ForeColor = Drawing.Color.Blue;
            }
            else
            {
                this.ForeColor = Drawing.Color.Gray;
            }
        }
    }
}
