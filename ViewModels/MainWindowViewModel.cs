using System;
using System.Globalization;
using Avalonia.Data.Converters;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaComboxItemStyleIssue.ViewModels;

public enum Category
{
    File, Folder, Url, Command
}

public partial class MainWindowViewModel : ViewModelBase
{
    public Category[] Categories { get; } = Enum.GetValues<Category>();

    [ObservableProperty]
    private Category _category = Category.Command;
}

public class CategoryNameConvertor : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Category category)
        {
            return category switch
            {
                Category.File => "文件",
                Category.Folder => "文件夹",
                Category.Url => "网址",
                Category.Command => "命令",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}