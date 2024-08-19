using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Nasobilka
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool gameRunning = false;
		private Button[] answerButtons = new Button[3];
		private byte correctAnswerButtonID;
		private Equation? currentEquation;

		private System.Timers.Timer timer;
		private byte secondsLeft;

		private uint score;
		private uint highScore;

		public MainWindow()
		{
			InitializeComponent();
			answerButtons[0] = AnswerOption1;
			answerButtons[1] = AnswerOption2;
			answerButtons[2] = AnswerOption3;

			timer = new System.Timers.Timer(1000);
			timer.Elapsed += SecondPassed;
		}

		private void GameControlButton_Click(object sender, RoutedEventArgs e)
		{
			if (gameRunning) return;
			gameRunning = true;
			score = 0;

			HeadingTextBlock.Text = "Vypočítejte: ";

			secondsLeft = 10;
			GameControlButton.Content = $"Zbývající čas: {secondsLeft} s";
			ScoreTextBlock.Text = "Skóre: 0";
			timer.Start();

			DisplayNextEquation();
		}

		private void AnswerButton_Click(object sender, RoutedEventArgs e)
		{
			if (!gameRunning || currentEquation == null) return;

			Button button = (Button)sender;
			if (button.Tag.ToString() != correctAnswerButtonID.ToString())
			{
				GameOver("Konec hry! ", $"{currentEquation.ToString()} = {currentEquation.CorrectAnswer}");
				return;
			}

			score++;
			highScore = Math.Max(score, highScore);
			ScoreTextBlock.Text = $"Skóre: {score}";
			HighScoreTextBlock.Text = $"Rekord: {highScore}";

			secondsLeft++;

			DisplayNextEquation();
		}

		private void DisplayNextEquation()
		{
			if (!gameRunning) return;

			currentEquation = new Equation(answerButtons.Length - 1);
			HeadingTextBlockBold.Text = $"{currentEquation.Factors.Item1} × {currentEquation.Factors.Item2}";
			List<int> answers = currentEquation.WrongAnswers;

			correctAnswerButtonID = (byte)new Random().Next(answerButtons.Length);
			answers.Insert(correctAnswerButtonID, currentEquation.CorrectAnswer);
			for (byte i = 0; i < answerButtons.Length; i++)
			{
				answerButtons[i].Content = answers[i];
			}
		}

		private void GameOver(string headingMessage, string? headingBoldMessage)
		{
			if (!gameRunning) return;
			gameRunning = false;
			timer.Stop();

			Dispatcher.Invoke(new Action(() =>
			{
				HeadingTextBlock.Text = headingMessage;
				HeadingTextBlockBold.Text = headingBoldMessage;
				GameControlButton.Content = "Klikněte pro start hry";
			}));
		}

		private void SecondPassed(object? sender, ElapsedEventArgs e)
		{
			if (!gameRunning) return;
			if (secondsLeft == 0)
			{
				GameOver("Konec hry! ", "Čas vypršel.");
				return;
			}

			secondsLeft--;

			Dispatcher.Invoke(new Action(() =>
			{
				GameControlButton.Content = $"Zbývající čas: {secondsLeft} s";
			}));
		}
	}

	internal class Equation
	{
		private Random random = new Random();

		private Tuple<int, int> factors;
		public Tuple<int, int> Factors { get { return factors; } }

		private int correctAnswer;
		public int CorrectAnswer { get { return correctAnswer; } }

		private List<int> wrongAnswers = new List<int>();
		public List<int> WrongAnswers { get { return wrongAnswers; } }

		public Equation(int totalWrongAnswers)
		{
			factors = new Tuple<int, int>(GenerateRandomFactor(), GenerateRandomFactor());

			correctAnswer = factors.Item1 * factors.Item2;

			for (int i = 0; i < totalWrongAnswers; i++)
			{
				wrongAnswers.Add(GenerateWrongAnswer());
			}
		}

		public override string ToString()
		{
			return $"{factors.Item1} × {factors.Item2}";
		}

		private int GenerateRandomFactor()
		{
			return (random.NextDouble() < 0.8) ? random.Next(11) : random.Next(11, 17);
		}

		private int GenerateWrongAnswer()
		{
			byte randomizer = (byte)random.Next(1 << 8);

			int fakeFactor1 = GetFakeFactor(factors.Item1, randomizer);
			int fakeFactor2 = GetFakeFactor(factors.Item2, (byte)(randomizer >> 3));

			int fakeResult = fakeFactor1 * fakeFactor2;
			if ((randomizer >> 6 & 1) == 1)
			{
				int resultDifference = random.Next(5);
				fakeResult = ((randomizer >> 7 & 1) == 1 && fakeResult - resultDifference >= 0) ? fakeResult - resultDifference : fakeResult + resultDifference;
			}
			return (wrongAnswers.Contains(fakeResult) || fakeResult == correctAnswer) ? GenerateWrongAnswer() : fakeResult;

			int GetFakeFactor(int factor, byte randomizer)
			{
				int factorDifference = randomizer & 0b11;
				if (factorDifference == 0b11) factorDifference = 0;
				return ((randomizer >> 2 & 1) == 1 && factor - factorDifference >= 0) ? factor - factorDifference : factor + factorDifference;
			}
		}
	}
}