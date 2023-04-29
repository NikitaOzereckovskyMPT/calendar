using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WpfCalendar
{
    public static class DataStorage
    {
        private static string dataFilePath = "data.json";

        public static void SaveData(List<UserSelection> data)
        {
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(data));
        }

        public static List<UserSelection> LoadData()
        {
            if (File.Exists(dataFilePath))
            {
                return JsonConvert.DeserializeObject<List<UserSelection>>(File.ReadAllText(dataFilePath));
            }
            else
            {
                return new List<UserSelection>();
            }
        }
    }
}
