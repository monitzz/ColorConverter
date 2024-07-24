using ReactiveUI;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ColorConverter.ViewModels;

//public class MainWindowViewModel : ViewModelBase
//{
//#pragma warning disable CA1822 // Mark members as static
//    public string Greeting => "Welcome to Avalonia!";
//#pragma warning restore CA1822 // Mark members as static
//}

public class MainWindowViewModel : ReactiveObject
{
    private string _rText = "0";
    public string RText
    {
        get => _rText;
        set => this.RaiseAndSetIfChanged(ref _rText, ValidateText(value));
    }

    private string _gText = "0";
    public string GText
    {
        get => _gText;
        set => this.RaiseAndSetIfChanged(ref _gText, ValidateText(value));
    }

    private string _bText = "0";
    public string BText
    {
        get => _bText;
        set => this.RaiseAndSetIfChanged(ref _bText, ValidateText(value));
    }

    private string _hexText = "000000";
    public string HexadecimalText
    {
        get => _hexText;
        set => this.RaiseAndSetIfChanged(ref _hexText, ValidateText(value, 6, false));
    }

    private string ValidateText(string text, int maxLength = 3, bool isNumerical = true)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            text = "0";
        }

        string newText = "";

        if (isNumerical)
        {
            newText =  string.Concat(text.Where(char.IsDigit));
        }
        else if (Regex.IsMatch(text, @"[a-f0-9]"))
        {
            newText = text;
        }
        else
        {
            newText = "0";
        }

        if (newText.Length > maxLength)
        {
            newText = newText.Substring(0, maxLength);
        }

        return newText;
    }
}
