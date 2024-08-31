using Avalonia.Media;
using KeyboardOverlay.Services;
using KeyboardOverlay.Views;

namespace KeyboardOverlay.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public SolidColorBrush FontColor => SettingsService.FontColor;
    public SolidColorBrush BorderColor => SettingsService.BorderColor;
    public SolidColorBrush BackgroundColor => SettingsService.BackgroundColor;
    public SolidColorBrush HoverColor => SettingsService.HoverColor;
#pragma warning restore CA1822 // Mark members as static
}
