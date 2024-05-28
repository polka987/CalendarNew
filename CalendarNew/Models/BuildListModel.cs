using System.Runtime.Serialization;

namespace CalendarNew.Models;

[DataContract]
public class BuildListModel: BaseModel
{
    private string isreversal;
    [DataMember]
    public string IsReversal
    {
        get { return isreversal; }
        set
        {
            isreversal = value;
            NotifyPropertyChanged("IsReversal");
        }
    }
}