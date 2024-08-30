using System;
using Avalonia.Controls;
using Avalonia.Input;
using System.Collections.Generic;
using Avalonia.Media;
using System.IO;

namespace KeyboardOverlay.Views;

public partial class MainWindow : Window
{
    // Dicionario para guardar teclas.
    private Dictionary<Key, Border> keyButtonMap = null!;

    public MainWindow()
    {
        InitializeComponent();
        InitializeKeyButtonMap();

        // Registra manipuladores de eventos
        this.AddHandler(KeyDownEvent, Main_Window_KeyDown, handledEventsToo: true);
        this.AddHandler(KeyUpEvent, Main_Window_KeyUp, handledEventsToo: true);

    }

    // Metodo que faz o mapeamento das teclas
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
                {Key.NumPad9, numpad9 }
            };
    }

    // Evento para detectar quando uma tecla é pressionada
    private void Main_Window_KeyDown(object? sender, KeyEventArgs e)
    {
        if (keyButtonMap.ContainsKey(e.Key))
        {
            keyButtonMap[e.Key].Background = Brushes.Cyan;

        }
    }


    // Evento para detectar quando uma tecla é solta
    private void Main_Window_KeyUp(object? sender, KeyEventArgs e)
    {
        if (keyButtonMap.ContainsKey(e.Key))
        {
            keyButtonMap[e.Key].Background = Brushes.Black;
        }
    }

    private void SettingsButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var settingsWindow = new SettingsWindow();
        settingsWindow.ShowDialog(this);
    }
}