using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Newtonsoft.Json;
using System.IO;

namespace KeyboardOverlay.Views
{
    public partial class SettingsWindow : Window
    {
        private const string ConfigFilePath = "config.json";

        public SettingsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists("config.json"))
            {
                var json = File.ReadAllText("config.json");
                var settings = JsonConvert.DeserializeObject<AppSettings>(json);
                ApplySettings(settings);
            }
            else
            {
                // Caso o arquivo não exista, criar com configurações padrão
                var defaultSettings = new AppSettings
                {
                    FontColor = "#FFFFFF",
                    BorderColor = "#05a1a1",
                    BackgroundColor = "#1e1e1e",
                    HoverColor = "#05a1a1"
                };
                SaveSettings(defaultSettings);
                ApplySettings(defaultSettings);
            }
        }

        private void SaveSettings(AppSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }

        private void ApplySettings(AppSettings settings)
        {
            // Exemplo de aplicação das configurações de cor em elementos da interface
            var fontColorBrush = new SolidColorBrush(Color.Parse(settings.FontColor));
            var borderColorBrush = new SolidColorBrush(Color.Parse(settings.BorderColor));
            var backgroundColorBrush = new SolidColorBrush(Color.Parse(settings.BackgroundColor));

            // Aqui podemos aplicar as cores aos elementos da interface
            // Exemplo:
            // this.SomeTextBlock.Foreground = fontColorBrush;
            // this.SomeBorder.BorderBrush = borderColorBrush;
            // this.SomePanel.Background = backgroundColorBrush;
        }

        // Método que pode ser chamado ao clicar no botão de salvar configurações
        private void OnSaveSettingsButtonClick(object sender, RoutedEventArgs e)
        {
            var newSettings = new AppSettings
            {
                FontColor = "#FFFF00", // Aqui você poderia obter esses valores de campos da UI
                BorderColor = "#00FF00",
                BackgroundColor = "#0000FF"
            };

            SaveSettings(newSettings);
            ApplySettings(newSettings);
        }
    }

    public class AppSettings
    {
        public string? FontColor { get; set; }
        public string? BorderColor { get; set; }
        public string? BackgroundColor { get; set; }
        public string? HoverColor { get; set; }
    }
}
