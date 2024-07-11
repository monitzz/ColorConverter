using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;

namespace ColorConverter.Views;

public partial class MainWindow : Window
{
    private const int MaxLength = 3;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnTextInput(object? sender, TextInputEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            Box.Text = "haai";
            if (!int.TryParse(e.Text, out _) || textBox.Text?.Length >= MaxLength)
            {
                e.Handled = true;
            }
        }
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Back || e.Key == Key.Delete)
        {
            e.Handled = false;
        }
    }
}
