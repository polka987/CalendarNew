namespace CalendarNew.Models.Helps;

public class Parser
{
    public static (int, int) ParseDate(string date)
    {
        string[] dateParse = date.Split('.');
        return (Convert.ToInt32(dateParse[1]), Convert.ToInt32(dateParse[2]));
    }
}