using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using CalendarNew.Models;
using CalendarNew.Models.Helps;
using CalendarNew.Views;

namespace CalendarNew.ViewModels;

public class SelectDayModel : BindingHelpers
{
    private bool _gustaBtn;
    public bool GustaBtn
    {
        get { return _gustaBtn; }
        set { _gustaBtn = value; OnPropertyChanged(nameof(GustaBtn)); }
    }
    
    private bool _okayBtn;
    public bool OkayBtn
    {
        get { return _okayBtn; }
        set { _okayBtn = value; OnPropertyChanged(nameof(OkayBtn)); }
    }
    
    private bool _pokerBtn;
    public bool PokerBtn
    {
        get { return _pokerBtn; }
        set { _pokerBtn = value; OnPropertyChanged(nameof(PokerBtn)); }
    }
    
    
    private bool _iBtn;
    public bool IBtn
    {
        get { return _iBtn; }
        set { _iBtn = value; OnPropertyChanged(nameof(IBtn)); }
    }
    
    public BuildListModel ListModel { get; set; }
    public SelectDayModel()
    {
        ListModel = new BuildListModel();
        ListModel.IsReversal = "Flip";
    }

    private BindableCommand _SaveBtn_Click;

    public BindableCommand SaveBtn_Click
    {
        get;
    }
    
    private BindableCommand _BackBtn_Click;

    public BindableCommand BackBtn_Click
    {
        get;
    }
    
    
    public DateTime _selectDate = DateTime.Now.Date;
    public DateTime SelectDate
    {
        get { return _selectDate; }
        set { _selectDate = value; OnPropertyChanged("SelectDate");  }
    }


    private Frame thisFrame;
    public SelectDayModel(DateTime date, Frame frame)
    {
        _selectDate = date;
        OnPropertyChanged("SelectDate");

        thisFrame = frame;
        
        SaveBtn_Click = new BindableCommand(_ => SaveData());
        BackBtn_Click = new BindableCommand(_ => Back());
    
    }

    public void SaveData()
    {
        if (_gustaBtn)
        {
            SerializeItem.MakeSerClass(_selectDate.ToString(), "//img//gusta.jpg", "gusta");
        }
        else if (_okayBtn)
        {
            SerializeItem.MakeSerClass(_selectDate.ToString(), "//img//ok.jpg", "okay");
        }
        else if (_pokerBtn)
        {
            SerializeItem.MakeSerClass(_selectDate.ToString(), "//img//poker.jpg", "poker");
        }
        else if (_iBtn)
        {
            SerializeItem.MakeSerClass(_selectDate.ToString(), "//img//you.jpg", "you");
        }
        thisFrame.Content = new ListDays(thisFrame);
    }

    public void Back()
    {
        thisFrame.Content = new ListDays(thisFrame);
    }
}