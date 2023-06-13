using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BotanicalGardenAPP.Models;
using Практика;
using Практика.Services;

namespace BotanicalGardenAPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\garderPlantList.json";
        private BindingList<PlantModel> garderPlantList;
        private FileIOService fileIOServicel;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOServicel = new FileIOService(PATH);

            garderPlantList = fileIOServicel.LoadData();
            /*
            //garderPlantList = new BindingList<PlantModel>()
            //{
            //    new PlantModel()
            //    {
            //        PlantName = "Лаконос американский",
            //        PlaceOfGrowth = Place.Greenhouse,
            //        Frutiting = "dfsg",
            //        LandingTime = DateTime.Now.AddDays(5),
            //        CountryOfOrigin = "Америка",
            //        HarvestDate = DateTime.Now.AddMonths(12)

            //    },
            //    new PlantModel()
            //    {
            //        PlantName = "Подорожник большой пурпурный",
            //        PlaceOfGrowth = Place.Greenhouse,
            //        Frutiting = "Что?",
            //        LandingTime = DateTime.Now.AddDays(14),
            //        CountryOfOrigin = "ССР",
            //        HarvestDate = DateTime.Now.AddMonths(28)
            //    },
            //    new PlantModel()
            //    {
            //        PlantName = "Очиток пурпурный",
            //        PlaceOfGrowth = Place.Ground,
            //        Frutiting = "fsdg",
            //        LandingTime = DateTime.Now.AddDays(75),
            //        CountryOfOrigin = "Нидерланды",
            //        HarvestDate = DateTime.Now.AddMonths(24)
            //    },
            //    new PlantModel()
            //    {
            //        PlantName = "Молочай огненный",
            //        PlaceOfGrowth = Place.Greenhouse,
            //        Frutiting = "sfd",
            //        LandingTime = DateTime.Now.AddDays(65),
            //        CountryOfOrigin = "Австрия",
            //        HarvestDate = DateTime.Now.AddMonths(27)
            //    },
            //    new PlantModel()
            //    {
            //        PlantName = "Кентрантус красный",
            //        PlaceOfGrowth = Place.Ground,
            //        Frutiting = "Что?",
            //        LandingTime = DateTime.Now.AddDays(85),
            //        CountryOfOrigin = "Мордор",
            //        HarvestDate = DateTime.Now.AddMonths(27)
            //    },
            //     new PlantModel()
            //    {
            //        PlantName = "Шаровница сердцевиднолистная",
            //        PlaceOfGrowth = Place.Ground,
            //        Frutiting = "xvbv",
            //        LandingTime = DateTime.Now.AddDays(5),
            //        CountryOfOrigin = "Австралия",
            //        HarvestDate = DateTime.Now.AddMonths(54)
            //    },
            //    new PlantModel()
            //    {
            //        PlantName = "Чудесный прудик",
            //        PlaceOfGrowth = Place.Greenhouse,
            //        Frutiting = "vcxb",
            //        LandingTime = DateTime.Now.AddDays(95),
            //        CountryOfOrigin = "Куба",
            //        HarvestDate = DateTime.Now.AddMonths(25)
            //    },
            //    new PlantModel()
            //    {
            //        PlantName = "Михения крапиволистная",
            //        PlaceOfGrowth = Place.Ground,
            //        Frutiting = "cxvb",
            //        LandingTime = DateTime.Now.AddDays(65),
            //        CountryOfOrigin = "Америка",
            //        HarvestDate = DateTime.Now.AddMonths(34)
            //    },
            //     new PlantModel()
            //    {
            //        PlantName = "Вульфения каринтская",
            //        PlaceOfGrowth = Place.Ground,
            //        Frutiting = "fds",
            //        LandingTime = DateTime.Now.AddDays(66),
            //        CountryOfOrigin = "Россия",
            //        HarvestDate = DateTime.Now.AddMonths(14)
            //    },
            //    new PlantModel()
            //    {
            //        PlantName = "Дармера щитовидная",
            //        PlaceOfGrowth = Place.Greenhouse,
            //        Frutiting = "ewr",
            //        LandingTime = DateTime.Now.AddDays(15),
            //        CountryOfOrigin = "Япония",
            //        HarvestDate = DateTime.Now.AddMonths(24)
            //    },
            //};
            */
            dgGarderList.ItemsSource = garderPlantList;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            fileIOServicel.SaveData(garderPlantList);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingList<PlantModel> sortPlantModels = new BindingList<PlantModel>();
            foreach (var item in garderPlantList)
            {
                if (item.HarvestDate.Year >= 2019 && item.Frutiting.ToLower() == "осень")
                    sortPlantModels.Add(item);

            }
            PrintWindow printWindow = new PrintWindow();
            printWindow.SortPlants = sortPlantModels;
            printWindow.Show();
            printWindow.AddDataDocument(garderPlantList.Count);

        }
    }
}
