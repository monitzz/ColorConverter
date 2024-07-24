using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.LogicalTree;
using System;
using System.Text.RegularExpressions;

namespace ColorConverter.Views;

public partial class MainWindow : Window
{
    private string[] rgbCode = Colors.Arrays.RgbArray;
    private string[] hexCode = Colors.Arrays.HexArray;

    public MainWindow()
    {
        InitializeComponent();
        AttachEventHandlers(this);
    }

    private void AttachEventHandlers(ILogical parent)
    {
        foreach (var child in parent.LogicalChildren)
        {
            if (child is TextBox textBox)
            {
                textBox.TextChanged += OnTextChanged;
                textBox.GotFocus += OnGotFocus;
            }
            else if (child is ILogical logicalChild)
            {
                AttachEventHandlers(logicalChild);
            }
        }
    }

    private void OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox)
        {

            try
            {
                string hexValue = Colors.Codes.HexCode;
                ColorPreview.Fill = new SolidColorBrush(Color.Parse(hexValue));
            }
            catch (FormatException)
            {
                ColorPreview.Fill = new SolidColorBrush(Color.Parse("#000000"));
            }

            switch (textBox.Name)
            {
                case "RgbRedText":
                case "RgbGreenText":
                case "RgbBlueText":
                    try
                    {
                        string[] rgb =
                        [
                            RgbRedText.Text!,
                            RgbGreenText.Text!,
                            RgbBlueText.Text!
                        ];

                        Colors.ConvertFrom.RgbToHex(rgb);
                    }
                    catch
                    {
                        textBox.Text = "0";
                    }
                    HexText.Text = String.Format(
                        "{0}{1}{2}",
                        hexCode[0],
                        hexCode[1],
                        hexCode[2]
                    );
                    break;
                case "HexText":
                    string pattern = @"[a-f0-9]";
                    string text = textBox.Text!;

                    if (text.Length == 6 && Regex.IsMatch(text, pattern))
                    {

                        string[] hex =
                        [
                            HexText.Text!.Substring(0, 2),
                            HexText.Text!.Substring(2, 2),
                            HexText.Text!.Substring(4, 2)
                        ];

                        Colors.ConvertFrom.HexToRgb(hex);
                    }
                    RgbRedText.Text = rgbCode[0];
                    RgbGreenText.Text = rgbCode[1];
                    RgbBlueText.Text = rgbCode[2];
                    break;
            }

            if (textBox.Text == "0")
            {
                textBox.SelectAll();
            }
        }
    }

    private void OnGotFocus(object? sender, GotFocusEventArgs e)
    {
        if (sender is TextBox textBox && textBox.IsFocused == true)
        {
            textBox.SelectAll();
        }
    }
}
