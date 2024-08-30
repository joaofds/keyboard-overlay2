using Avalonia.Controls;
using Avalonia.Media;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;

namespace KeyboardOverlay.Views
{
    public partial class SettingsWindow : Window
    {
        private const string ConfigFilePath = "settings.json";
        private Color _fontColor = Colors.White;
        private Color _borderColor = Colors.Cyan;
        private Color _backgroundColor = Colors.Black;

        public SettingsWindow()
        {
            InitializeComponent();

            // Carregar configurações existentes
            if (File.Exists(ConfigFilePath))
            {
                var json = File.ReadAllText(ConfigFilePath);
                var config = JsonConvert.DeserializeObject<AppConfig>(json);

                FontColorPicker.SelectedColor = config.FontColor;
                BorderColorPicker.SelectedColor = config.BorderColor;
                BackgroundColorPicker.SelectedColor = config.BackgroundColor;

                _fontColor = config.FontColor;
                _borderColor = config.BorderColor;
                _backgroundColor = config.BackgroundColor;
            }
        }

        private void OnFontColorChanged(object sender, EventArgs e)
        {
            _fontColor = ((ColorPicker)sender).SelectedColor ?? Colors.White;
        }

        private void OnBorderColorChanged(object sender, EventArgs e)
        {
            _borderColor = ((ColorPicker)sender).SelectedColor ?? Colors.Cyan;
        }

        private void OnBackgroundColorChanged(object sender, EventArgs e)
        {
            _backgroundColor = ((ColorPicker)sender).SelectedColor ?? Colors.Black;
        }

        private void SaveButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var config = new AppConfig
            {
                FontColor = _fontColor,
                BorderColor = _borderColor,
                BackgroundColor = _backgroundColor
            };

            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);

            this.Close();
        }
    }

    public class AppConfig
    {
        public Color FontColor { get; set; }
        public Color BorderColor { get; set; }
        public Color BackgroundColor { get; set; }
    }
}