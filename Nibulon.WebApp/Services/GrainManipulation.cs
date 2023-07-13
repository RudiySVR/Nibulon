using Newtonsoft.Json;
using Nibulon.WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nibulon.WebApp.Services
{
    public class GrainManipulation: IGrainManipulation
    {
        public List<Grain> ReadJson()
        {
            const string filepath = @"Data\grain.json";
            // Чтение файла
            string json = File.ReadAllText(filepath);

            // Десериализация строки в объект
            // Десериализация строки в объект
            List<Grain> data = JsonConvert.DeserializeObject<List<Grain>>(json);
            return data;
        }
        public void WriteJson(List<Grain> data)
        {
            const string filepath = @"Data\grain.json";
            // Сериализация объекта в строку
            string json = JsonConvert.SerializeObject(data);

            // Сохранение строки в файл
            File.WriteAllText(filepath, json);
            return;
        }
    }
}
