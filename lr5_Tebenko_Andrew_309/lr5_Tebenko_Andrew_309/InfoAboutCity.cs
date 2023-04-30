using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5_Tebenko_Andrew_309
{
    internal class InfoAboutCity
    {
        public int temperature { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int cloudCover { get; set; }
        public int feelsLike { get; set; }
        public int visibility { get; set; }

        public override string ToString()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendLine($"Temperature in the city - {temperature}°C");
            stringbuilder.AppendLine("-----------");
            stringbuilder.AppendLine($"Pressure in the city {pressure} mb");
            stringbuilder.AppendLine("-----------");
            stringbuilder.AppendLine($"Humidity in the city - {humidity}%");
            stringbuilder.AppendLine("-----------");
            stringbuilder.AppendLine($"Cloud cover in the city - {cloudCover}%");
            stringbuilder.AppendLine("-----------");
            stringbuilder.AppendLine($"Feels like in the city - {feelsLike}°C");
            stringbuilder.AppendLine("-----------");
            stringbuilder.AppendLine($"Visibility in the city - {visibility} km");

            return stringbuilder.ToString();
        }

    }
}