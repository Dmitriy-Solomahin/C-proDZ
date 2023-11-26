using System.Text.Json;
using System.Xml.Serialization;

namespace Lesson2_9
{
    internal static class HomeWork
    {
        //Напишите приложение, конвертирующее произвольный JSON в XML. Используйте JsonDocument.

        public static void OutputXmlInConsol(WeatherInfoXml obj)
        {
            var seriolaze = new XmlSerializer(typeof(WeatherInfoXml));
            seriolaze.Serialize(Console.Out, obj);
        }
        public static WeatherInfoXml FindValueInJSON(string json)
        {
            WeatherInfoXml filejson = JsonSerializer.Deserialize<WeatherInfoXml>(json);
            return filejson;
        }
    }
    [XmlRoot("WeatherInfo")]
    public class WeatherInfoXml
    {
        [XmlElement("Current")]
        public WeatherXml Current { get; set; }


        [XmlArray("History")]
        [XmlArrayItem("Weather")]
        public WeatherXml[] History {  get; set; }
    }

    
    public class WeatherXml
    {
        [XmlElement("Time")]
        public DateTime Time { get; set; }
        [XmlElement("Temperature")]
        public double Temperature { get; set; }
        [XmlElement("Weathercode")]
        public int Weathercode { get; set; }
        [XmlElement("Windspeed")]
        public double Windspeed { get; set; }
        [XmlElement("Winddirection")]
        public int Winddirection { get; set; }
    }


}
