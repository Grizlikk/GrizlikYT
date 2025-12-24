using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Timer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private const double TIMER_UPDATE_INTERVAL_MILLISECONDS = 15;
		private readonly Color INVALID_INPUT_COLOR = Color.FromRgb(255, 92, 92);
		private readonly Color DEFAULT_INPUT_COLOR = Color.FromRgb(255, 255, 255);
		private TextBox[] inputTextBoxes;

		private DateTime targetTime = new DateTime();

		DispatcherTimer timer;

		private string countdownText;
		public string CountdownText
		{
			get { return countdownText; }
			set
			{
				NotifyPropertyChanged(nameof(countdownText));
				countdownText = value;
			}
		}

		public string YearText { get; set; }
		public string MonthText { get; set; }
		public string DayText { get; set; }
		public string HourText { get; set; }
		public string MinuteText { get; set; }
		public string SecondText { get; set; }
		public string MillisecondText { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;

			DateTime now = DateTime.Now;
			YearText = now.Year.ToString();
			MonthText = now.Month.ToString();
			DayText = now.Day.ToString();
			HourText = now.Hour.ToString();
			MinuteText = now.Minute.ToString();
			SecondText = now.Second.ToString();
			MillisecondText = now.Millisecond.ToString();
			countdownText = "00:00:00.000";

			inputTextBoxes = [YearTextBox, MonthTextBox, DayTextBox, HourTextBox, MinuteTextBox, SecondTextBox, MillisecondTextBox];

			UpdateTargetTime();

			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(TIMER_UPDATE_INTERVAL_MILLISECONDS);
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			UpdateTargetTime();
			UpdateTimer();
		}

		private void UpdateTargetTime()
		{
			int[] newTargetTimeParts = { targetTime.Year, targetTime.Month, targetTime.Day, targetTime.Hour, targetTime.Minute, targetTime.Second, targetTime.Millisecond };
			string[] inputTexts = [YearText, MonthText, DayText, HourText, MinuteText, SecondText, MillisecondText];
			bool[] validInputs = new bool[newTargetTimeParts.Length];
			validInputs.Select(x => x = false);
			if (newTargetTimeParts.Length != inputTextBoxes.Length || newTargetTimeParts.Length != inputTexts.Length) throw new InvalidOperationException("Lengths of arrays doesn't match");

			for (byte i = 0; i < inputTextBoxes.Length; i++)
			{
				if (int.TryParse(inputTexts[i], out int value))
				{
					newTargetTimeParts[i] = value;
					validInputs[i] = true;
				}
			}

			if (newTargetTimeParts[0] < 1 || newTargetTimeParts[0] > 9999)
			{
				validInputs[0] = false;
				newTargetTimeParts[0] = targetTime.Year;
			}

			if (newTargetTimeParts[1] < 1 || newTargetTimeParts[1] > 12)
			{
				validInputs[1] = false;
				newTargetTimeParts[1] = targetTime.Month;
			}

			int daysInMonth = DateTime.DaysInMonth(newTargetTimeParts[0], newTargetTimeParts[1]);
			if (newTargetTimeParts[2] < 1 || newTargetTimeParts[2] > daysInMonth)
			{
				validInputs[2] = false;
				if (targetTime.Day > daysInMonth)
				{
					newTargetTimeParts[2] = daysInMonth;
				}
				else
				{
					newTargetTimeParts[2] = targetTime.Day;
				}
			}

			if (newTargetTimeParts[3] < 0 || newTargetTimeParts[3] > 23)
			{
				validInputs[3] = false;
				newTargetTimeParts[3] = targetTime.Hour;
			}

			if (newTargetTimeParts[4] < 0 || newTargetTimeParts[4] > 59)
			{
				validInputs[4] = false;
				newTargetTimeParts[4] = targetTime.Minute;
			}

			if (newTargetTimeParts[5] < 0 || newTargetTimeParts[5] > 59)
			{
				validInputs[5] = false;
				newTargetTimeParts[5] = targetTime.Second;
			}

			if (newTargetTimeParts[6] < 0 || newTargetTimeParts[6] > 999)
			{
				validInputs[6] = false;
				newTargetTimeParts[6] = targetTime.Millisecond;
			}

			for (byte i = 0; i < validInputs.Length; i++)
			{
				if (validInputs[i]) SetDefaultBackgroundColor(inputTextBoxes[i]);
				else SetInvalidBackgroundColor(inputTextBoxes[i]);
			}

			targetTime = new DateTime(newTargetTimeParts[0], newTargetTimeParts[1], newTargetTimeParts[2], newTargetTimeParts[3], newTargetTimeParts[4], newTargetTimeParts[5], newTargetTimeParts[6]);

			/*


			int year;
			if (int.TryParse(YearText, out year))
			{
				SetDefaultBackgroundColor(YearTextBox);
			}
			else
			{
				year = targetTime.Year;
			}

			try
			{
				targetTime = new DateTime(
					int.Parse(YearText),
					int.Parse(MonthText),
					int.Parse(DayText),
					int.Parse(HourText),
					int.Parse(MinuteText),
					int.Parse(SecondText),
					int.Parse(MillisecondText)
				);
			}
			catch
			{
				return;
			}*/
		}
		private void SetInvalidBackgroundColor(TextBox textBlock)
		{
			textBlock.Background = new SolidColorBrush(INVALID_INPUT_COLOR);
		}
		private void SetDefaultBackgroundColor(TextBox textBlock)
		{
			textBlock.Background = new SolidColorBrush(DEFAULT_INPUT_COLOR);
		}

		private void UpdateTimer()
		{
			TimeSpan remainingTime = targetTime - DateTime.Now;
			if (remainingTime.TotalMilliseconds <= 0)
			{
				CountdownText = "00:00:00.000";
			}
			else
			{
				CountdownText = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", Math.Floor(remainingTime.TotalHours), remainingTime.Minutes, remainingTime.Seconds, remainingTime.Milliseconds);
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}