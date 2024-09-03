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

            // Preenche cores atuais no ColorPick
            var appSettings = SettingsService.appSettings;
            this.SelectedFontColor.Color = Color.Parse(appSettings!.FontColor!.ToString());
            this.SelectedBackgroundColor.Color = Color.Parse(appSettings!.BackgroundColor!.ToString());
            this.SelectedHoverColor.Color = Color.Parse(appSettings!.HoverColor!.ToString());
            this.SelectedBorderColor.Color = Color.Parse(appSettings!.BorderColor!.ToString());
        }

        // Método que pode ser chamado ao clicar no botão de salvar configurações
        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            var appSettings = SettingsService.appSettings;

            // Converte cor para string removendo canal alpha
            var SelectedFontColor = this.SelectedFontColor.Color.ToString().Remove(1, 2);
            var SelectedHoverColor = this.SelectedHoverColor.Color.ToString().Remove(1, 2);
            var SelectedBackgroundColor = this.SelectedBackgroundColor.Color.ToString().Remove(1, 2);
            var SelectedBorderColor = this.SelectedBorderColor.Color.ToString().Remove(1, 2);

            Debug.WriteLine(SelectedFontColor);
            Debug.WriteLine(SelectedHoverColor);
            Debug.WriteLine(SelectedBackgroundColor);
            Debug.WriteLine(SelectedBorderColor);

            /*
            appSettings!.FontColor= SelectedFontColor;
            appSettings!.HoverColor = SelectedHoverColor;
            appSettings!.BackgroundColor = SelectedBackgroundColor;
            appSettings!.BorderColor = SelectedBorderColor;
            */

            var newSettings = new AppSettings
            {
                FontColor = this.SelectedFontColor.Color.ToString().Remove(1, 2),
                BorderColor = this.SelectedBorderColor.Color.ToString().Remove(1, 2),
                BackgroundColor = this.SelectedBackgroundColor.Color.ToString().Remove(1, 2),
                HoverColor = this.SelectedHoverColor.Color.ToString().Remove(1, 2)
            };

            //_settingsService.SaveSettings(newSettings);
            //_settingsService.ApplySettings(newSettings);
        }

        private void OnCancelButtonClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
