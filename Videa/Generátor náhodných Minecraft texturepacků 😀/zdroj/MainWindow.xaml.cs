using Microsoft.VisualBasic;
using Microsoft.Win32;
using Minecraft_random_texturepacks.custom_windows;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Minecraft_random_texturepacks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HashSet<string> DEFAULT_FOLDERS_TO_RANDOMIZE = new HashSet<string> { "block", "blocks", "item", "items" };
        private readonly DirectoryInfo minecraftVersionsFolder = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\versions"));
        private readonly DirectoryInfo minecraftResourcepacksFolder = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\resourcepacks"));

        private FilesSelectionSettings filesSelectionSettings = new FilesSelectionSettings();
        private RandomizationSettings randomizationSettings = new RandomizationSettings();

        private ObservableCollection<FolderSettingsItem> autodetectedJarFileFolderSettings = new ObservableCollection<FolderSettingsItem>();
        private ObservableCollection<FolderSettingsItem> customJarFileFolderSettings = new ObservableCollection<FolderSettingsItem>();

        private List<FileInfo> detectedJarFiles = new List<FileInfo>();

        private List<FolderWithTexturesInArchive> autodetectJarTextureFolders = new List<FolderWithTexturesInArchive>();
        private List<FolderWithTexturesInArchive> customJarTextureFolders = new List<FolderWithTexturesInArchive>();

        private TexturepackGenerator? autodetectJarTexturepackGenerator;
        private TexturepackGenerator? customJarTexturepackGenerator;

        private FolderRandomizer? folderRandomizer;

        private DirectoryInfo outputFolder;

        private bool autodetectJarSelected = true;
        private List<FolderWithTexturesInArchive> CurrentTextureFolders
        {
            get { return (autodetectJarSelected) ? autodetectJarTextureFolders : customJarTextureFolders; }
            set { if (autodetectJarSelected) { autodetectJarTextureFolders = value; } else { customJarTextureFolders = value; } }
        }
        private ObservableCollection<FolderSettingsItem> DisplayedFolderSettings
        {
            get { return (autodetectJarSelected) ? autodetectedJarFileFolderSettings : customJarFileFolderSettings; }
            set { if (autodetectJarSelected) { autodetectedJarFileFolderSettings = value; } else { customJarFileFolderSettings = value; } }
        }
        private TexturepackGenerator? CurrentTexturepackGenerator
        {
            get { return (autodetectJarSelected) ? autodetectJarTexturepackGenerator : customJarTexturepackGenerator; }
            set { if (autodetectJarSelected) { autodetectJarTexturepackGenerator = value; } else { customJarTexturepackGenerator = value; } }
        }


        public MainWindow()
        {
            InitializeComponent();

            DataContext = new
            {
                FilesSelectionSettings = filesSelectionSettings,
                RandomizationSettings = randomizationSettings,
                FolderSettings = DisplayedFolderSettings
            };

            outputFolder = minecraftResourcepacksFolder;

            DetectMinecraftJarFiles();
        }

        private void DetectMinecraftJarFiles()
        {
            if (!minecraftVersionsFolder.Exists) return;

            detectedJarFiles = minecraftVersionsFolder.GetFiles("*.jar", new EnumerationOptions() { RecurseSubdirectories = true }).ToList();

            StringComparer numericalComparer = StringComparer.Create(CultureInfo.CurrentCulture, CompareOptions.NumericOrdering);
            detectedJarFiles.Sort((x, y) => numericalComparer.Compare(y.Name, x.Name));

            filesSelectionSettings.AutodetectedJarFiles.Clear();
            foreach (FileInfo file in detectedJarFiles)
            {
                filesSelectionSettings.AutodetectedJarFiles.Add(file.Name);
            }
        }

        private void InitializeTexturepackGenerator(FileInfo sourceFile)
        {
            DisplayedFolderSettings.Clear();

            try
            {
                CurrentTexturepackGenerator = new TexturepackGenerator(sourceFile, sourceFile.Length < (1 << 30));
            }
            catch (IOException)
            {
                CurrentTexturepackGenerator = new TexturepackGenerator(sourceFile, true);
            }
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, false);

            CurrentTextureFolders = CurrentTexturepackGenerator.GetFoldersWithTextures();
            CurrentTextureFolders.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
            DisplayDataFromTexturesFolder();
        }

        private void DisplayDataFromTexturesFolder()
        {
            DisplayedFolderSettings.Clear();
            foreach (FolderWithTexturesInArchive folder in CurrentTextureFolders)
            {
                if (folder.NumberOfTextures <= 3) continue;
                DisplayedFolderSettings.Add(new FolderSettingsItem(folder.Name, DEFAULT_FOLDERS_TO_RANDOMIZE.Contains(folder.Name), CalculateNumberOfFilesToRandomize));
            }
        }

        private void CalculateNumberOfFilesToRandomize()
        {
            uint totalFiles = 0;
            foreach (FolderSettingsItem setting in DisplayedFolderSettings)
            {
                if (!setting.Selected) continue;

                for (int i = 0; i < CurrentTextureFolders.Count; i++)
                {
                    if (CurrentTextureFolders[i].Name == setting.Name)
                    {
                        totalFiles += CurrentTextureFolders[i].NumberOfTextures;
                        break;
                    }
                }
            }
            randomizationSettings.TotalFiles = totalFiles;
        }

        private void GenerateTexturepackButton_Click(object sender, RoutedEventArgs e)
        {
            if (filesSelectionSettings.CustomFolderSelectionSelected)
            {
                if (MinecraftMessageBox.Show("Opravdu chcete rozházet obsah vybrané složky?", "Potvrzení rozházení složky", MinecraftMessageBox.MinecraftMessageBoxIcon.Warning, MinecraftMessageBox.MinecraftMessageBoxOptions.YesNo, true) != true) return;

                folderRandomizer?.RandomizeFolder(randomizationSettings.RandomizationPercentage);
                return;
            }

            if (MinecraftMessageBox.Show("Opravdu chcete vygenerovat nový náhodný texturepack?", "Vygenerování texturepacku", MinecraftMessageBox.MinecraftMessageBoxIcon.Warning, MinecraftMessageBox.MinecraftMessageBoxOptions.YesNo, true) != true) return;


            if (!Directory.Exists(outputFolder.FullName))
            {
                if (MinecraftMessageBox.Show("Chcete cílovou složku automaticky vytvořit?", "Cílová složka neexistuje", MinecraftMessageBox.MinecraftMessageBoxIcon.Warning, MinecraftMessageBox.MinecraftMessageBoxOptions.YesNo, true) != true) return;
                try
                {
                    Directory.CreateDirectory(outputFolder.FullName);
                }
                catch (Exception ex)
                {
                    MinecraftMessageBox.Show("Při pokusu o vytvoření cílové složky došlo k chybě.\nZkontrolujte, zda je zvolená cesta ke složce platná.\n\nDetaily: " + ex.Message, "Cílovou složku nebylo možné vytvořit", MinecraftMessageBox.MinecraftMessageBoxIcon.Error, MinecraftMessageBox.MinecraftMessageBoxOptions.OK, true);
                    return;
                }
            }

            CurrentTexturepackGenerator?.GenerateRandomTexturepack(DisplayedFolderSettings.Where(x => x.Selected).Select(x => x.Name).ToArray(), outputFolder, randomizationSettings.RandomizationPercentage);
        }

        private void RefreshMinecraftVersionsButton_Click(object sender, RoutedEventArgs e)
        {
            DetectMinecraftJarFiles();

            if (detectedJarFiles.Count == 0)
            {
                MinecraftMessageBox.Show($"Nebyly nalezeny žádné .jar soubory ve výchozím umístění:\n{minecraftVersionsFolder.FullName}", ".jar soubory nebyly detekovány", MinecraftMessageBox.MinecraftMessageBoxIcon.Warning, MinecraftMessageBox.MinecraftMessageBoxOptions.OK, true);
            }
        }

        private void ChooseCustomJarFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ".jar soubory|*.jar|Všechny soubory|*.*";

            if (openFileDialog.ShowDialog() != true) return;
            filesSelectionSettings.CustomPathToJarFile = openFileDialog.FileName;
        }

        private void ChooseCustomFolderButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();

            if (openFolderDialog.ShowDialog() != true) return;
            filesSelectionSettings.CustomFolderPath = openFolderDialog.FolderName;
        }

        private void SelectAllButton_Click(object sender, RoutedEventArgs e) { foreach (FolderSettingsItem item in DisplayedFolderSettings) item.Selected = true; }
        private void UnselectAllButton_Click(object sender, RoutedEventArgs e) { foreach (FolderSettingsItem item in DisplayedFolderSettings) item.Selected = false; }
        private void InvertSelectionButton_Click(object sender, RoutedEventArgs e) { foreach (FolderSettingsItem item in DisplayedFolderSettings) item.Selected = !item.Selected; }

        private void AutodetectedJarFilesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == -1) return;
            InitializeTexturepackGenerator(detectedJarFiles[((ComboBox)sender).SelectedIndex]);
            CalculateNumberOfFilesToRandomize();
        }

        private void JarPathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text)) return;

            FileInfo file = new FileInfo(((TextBox)sender).Text);
            if (!file.Exists) return;

            try
            {
                InitializeTexturepackGenerator(file);
            }
            catch (InvalidDataException)
            {
                MinecraftMessageBox.Show("Error: Zvolený soubor není platný .zip archiv", "Neplatný archiv!", MinecraftMessageBox.MinecraftMessageBoxIcon.Error, MinecraftMessageBox.MinecraftMessageBoxOptions.OK, true);
            }
            CalculateNumberOfFilesToRandomize();
        }

        private void FolderPathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text)) return;

            DirectoryInfo directoryInfo = new DirectoryInfo(((TextBox)sender).Text);
            if (!directoryInfo.Exists) return;

            folderRandomizer = new FolderRandomizer(directoryInfo);
            randomizationSettings.TotalFiles = (uint)folderRandomizer.TotalFiles;
        }

        private void AutoDetectJarRadio_Checked(object sender, RoutedEventArgs e) { autodetectJarSelected = true; FolderSettingsItemsControl.ItemsSource = DisplayedFolderSettings; CalculateNumberOfFilesToRandomize(); }
        private void ManualJarSelectionRadio_Checked(object sender, RoutedEventArgs e) { autodetectJarSelected = false; FolderSettingsItemsControl.ItemsSource = DisplayedFolderSettings; CalculateNumberOfFilesToRandomize(); }

        private void SelectOutputFolderButton_Click(object sender, RoutedEventArgs e)
        {
            OutputFolderSelectionWindow selectionWindow = new OutputFolderSelectionWindow(outputFolder.FullName);

            if (selectionWindow.ShowDialog() != true) return;
            try { outputFolder = new DirectoryInfo(selectionWindow.SelectedFolderPath); }
            catch { return; }
        }
    }
}