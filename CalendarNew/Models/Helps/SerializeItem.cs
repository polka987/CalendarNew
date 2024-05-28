namespace CalendarNew.Models.Helps;

public class SerializeItem
{
     public static void MakeSerClass(string date, string path, string name)
        {
            List<DayClass> days = Serializer.Des<List<DayClass>>()?? new List<DayClass>();
            List<string> dates = new List<string>();

            foreach (DayClass i in days)
            {
                dates.Add(i.date);
            }

            List<DayClass> newDays = new List<DayClass>();
            if (days.Count != 0)
            {
                if (dates.Any(date.Contains))
                {
                    foreach (DayClass dayClass in days)
                    {
                        if (date == dayClass.date)
                        {
                            DayClass day = new DayClass();
                            DayItem item = new DayItem();

                            item.imgPath = path;
                            item.name = name;

                            day.date = date;
                            day.item = item;

                            newDays.Add(day);
                        }
                        else
                        {
                            newDays.Add(dayClass);
                        }
                    }
                }
                else
                {
                    foreach (DayClass dayClass in days)
                    {
                        newDays.Add(dayClass);
                    }
                    DayClass day = new DayClass();
                    DayItem item = new DayItem();

                    item.imgPath = path;
                    item.name = name;

                    day.date = date;
                    day.item = item;

                    newDays.Add(day);
                }
            }
            else
            {
                DayClass day = new DayClass();
                DayItem item = new DayItem();

                item.imgPath = path;
                item.name = name;

                day.date = date;
                day.item = item;

                newDays.Add(day);
            }
            

            Serializer.Ser(newDays);
    }
}