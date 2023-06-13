using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace BotanicalGardenAPP.Models
{
    public enum Place
    {
        Greenhouse,
        Ground,
    }
    public class PlantModel
    {
        public string PlantName { get; set; }
        public Place PlaceOfGrowth { get; set; }
        public string Frutiting { get; set; }
        public DateTime LandingTime { get; set; } = DateTime.Now;
        public string CountryOfOrigin { get; set; }
        public DateTime HarvestDate { get; set; } = DateTime.Now;
    }
}
