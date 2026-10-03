using System.ComponentModel;
using System.IO;
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

namespace Náročná_aplikace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string progressLabelText = "Čtení souboru nebylo zahájeno";
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

        private void Button_Click(object sender, RoutedEventArgs e) { MessageBox.Show($"{((Button)sender).Content} bylo stisknuto", "Tlačítko stisknuto", MessageBoxButton.OK, MessageBoxImage.Information); }
        private void StartProcessingButton_Click(object sender, RoutedEventArgs e) { processingFunctions[ProcessingSelectionIndex](ctSource.Token); }
        private void CancelProcessingButton_Click(object sender, RoutedEventArgs e) { ctSource.Cancel(); ctSource.Dispose(); ctSource = new CancellationTokenSource(); }

        private void StartSynchronousTask(CancellationToken ct)
        {
            try
            {
                ProgressLabelText = "Čtení souboru bylo zahájeno";
                byte[] data = File.ReadAllBytes("Video.mp4");
                ct.ThrowIfCancellationRequested();
                ProgressLabelText = $"Ze souboru bylo úspěšně přečteno {data.Length} bajtů";
            }
            catch (OperationCanceledException)
            {
                ProgressLabelText = "Čtení souboru bylo přerušeno";
            }
            catch (FileNotFoundException)
            {
                ProgressLabelText = "Soubor ke čtení dat nebyl nalezen";
            }
        }

        private async void StartAsynchronousTask(CancellationToken ct)
        {
            try
            {
                ProgressLabelText = "Čtení souboru bylo zahájeno";
                byte[] data = await File.ReadAllBytesAsync("Video.mp4", ct);
                ProgressLabelText = $"Ze souboru bylo úspěšně přečteno {data.Length} bajtů";
            }
            catch (OperationCanceledException)
            {
                ProgressLabelText = "Čtení souboru bylo přerušeno";
            }
            catch (FileNotFoundException)
            {
                ProgressLabelText = "Soubor ke čtení dat nebyl nalezen";
            }
        }
        private async void StartParallelTask(CancellationToken ct)
        {
            try
            {
                ProgressLabelText = "Čtení souboru bylo zahájeno";
                byte[] data = [];
                await Task.Run(() =>
                {
                    data = File.ReadAllBytes("Video.mp4");
                    ct.ThrowIfCancellationRequested();
                });
                ProgressLabelText = $"Ze souboru bylo úspěšně přečteno {data.Length} bajtů";
            }
            catch (OperationCanceledException)
            {
                ProgressLabelText = "Čtení souboru bylo přerušeno";
            }
            catch (FileNotFoundException)
            {
                ProgressLabelText = "Soubor ke čtení dat nebyl nalezen";
            }
        }
    }
}
