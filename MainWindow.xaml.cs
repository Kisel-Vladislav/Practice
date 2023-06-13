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
