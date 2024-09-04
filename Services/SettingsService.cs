using Avalonia.Media;
using KeyboardOverlay.Views;
using Newtonsoft.Json;
using System.IO;

namespace KeyboardOverlay.Services
{
    public class SettingsService
    {
        // Arquivo de configuração
        private const string ConfigFilePath = "config.json";

        // Configurações atuais são guardadas aqui
        public static AppSettings? appSettings = null;

        public AppSettings LoadSettings()
        {
            // Verifica existencia de arquivo
            if (File.Exists("config.json"))
            {
                // Lê arquivo
                var json = File.ReadAllText("config.json");

                // Faz o parse do arquivo, armazena e retorna
                var settings = JsonConvert.DeserializeObject<AppSettings>(json);
                appSettings = settings;
                
                return settings!;
            }

            // Caso o arquivo não exista, criar com configurações padrão
            var defaultSettings = new AppSettings
            {
                FontColor = "#FFFFFF",
                BorderColor = "#05a1a1",
                BackgroundColor = "#1e1e1e",
                HoverColor = "#05a1a1"
            };
            SaveSettings(defaultSettings);

            appSettings = defaultSettings;

            return defaultSettings;
        }

        // Salva arquivo de configuração
        public void SaveSettings(AppSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);

            this.LoadSettings();
        }

        // Metodos que retornam configurações
        public static SolidColorBrush FontColor => new SolidColorBrush(Color.Parse(appSettings!.FontColor!));
        public static SolidColorBrush BorderColor => new SolidColorBrush(Color.Parse(appSettings!.BorderColor!));
        public static SolidColorBrush BackgroundColor => new SolidColorBrush(Color.Parse(appSettings!.BackgroundColor!));
        public static SolidColorBrush HoverColor => new SolidColorBrush(Color.Parse(appSettings!.HoverColor!));
    }

    // Usada para gerar o json
    public class AppSettings
    {
        public string? FontColor { get; set; }
        public string? BorderColor { get; set; }
        public string? BackgroundColor { get; set; }
        public string? HoverColor { get; set; }
    }
}