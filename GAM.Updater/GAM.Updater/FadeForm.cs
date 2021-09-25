using System;
using System.Windows.Forms;

public class FadeForm : Form
{
    private double counter;
    private Timer fadeInOut;
    private bool sw;
    private bool closeAble;

    public event FadeCompleteEvent FadeInComplete;
    public delegate void FadeCompleteEvent();

    public FadeForm()
    {
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Opacity = 0;
        fadeInOut = new Timer { Interval = 50 };
        this.fadeInOut.Enabled = true;
        this.fadeInOut.Tick += new System.EventHandler(timer_Tick);
        sw = true;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (sw)
        {
            counter += 0.1;
            DoFadeIn();
        }
        else
        {
            counter -= 0.1;
            DoFadeOut();
        }
    }
    private void DoFadeOut()
    {
        Application.DoEvents();

        if (counter <= 1.1 && counter > 0)
        {
            Opacity = counter;
            Refresh();
        }
        else if (counter <= 0)
        {
            closeAble = true;
        }
    }
    private void DoFadeIn()
    {
        Application.DoEvents();

        if (counter <= 1.1)
        {
            Opacity = counter;
            Refresh();
        }
        else
        {
            fadeInOut.Enabled = false;

            if (FadeInComplete != null)
                FadeInComplete();
        }
    }
    private void this_Closing(object sender, FormClosingEventArgs e)
    {
        if (!closeAble)
        {
            e.Cancel = true;
            sw = false;
            fadeInOut.Enabled = true;
        }
    }
}

