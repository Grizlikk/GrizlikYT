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
    /// Interaction logic for MinecraftMessageBox.xaml
    /// </summary>
    public partial class MinecraftMessageBox : Window, INotifyPropertyChanged
    {
        public enum MinecraftMessageBoxIcon
        {
            None, Error, Warning
        }

        public enum MinecraftMessageBoxOptions
        {
            OK, YesNo
        }

        private string message = string.Empty;
        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    NotifyPropertyChanged(nameof(Message));
                }
            }
        }

        private string heading = string.Empty;
        public string Heading
        {
            get { return heading; }
            set
            {
                if (heading != value)
                {
                    heading = value;
                    NotifyPropertyChanged(nameof(Heading));
                }
            }
        }


        public MinecraftMessageBox(string message, string heading, MinecraftMessageBoxIcon icon, MinecraftMessageBoxOptions options)
        {
            InitializeComponent();

            DataContext = this;

            Message = message;
            Heading = heading;

            switch (icon)
            {
                case MinecraftMessageBoxIcon.Error: ErrorIcon.Visibility = Visibility.Visible; break;
                case MinecraftMessageBoxIcon.Warning: WarningIcon.Visibility = Visibility.Visible; break;
            }

            switch (options)
            {
                case MinecraftMessageBoxOptions.YesNo:
                    OkButton.Visibility = Visibility.Collapsed;
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    break;
            }
        }

        public static bool? Show(string message, string heading = "Oznámení", MinecraftMessageBoxIcon icon = MinecraftMessageBoxIcon.None, MinecraftMessageBoxOptions options = MinecraftMessageBoxOptions.OK, bool playSound = false)
        {
            if (playSound)
            {
                switch (icon)
                {
                    case MinecraftMessageBoxIcon.Error: System.Media.SystemSounds.Hand.Play(); break;
                    case MinecraftMessageBoxIcon.Warning: System.Media.SystemSounds.Exclamation.Play(); break;
                }
            }

            MinecraftMessageBox minecraftMessageBox = new MinecraftMessageBox(message, heading, icon, options);
            minecraftMessageBox.ShowDialog();
            return minecraftMessageBox.DialogResult;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) OkButton_Click(sender, e);
            if (e.Key == Key.Escape) Close();
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
