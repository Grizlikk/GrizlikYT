using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Náročná_aplikace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string progressLabelText = "Výpočet nebyl zahájen";
        public string ProgressLabelText
        {
            get => progressLabelText;
            set { progressLabelText = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgressLabelText))); }
        }
        private int processingSelectionIndex = 0;
        public int ProcessingSelectionIndex
        {
            get => processingSelectionIndex;
            set { processingSelectionIndex = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcessingSelectionIndex))); }
        }

        private CancellationTokenSource ctSource = new CancellationTokenSource();
        private readonly Action<CancellationToken>[] processingFunctions;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            processingFunctions = [StartSynchronousTask, StartAsynchronousTask, StartParallelTask];
        }

        private bool IsPrime(uint number)
        {
            if (number < 2) return false;
            for (uint i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) { MessageBox.Show($"{((Button)sender).Content} bylo stisknuto", "Tlačítko stisknuto", MessageBoxButton.OK, MessageBoxImage.Information); }
        private void StartProcessingButton_Click(object sender, RoutedEventArgs e) { processingFunctions[ProcessingSelectionIndex](ctSource.Token); }
        private void CancelProcessingButton_Click(object sender, RoutedEventArgs e) { ctSource.Cancel(); ctSource.Dispose(); ctSource = new CancellationTokenSource(); }

        private void StartSynchronousTask(CancellationToken ct)
        {
            try
            {
                ProgressLabelText = "Výpočet byl zahájen";
                uint next = 0;
                for (uint i = 0; i < 1000000; next++)
                {
                    i += (IsPrime(next)) ? 1u : 0;
                    ct.ThrowIfCancellationRequested();
                }
                ProgressLabelText = $"Výpočet byl dokončen, 1 000 000. prvočíslo je {next - 1}";
            }
            catch (OperationCanceledException)
            {
                ProgressLabelText = "Výpočet byl přerušen";
            }
        }

        private async void StartAsynchronousTask(CancellationToken ct)
        {
            try
            {
                ProgressLabelText = "Výpočet byl zahájen";
                uint next = 0;
                for (uint i = 0; i < 1000000; next++)
                {
                    i += (IsPrime(next)) ? 1u : 0;
                    ct.ThrowIfCancellationRequested();
                }
                ProgressLabelText = $"Výpočet byl dokončen, 1 000 000. prvočíslo je {next - 1}";
            }
            catch (OperationCanceledException)
            {
                ProgressLabelText = "Výpočet byl přerušen";
            }
        }
        private async void StartParallelTask(CancellationToken ct)
        {
            try
            {
                ProgressLabelText = "Výpočet byl zahájen";
                uint next = 0;
                await Task.Run(() =>
                {
                    for (uint i = 0; i < 1000000; next++)
                    {
                        i += (IsPrime(next)) ? 1u : 0;
                        ct.ThrowIfCancellationRequested();
                    }
                });
                ProgressLabelText = $"Výpočet byl dokončen, 1 000 000. prvočíslo je {next - 1}";
            }
            catch (OperationCanceledException)
            {
                ProgressLabelText = "Výpočet byl přerušen";
            }
        }
    }
}
