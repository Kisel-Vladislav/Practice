using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotanicalGardenAPP.Models;
using Newtonsoft.Json;

namespace Практика.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<PlantModel> LoadData()
        {
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<PlantModel>();
            }

            using(StreamReader reader = new StreamReader(PATH)) 
            {
                string fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<PlantModel>>(fileText);
            }
        }
        public void SaveData(BindingList<PlantModel> garderPlantList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(garderPlantList);
                writer.WriteLine(output);
            }
        }
    }
}
