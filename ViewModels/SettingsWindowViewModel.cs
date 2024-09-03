using Avalonia.Media;
using KeyboardOverlay.Services;

namespace KeyboardOverlay.ViewModels;

public partial class SettingsWindowViewModel : ViewModelBase
{
    public SolidColorBrush FontColor => SettingsService.FontColor;
    public SolidColorBrush BorderColor => SettingsService.BorderColor;
    public SolidColorBrush BackgroundColor => SettingsService.BackgroundColor;
    public SolidColorBrush HoverColor => SettingsService.HoverColor;
}
