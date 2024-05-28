using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CalendarNew.Models;
using CalendarNew.Models.Helps;
using CalendarNew.Views;

namespace CalendarNew.ViewModels;

public class ListDaysModel: BindingHelpers
{
    
    public BindableCommand NextMouth_Click { get; set; }
    public BindableCommand BackMouth_Click { get; set; }


    private List<Plitka> _plitki;
 
    public List<Plitka> Plitki
    {
        get { return _plitki; }
        set
        {
            _plitki = value; OnPropertyChanged(nameof(SelectDate));  
        }
    }
    
    private DateTime _selectDate = DateTime.Now.Date;
    public DateTime SelectDate
    {
        get { return _selectDate; }
        set { _selectDate = value; OnPropertyChanged(nameof(SelectDate));  }
    }
    
    public Frame thisFrame;
    public ListDaysModel(Frame frame)
    {
        NextMouth_Click = new BindableCommand(_ => NextMouth());
        BackMouth_Click = new BindableCommand(_ => BackMouth());
        thisFrame = frame;
        
        ChangeUserControls();
    }


    private void NextMouth()
    {
        SelectDate = _selectDate.AddMonths(1);
        OnPropertyChanged(nameof(SelectDate));
        ChangeUserControls();
        OnPropertyChanged(nameof(Plitki));
    }
    
    private void BackMouth()
    {
        SelectDate = _selectDate.AddMonths(-1);
        OnPropertyChanged(nameof(SelectDate));
        
        ChangeUserControls();
        OnPropertyChanged(nameof(Plitki));
    }


    private void ChangeUserControls()
    { 
        _plitki = new List<Plitka>();
        string vr = _selectDate.ToString().Substring(0, 10);
        (int, int) date = Parser.ParseDate(vr);
        int days = DateTime.DaysInMonth(date.Item2, date.Item1);

        string ifDate = $"{date.Item1}.{date.Item2}";
        List<DayClass> serDays = Serializer.Des<List<DayClass>>()?? new List<DayClass>();


        for (int i = 1; i <= days; i++)
        {
            Plitka p = new Plitka();
            p.datelbl.Content = i.ToString();
            _plitki.Add(p);
            p.MouseDown += Element;
            if (serDays.Count != 0)
            {
                foreach (DayClass j in serDays)
                {
                    var datetme = new DateTime(date.Item2, date.Item1, i).ToString().Substring(0, 10);

                    if (datetme == j.date.Substring(0, 10))
                    {
                        var uri = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory() + $"\\..\\..\\..\\{j.item.imgPath}"));
                        p.ImgSt.Source = new BitmapImage(uri);
                    }
                }
            }
        }
    }
    
    private void Element(object sender, RoutedEventArgs e)
    {
        thisFrame.Content = new SelectDay(_selectDate, thisFrame);
    }
}