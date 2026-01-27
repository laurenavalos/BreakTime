namespace BreakTime;

public partial class MainPage : ContentPage
{

    private bool isRunning;
    private int intSec;
    private int intMin;
    private bool isRed;
    private void CountdownTimer(int StopTime)
    {
        intSec = 0;
        intMin = 0;
        int minute = 0;
        isRunning = true;
        Dispatcher.StartTimer(TimeSpan.FromMilliseconds(100), () =>
        {
            intSec++;
            if (intSec > 59)
            {
                intSec = 0;
                intMin++;
            }
            lblDisplay.Text = (StopTime - intMin).ToString() + "Minutes Left";
            if ((StopTime - intMin)< 1)
            {
                lblDisplay.Text = "Times Up";
                if (isRed)
                {
                    isRed = false;
                    frmMain.BackgroundColor = Colors.White;
                }
                else
                {
                    isRed = true;
                    frmMain.BackgroundColor = Colors.Red;
                }
            }
            else
            {
                lblDisplay.Text = (StopTime - intMin).ToString() + "Minutes Left";
            }
            return isRunning;
        });
        
    }
    
    public MainPage()
    {
        InitializeComponent();
    }

    private void Btn5_OnClicked(object sender, EventArgs e)
    {
        CountdownTimer(5);
    }

    private void Btn10_OnClicked(object sender, EventArgs e)
    {
        CountdownTimer(10);
    }

    private void Btn15_OnClicked(object sender, EventArgs e)
    {
        CountdownTimer(15);
    }

    private void Reset_OnClicked(object sender, EventArgs e)
    {
        isRunning = false;
        lblDisplay.Text = "Start Break Time Timer";
    }
}