using System.Windows.Controls;
using CalendarNew.ViewModels;

namespace CalendarNew.Views;

public partial class ListDays : UserControl
{
    public ListDays(Frame frame)
    {
        InitializeComponent();
        this.DataContext = new ListDaysModel(frame);
    }
}