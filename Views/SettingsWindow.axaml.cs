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
        private MainWindow _mainWindow;
        public SettingsWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            // Preenche cores atuais no ColorPick
            SettingsService settingsService = new SettingsService();
            var appSettings = settingsService.LoadSettings();
            this.SelectedFontColor.Color = Color.Parse(appSettings!.FontColor!.ToString());
            this.SelectedBackgroundColor.Color = Color.Parse(appSettings!.BackgroundColor!.ToString());
            this.SelectedHoverColor.Color = Color.Parse(appSettings!.HoverColor!.ToString());
            this.SelectedBorderColor.Color = Color.Parse(appSettings!.BorderColor!.ToString());
        }

        // Evento onChange para os Colorpickers para mudanças em tempo real dos elementos
        private void ChangeColorOnColorpickChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "Color" && e.NewValue is Color newColor && sender is ColorPicker colorPicker)
            {
                SolidColorBrush brush = new SolidColorBrush(newColor);

                // Determine qual ColorPicker disparou o evento
                if (colorPicker == SelectedBackgroundColor)
                {
                    UpdateBackgroundColor(brush);
                }
                else if (colorPicker == SelectedBorderColor)
                {
                    UpdateBorderColor(brush);
                }
                else if (colorPicker == SelectedFontColor)
                {
                    UpdateFontColor(brush);
                }
            }
        }

        // Atualiza background
        private void UpdateBackgroundColor(SolidColorBrush brush)
        {
            _mainWindow.Background = brush;
            _mainWindow.settingsButton.Background = brush;
        }

        // Atualiza bordas
        private void UpdateBorderColor(SolidColorBrush brush)
        {
            _mainWindow.settingsButton.BorderBrush = brush;
            foreach (var button in _mainWindow.GetKeys().Values)
            {
                button.BorderBrush = brush;
            }
        }

        // Atualiza fonte
        private void UpdateFontColor(SolidColorBrush brush)
        {
            _mainWindow.settingsIcon.Foreground = brush;
            foreach (var button in _mainWindow.GetKeys().Values)
            {
                if (button.Child is TextBlock textBlock)
                {
                    textBlock.Foreground = brush;
                }
            }
        }

        // Restaura para cor padrão
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
            // Inicializa objetos necessarios
            SettingsService _settingsService = new SettingsService();
            
            // Novo objeto que guardamos as cores
            var newSettings = new AppSettings
            {
                FontColor = this.SelectedFontColor.Color.ToString(),
                BorderColor = this.SelectedBorderColor.Color.ToString(),
                BackgroundColor = this.SelectedBackgroundColor.Color.ToString(),
                HoverColor = this.SelectedHoverColor.Color.ToString()
            };
            
            // Altera arquivo com novas cores
            _settingsService.SaveSettings(newSettings);

            this.Close();
        }

        // Fecha janela e coloca elementos no estado anterior
        private void OnCancelButtonClick(object? sender, RoutedEventArgs e)
        {
            AppSettings appSettings = new SettingsService().LoadSettings();

            _mainWindow.Background = new SolidColorBrush(Color.Parse(appSettings!.BackgroundColor!));
            _mainWindow.settingsButton.Background = new SolidColorBrush(Color.Parse(appSettings!.BackgroundColor!));
            _mainWindow.settingsButton.BorderBrush = new SolidColorBrush(Color.Parse(appSettings!.BorderColor!));
            _mainWindow.settingsIcon.Foreground = new SolidColorBrush(Color.Parse(appSettings!.FontColor!));

            foreach (var button in _mainWindow.GetKeys().Values)
            {
                button.BorderBrush = new SolidColorBrush(Color.Parse(appSettings!.BorderColor!));
                if (button.Child is TextBlock textBlock)
                {
                    textBlock.Foreground = new SolidColorBrush(Color.Parse(appSettings!.FontColor!));
                }
            }
            this.Close();
        }
    }
}
