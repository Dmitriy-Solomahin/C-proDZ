using System.Text.Json;
using System.Xml.Serialization;

namespace Lesson2_9
{
    internal static class ClassWork
    {
        public static void Ex1()
        {
            //Напишите класс в который можно десериализовать представленный XMl
            //var xml = "" +
            //    "<? xml version = \"1.0\" encoding = \"utf-8\" ?>" +
            //    "< Data.Root xmlns: xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns: xsd = \"http://www.w3.org/2001/XMLSchema\" >" +
            //        "< Data.Root.Names >" +
            //            "< Name > Name1 </ Name >" +
            //            "< Name > Name2 </ Name >" +
            //            "< Name > Name3 </ Name >" +
            //        "</ Data.Root.Names >" +
            //        "< Data.Entry LinkedEntry = \"Name1\" >" +
            //            "< Data.Name > Name2 </ Data.Name >" +
            //        "</ Data.Entry >" +
            //        "< Data_x0023_ExtendedEntry LinkedEntry = \"Name2\" >" +
            //            "< Data.Name > Name1 </ Data.Name >" +
            //            "< Data_x0023_Extended > NameOne </ Data_x0023_Extended >" +
            //        "</ Data_x0023_ExtendedEntry >" +
            //    "</ Data.Root >";


            DataRoot dataRoot = new DataRoot();
            dataRoot.Names = new string[] { "Name1", "Name2", "Name3" };

            dataRoot.Entry = new DataEntry[2];
            dataRoot.Entry[0] = new DataEntry();
            dataRoot.Entry[0].LinkedEntry = "Name1";
            dataRoot.Entry[0].Name = "Name2";

            dataRoot.Entry[1] = new DataX { LinkedEntry = "Name1", Name = "NameOne", DataExt = "NameOne" };

            var seriolaze = new XmlSerializer(typeof(DataRoot));
            seriolaze.Serialize(Console.Out, dataRoot);
        }

        public static void Ex2()
        {
            //Задача 2. С сайта о погоде была получена информация о текущей и прошлой (за три дня) погоде в виде JSON.
            //Напишите класс способный хранить представленную информацию.

            //var filejson = "{\"Current\":{\"Time\":\"2023-06-18T20:35:06.722127+04:00\",\"Temperature\":29,\"Weathercode\":1,\"Windspeed\":2.1,\"Winddirection\":1},\"History\":[{\"Time\":\"2023-06-17T20:35:06.77707+04:00\",\"Temperature\":29,\"Weathercode\":2,\"Windspeed\":2.4,\"Winddirection\":1},{\"Time\":\"2023-06-16T20:35:06.777081+04:00\",\"Temperature\":22,\"Weathercode\":2,\"Windspeed\":2.4,\"Winddirection\":1},{\"Time\":\"2023-06-15T20:35:06.777082+04:00\",\"Temperature\":21,\"Weathercode\":4,\"Windspeed\":2.2,\"Winddirection\":1}]}";

        }
        public static void Ex3()
        {
            //Задача 3. Напишите метод для поиска значений в JSON.В качестве JSON можно использовать JSON из предыдущего примера.
            //Метод должен принимать строку-название ключа и возвращать список найденных значений.
            //Используйте например JsonDocument.Parse

            var filejson = "{\"Current\":{\"Time\":\"2023-06-18T20:35:06.722127+04:00\",\"Temperature\":29,\"Weathercode\":1,\"Windspeed\":2.1,\"Winddirection\":1},\"History\":[{\"Time\":\"2023-06-17T20:35:06.77707+04:00\",\"Temperature\":29,\"Weathercode\":2,\"Windspeed\":2.4,\"Winddirection\":1},{\"Time\":\"2023-06-16T20:35:06.777081+04:00\",\"Temperature\":22,\"Weathercode\":2,\"Windspeed\":2.4,\"Winddirection\":1},{\"Time\":\"2023-06-15T20:35:06.777082+04:00\",\"Temperature\":21,\"Weathercode\":4,\"Windspeed\":2.2,\"Winddirection\":1}]}";

            List<string> list = new List<string>();
            list = FindValueInJSON(filejson);
            WeatherInfo weather = JsonSerializer.Deserialize<WeatherInfo>(filejson);
            List<string> FindValueInJSON(string json)
            {
                List<string> list = new List<string>();

                return list;
            }
        }
    }
}
    public class WeatherInfo
    {
        public Weather Current { get; set; }
        public List<Weather> WeatherList { get; set; }
    }

    public class Weather
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public int Weathercode { get; set; }
        public double Windspeed { get; set; }
        public int Winddirection { get; set; }
    }

    [XmlRoot("Data.Root")]
    public class DataRoot
    {
        [XmlArray("Data.Root.Name")]
        [XmlArrayItem("Name")]
        public string[] Names;

        [XmlElement(typeof(DataEntry))]
        [XmlElement(typeof(DataX))]
        public DataEntry[] Entry;

        //[XmlElement(typeof(DataX))]
        //public DataX X;
    }

    [XmlType("Data.Entry")]
    public class DataEntry
    {
        [XmlAttribute]
        public string LinkedEntry;
        [XmlElement("Data.Name")]
        public string Name;
    }

    [XmlType("Data#ExtendedEntry")]
    public class DataX : DataEntry
    {
        [XmlElement("Data#ExtendedEntry")]
        public string DataExt;
    }

    








