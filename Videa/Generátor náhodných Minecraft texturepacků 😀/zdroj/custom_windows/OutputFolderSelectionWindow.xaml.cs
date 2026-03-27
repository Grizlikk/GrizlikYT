using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minecraft_random_texturepacks.custom_windows
{
    /// <summary>
    /// Interaction logic for OutputFolderSelectionWindow.xaml
    /// </summary>
    public partial class OutputFolderSelectionWindow : Window, INotifyPropertyChanged
    {
        private string selectedFolderPath = string.Empty;
        public string SelectedFolderPath
        {
            get { return selectedFolderPath; }
            set
            {
                if (value != selectedFolderPath)
                {
                    selectedFolderPath = value;
                    NotifyPropertyChanged(nameof(SelectedFolderPath));
                }
            }
        }

        public OutputFolderSelectionWindow(string selectedFolderPath)
        {
            InitializeComponent();
            DataContext = this;

            SelectedFolderPath = selectedFolderPath;
        }

        private void SelectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();

            if (openFolderDialog.ShowDialog() != true) return;
            SelectedFolderPath = openFolderDialog.FolderName;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) SelectButton_Click(sender, e);
            if (e.Key == Key.Escape) CancelButton_Click(sender, e);
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
