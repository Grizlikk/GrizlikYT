using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Minecraft_random_texturepacks
{
    internal class FolderSettingsItem : INotifyPropertyChanged
    {
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    NotifyPropertyChanged(nameof(Selected));
                    if (selectedValueChanged != null) selectedValueChanged();
                }
            }
        }

        private Action? selectedValueChanged;

        public FolderSettingsItem(string name, bool selected = false, Action? selectedValueChanged = null)
        {
            Name = name;
            Selected = selected;
            this.selectedValueChanged = selectedValueChanged;
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

    internal class RandomizationSettings : INotifyPropertyChanged
    {

        private byte randomizationPercentage = 100;
        public byte RandomizationPercentage
        {
            get { return randomizationPercentage; }
            set
            {
                if (randomizationPercentage != value)
                {
                    randomizationPercentage = value;
                    NotifyPropertyChanged(nameof(RandomizationPercentage));
                    NotifyPropertyChanged(nameof(FilesToRandomize));
                }
            }
        }

        private uint totalFiles = 0;
        public uint TotalFiles
        {
            get { return totalFiles; }
            set
            {
                if (totalFiles != value)
                {
                    totalFiles = value;
                    NotifyPropertyChanged(nameof(TotalFiles));
                    NotifyPropertyChanged(nameof(FilesToRandomize));
                }
            }
        }
        public uint FilesToRandomize
        {
            get { return (uint)((long)TotalFiles * RandomizationPercentage / 100); }
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

    internal class FilesSelectionSettings(Action? autoDetectJarSelectedCallback = null, Action? manualJarSelectionSelectedCallback = null, Action? customFolderSelectionSelectedCallback = null) : INotifyPropertyChanged
    {
        private bool autoDetectJarSelected = true;
        public bool AutoDetectJarSelected
        {
            get { return autoDetectJarSelected; }
            set
            {
                if (autoDetectJarSelected != value)
                {
                    autoDetectJarSelected = value;
                    NotifyPropertyChanged(nameof(AutoDetectJarSelected));
                    if (value && autoDetectJarSelectedCallback != null) autoDetectJarSelectedCallback();
                }
            }
        }

        private bool manualJarSelectionSelected;
        public bool ManualJarSelectionSelected
        {
            get { return manualJarSelectionSelected; }
            set
            {
                if (manualJarSelectionSelected != value)
                {
                    manualJarSelectionSelected = value;
                    NotifyPropertyChanged(nameof(ManualJarSelectionSelected));
                    if (value && manualJarSelectionSelectedCallback != null) manualJarSelectionSelectedCallback();
                }
            }
        }

        private bool customFolderSelectionSelected;
        public bool CustomFolderSelectionSelected
        {
            get { return customFolderSelectionSelected; }
            set
            {
                if (customFolderSelectionSelected != value)
                {
                    customFolderSelectionSelected = value;
                    NotifyPropertyChanged(nameof(CustomFolderSelectionSelected));
                    if (value && customFolderSelectionSelectedCallback != null) customFolderSelectionSelectedCallback();
                }
            }
        }


        public ObservableCollection<string> AutodetectedJarFiles { get; set; } = new ObservableCollection<string>();

        private string customPathToJarFile = string.Empty;
        public string CustomPathToJarFile
        {
            get { return customPathToJarFile; }
            set
            {
                if (customPathToJarFile != value)
                {
                    customPathToJarFile = value;
                    NotifyPropertyChanged(nameof(CustomPathToJarFile));
                }
            }
        }

        private string customFolderPath = string.Empty;
        public string CustomFolderPath
        {
            get { return customFolderPath; }
            set
            {
                if (customFolderPath != value)
                {
                    customFolderPath = value;
                    NotifyPropertyChanged(nameof(CustomFolderPath));
                }
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

    [ValueConversion(typeof(uint), typeof(string))]
    public class NumberWithSpacesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((uint)value).ToString("N0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return uint.Parse(((string)value).Replace(" ", string.Empty));
        }
    }
    [ValueConversion(typeof(bool), typeof(string))]
    public class GenerateTexturepackButtonTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "ROZHÁZET OBSAH SLOŽKY" : "VYGENEROVAT TEXTUREPACK";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).First() == 'R'; // Not used
        }
    }
    [ValueConversion(typeof(bool), typeof(string))]
    public class RandomizationPercentageSettingHeadingTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "MÍRA ROZHÁZENÍ SOUBORŮ" : "MÍRA ROZHÁZENÍ TEXTUR";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Last() == 'R'; // Not used
        }
    }
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class ReversedBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Hidden; // Not used
        }
    }
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class ReversedBooleanToCollabsedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Collapsed; // Not used
        }
    }
}