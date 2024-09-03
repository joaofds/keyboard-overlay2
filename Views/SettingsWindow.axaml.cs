using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using KeyboardOverlay.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using KeyboardOverlay.Views;
using KeyboardOverlay.ViewModels;

namespace KeyboardOverlay.Views
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        // Método que pode ser chamado ao clicar no botão de salvar configurações
        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
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

        private void OnCancelButtonClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Btn_Event_Test(object? source, RoutedEventArgs e)
        {
            var appSettings = SettingsService.appSettings;

            // Converte cor para string removendo canal alpha
            var SelectedFontColor = this.SelectedFontColor.Color.ToString().Remove(1,2);
            var SelectedHoverColor = this.SelectedHoverColor.Color.ToString().Remove(1,2);
            var SelectedBackColor = this.SelectedBackColor.Color.ToString().Remove(1,2);
            var SelectedBorderColor = this.SelectedBorderColor.Color.ToString().Remove(1,2);

            Debug.WriteLine(SelectedFontColor);
            Debug.WriteLine(SelectedHoverColor);
            Debug.WriteLine(SelectedBackColor);
            Debug.WriteLine(SelectedBorderColor);

            /*
            appSettings!.FontColor= SelectedFontColor;
            appSettings!.HoverColor = SelectedHoverColor;
            appSettings!.BackgroundColor = SelectedBackColor;
            appSettings!.BorderColor = SelectedBorderColor;
            */
            

        }
    }
}
