using System;
using Avalonia.Controls;
using Avalonia.Input;
using System.Collections.Generic;
using Avalonia.Media;
using System.IO;
using Newtonsoft.Json;
using KeyboardOverlay.Services;
using System.Diagnostics;

namespace KeyboardOverlay.Views;

public partial class MainWindow : Window
{
    // Dicionario para guardar teclas.
    private Dictionary<Key, Border> keyButtonMap = null!;
    private Dictionary<MouseButton, Border> MouseButtonMap = null!;

    // Guarda configurações atuais
    public AppSettings? Config = null;

    public MainWindow()
    {
        InitializeComponent();
        InitializeKeyButtonMap();
        InitializeMouseButtonMap();

        // Carrega configuracoes ao abrir janela
        var SettingsService = new SettingsService();
        SettingsService.LoadSettings();

        // Registra manipuladores de eventos
        // Keys
        this.AddHandler(KeyDownEvent, Main_Window_KeyDown, handledEventsToo: true);
        this.AddHandler(KeyUpEvent, Main_Window_KeyUp, handledEventsToo: true);

        // Mouse events
        this.AddHandler(PointerPressedEvent, MainWindowMouseDown, handledEventsToo: true);
        this.AddHandler(PointerReleasedEvent, MainWindowMouseUp, handledEventsToo: true);

    }

    // Mapeamento das teclas
    private void InitializeKeyButtonMap()
    {
        keyButtonMap = new Dictionary<Key, Border>
            {
                {Key.Q, qButton },
                {Key.W, wButton },
                {Key.E, eButton },
                {Key.R, rButton },
                {Key.T, tButton },
                {Key.A, aButton },
                {Key.S, sButton },
                {Key.D, dButton },
                {Key.F, fButton },
                {Key.Space, spaceButton },
                {Key.NumPad1, numpad1 },
                {Key.NumPad2, numpad2 },
                {Key.NumPad3, numpad3 },
                {Key.NumPad4, numpad4 },
                {Key.NumPad5, numpad5},
                {Key.NumPad6, numpad6 },
                {Key.NumPad7, numpad7 },
                {Key.NumPad8, numpad8 },
                {Key.Tab, tabButton },
                {Key.LeftShift, shiftButton},
                {Key.Z, zButton},
                {Key.X, xButton},
                {Key.C, cButton},
                {Key.V, vButton},
                {Key.LeftCtrl, ctrlButton},
                {Key.LeftAlt, altButton}
            };
    }

    // Mapeamento do mouse
    private void InitializeMouseButtonMap()
    {
        MouseButtonMap = new Dictionary<MouseButton, Border>
            {
                {MouseButton.Left, leftMouseButton },
                {MouseButton.Right, rightMouseButton },
            };
    }

    // Evento para detectar quando uma tecla é pressionada
    private void Main_Window_KeyDown(object? sender, KeyEventArgs e)
    {
        if (keyButtonMap.ContainsKey(e.Key))
        {
            keyButtonMap[e.Key].Background = SettingsService.HoverColor;

        }
    }


    // Evento para detectar quando uma tecla é solta
    private void Main_Window_KeyUp(object? sender, KeyEventArgs e)
    {
        if (keyButtonMap.ContainsKey(e.Key))
        {
            keyButtonMap[e.Key].Background = SettingsService.BackgroundColor;
        }
    }

    // Botao que abre configuracoes
    private void SettingsButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var settingsWindow = new SettingsWindow(this);
        settingsWindow.ShowDialog(this);
    }

    // Mouse pressed event
    private void MainWindowMouseDown(object? sender, PointerPressedEventArgs e)
    {
        var properties = e.GetCurrentPoint(this).Properties;

        // Verifica o botão pressionado diretamente
        if (properties.IsLeftButtonPressed)
        {
            if (MouseButtonMap.ContainsKey(MouseButton.Left))
            {
                MouseButtonMap[MouseButton.Left].Background = SettingsService.HoverColor;
            }
        }
        else if (properties.IsRightButtonPressed)
        {
            if (MouseButtonMap.ContainsKey(MouseButton.Right))
            {
                MouseButtonMap[MouseButton.Right].Background = SettingsService.HoverColor;
            }
        }
    }

    // Mouse released event
    private void MainWindowMouseUp(object? sender, PointerReleasedEventArgs e)
    {
        Debug.WriteLine("release click");

    }


    // Retorna dicionario de teclas
    public Dictionary<Key, Border> GetKeys()
    {
        return keyButtonMap;
    }
}