using System.IO;
using Newtonsoft.Json;

namespace CalendarNew.Models.Helps;

public class Serializer
{
    private static string path = Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\JsonFiles\\data.json");
    //Конверт в джэйсон
    public static void Ser<T>(List<T> obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        File.WriteAllText(path, json);
    }

    //Приведение к классу от джэйсона
    public static T Des<T>()
    {
        string json = File.ReadAllText(path);
        T dates = JsonConvert.DeserializeObject<T>(json);
        return dates;
    }
}