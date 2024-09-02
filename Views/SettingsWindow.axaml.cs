using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using KeyboardOverlay.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using KeyboardOverlay.Views;

namespace KeyboardOverlay.Views
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
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

            //_settingsService.SaveSettings(newSettings);
            //_settingsService.ApplySettings(newSettings);
        }

        public void Btn_Event_Test(object? source, RoutedEventArgs e)
        {
            var appSettings = SettingsService.appSettings;
            var SelectedFontColor = this.SelectedFontColor;

            Debug.Print(SelectedFontColor.HsvColor);
            
        }
    }
}
