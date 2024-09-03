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
using System.IO.Enumeration;

namespace KeyboardOverlay.Views
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            // Preenche cores atuais no ColorPick
            SettingsService settingsService = new SettingsService();
            var appSettings = settingsService.LoadSettings();
            this.SelectedFontColor.Color = Color.Parse(appSettings!.FontColor!.ToString());
            this.SelectedBackgroundColor.Color = Color.Parse(appSettings!.BackgroundColor!.ToString());
            this.SelectedHoverColor.Color = Color.Parse(appSettings!.HoverColor!.ToString());
            this.SelectedBorderColor.Color = Color.Parse(appSettings!.BorderColor!.ToString());
        }

        private void OnDefaultButtonClick(object? sender, RoutedEventArgs e)
        {
            var file = "config.json";
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            this.Close();
        }

        // Método que pode ser chamado ao clicar no botão de salvar configurações
        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            //
            AppSettings _appSettings = new SettingsService().LoadSettings();
            MainWindow _mainWindow = new MainWindow();
            SettingsService _settingsService = new SettingsService();


            // Converte cor para string removendo canal alpha
            var SelectedFontColor = this.SelectedFontColor.Color.ToString();
            var SelectedHoverColor = this.SelectedHoverColor.Color.ToString();
            var SelectedBackgroundColor = this.SelectedBackgroundColor.Color.ToString();
            var SelectedBorderColor = this.SelectedBorderColor.Color.ToString();


            _appSettings!.FontColor = SelectedFontColor;
            _appSettings!.HoverColor = SelectedHoverColor;
            _appSettings!.BackgroundColor = this.SelectedBackgroundColor.Color.ToString();
            _appSettings!.BorderColor = SelectedBorderColor;

            // Altera backgound da janela principal.... eu acho kkkkkkkkk (com this.Background funciona)
            _mainWindow.Background = new SolidColorBrush(Color.Parse(this.SelectedBackgroundColor.Color.ToString()));

            
            var newSettings = new AppSettings
            {
                FontColor = this.SelectedFontColor.Color.ToString(),
                BorderColor = this.SelectedBorderColor.Color.ToString(),
                BackgroundColor = this.SelectedBackgroundColor.Color.ToString(),
                HoverColor = this.SelectedHoverColor.Color.ToString()
            };
            

            _settingsService.SaveSettings(newSettings);
            //_settingsService.ApplySettings(newSettings);

            this.Close();
        }

        // Fecha janela
        private void OnCancelButtonClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
