using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalendarNew.Models.Helps;

public class BindingHelpers: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}