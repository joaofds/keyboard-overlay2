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
            }
        }
    }

    public class AppConfig
    {
        public Color FontColor { get; set; }
        public Color BorderColor { get; set; }
        public Color BackgroundColor { get; set; }
    }
}