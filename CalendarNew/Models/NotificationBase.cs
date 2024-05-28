using System.ComponentModel;

namespace CalendarNew.Models;

public class NotificationBase : INotifyPropertyChanged
{
    
    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}