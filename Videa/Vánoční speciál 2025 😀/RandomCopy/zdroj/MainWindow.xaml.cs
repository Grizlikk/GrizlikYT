using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace RandomCopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string originalPath = string.Empty;
        public string OriginalPath
        {
            get { return originalPath; }
            set
            {
                originalPath = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nameof(OriginalPath)));
            }
        }
        private OpenFolderDialog originalPathDialog = new OpenFolderDialog();

        private string destinationPath = string.Empty;
        public string DestinationPath
        {
            get { return destinationPath; }
            set
            {
                destinationPath = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nameof(DestinationPath)));
            }
        }
        private OpenFolderDialog destinationPathDialog = new OpenFolderDialog();

        public string FilesFilter { get; set; } = "*.*";

        private FileInfo[] FilesToCopy = Array.Empty<FileInfo>();


        private Visibility copyingProgressBarVisibility = Visibility.Collapsed;
        public Visibility CopyingProgressBarVisibility
        {
            get { return copyingProgressBarVisibility; }
            set
            {
                copyingProgressBarVisibility = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nameof(CopyingProgressBarVisibility)));
            }
        }
        private int copyingProgressBarValue = 0;
        public int CopyingProgressBarValue
        {
            get { return copyingProgressBarValue; }
            set
            {
                copyingProgressBarValue = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nameof(CopyingProgressBarValue)));
            }
        }

        private Task? copyingFilesTask;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SelectOriginalPathButton_Click(object sender, RoutedEventArgs e)
        {
            if (originalPathDialog.ShowDialog() == true)
            {
                OriginalPath = originalPathDialog.FolderName;
            }

            DisplayFilesToCopy();
        }

        private void SelectDestinationPathButton_Click(object sender, RoutedEventArgs e)
        {
            if (destinationPathDialog.ShowDialog() == true)
            {
                DestinationPath = destinationPathDialog.FolderName;
            }
        }

        private void CopyFilesFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayFilesToCopy();
        }

        private void CopyFilesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            if (!Directory.Exists(OriginalPath))
            {
                MessageBox.Show("Vybraná zdrojová složka neexistuje", "Zdrojová složka neexistuje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Directory.Exists(DestinationPath))
            {
                result = MessageBox.Show("Vybraná cílová složka neexistuje, chcete ji vytvořit?", "Cílová složka neexistuje", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No) return;
            }

            if (copyingFilesTask != null && copyingFilesTask.Status != TaskStatus.RanToCompletion)
            {
                MessageBox.Show("Kopírování souborů ještě probíhá\nPočkejte na dokončení aktuálního kopírování souborů", "Kopírování probíhá", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            result = MessageBox.Show("Opravdu chcete zahájit kopírování souborů?", "Zahájit kopírování souborů", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No) return;


            copyingFilesTask = CopyFiles();
        }

        private void DisplayFilesToCopy()
        {
            if (string.IsNullOrEmpty(OriginalPath)) return;
            DirectoryInfo originalDirectory = new DirectoryInfo(OriginalPath);
            if (!originalDirectory.Exists) return;

            FilesToCopy = originalDirectory.GetFiles(FilesFilter);
            FilesToCopyItemsControl.ItemsSource = FilesToCopy.Select(x => x.Name).ToArray();
        }

        private async Task CopyFiles()
        {
            DirectoryInfo originalDirectory = new DirectoryInfo(OriginalPath);
            DirectoryInfo destinationDirectory = new DirectoryInfo(DestinationPath);

            // Create destination directory
            try
            {
                if (!destinationDirectory.Exists) destinationDirectory.Create();
            }
            catch (IOException exception)
            {
                MessageBox.Show("Při pokusu o vytvoření cílové složky došlo k chybě:\n" + exception.Message, "Chyba při vytváření složky", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Start copying
            CopyingFilesProgressBar.Maximum = FilesToCopy.Length;
            CopyingProgressBarVisibility = Visibility.Visible;
            CopyingProgressBarValue = 1;

            List<FileInfo> files = FilesToCopy.ToList();
            await Task.Run(() =>
            {
                Random random = new Random();

                while (files.Count > 0)
                {
                    int index = random.Next(files.Count);

                    try
                    {
                        files[index].CopyTo(Path.Combine(destinationDirectory.FullName, files[index].Name));
                    }
                    catch (Exception) { }

                    files.RemoveAt(index);

                    CopyingProgressBarValue++;
                }
            });

            CopyingProgressBarVisibility = Visibility.Collapsed;

            MessageBox.Show("Kopírování bylo dokončeno", "Kopírování dokončeno", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}