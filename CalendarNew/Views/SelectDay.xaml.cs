using System.Runtime.InteropServices.JavaScript;
using System.Windows.Controls;
using CalendarNew.ViewModels;

namespace CalendarNew.Views;

public partial class SelectDay : Page
{
    public SelectDay(DateTime date, Frame frame)
    {
        InitializeComponent();

        this.DataContext = new SelectDayModel(date, frame);

    }
}