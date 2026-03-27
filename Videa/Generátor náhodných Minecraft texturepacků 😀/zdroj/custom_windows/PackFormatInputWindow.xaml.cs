using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for PackFormatInputWindow.xaml
    /// </summary>
    public partial class PackFormatInputWindow : Window
    {
        public string PackFormatInputValue { get; set; } = string.Empty;

        public PackFormatInputWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = null;
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) OkButton_Click(sender, e);
            if (e.Key == Key.Escape) CancelButton_Click(sender, e);
        }

        private void OpenWikiLink_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("https://minecraft.wiki/Pack_format");
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
    }
}
