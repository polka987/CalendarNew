using System.Windows.Input;
using CalendarNew.Models;
using CalendarNew.Models.Helps;

namespace CalendarNew.ViewModels;

public class MainViewModel: BindingHelpers
{
    private object _currentView;

    public object CurrentView
    {
        get
        {
            return _currentView;
        }
        set
        {
            _currentView = value; OnPropertyChanged();
        }
    }
    
    public ICommand ListDaysCommand { get; set; }
    public ICommand SelectDaysCommand { get; set; }


    private void SelectDays(object obj) => CurrentView = new SelectDayModel();


    public MainViewModel()
    {

        SelectDaysCommand = new BindableCommand(SelectDays);
        
    }
}