using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
using System.Windows.Shapes;
using BotanicalGardenAPP;
using BotanicalGardenAPP.Models;

namespace Практика
{
    /// <summary>
    /// Логика взаимодействия для PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        public BindingList<PlantModel> SortPlants {get; set; }
        public PrintWindow()
        {
            InitializeComponent();
            
        }
        public void AddDataDocument(double allPlantsCount)
        {
            PageContent pageContent = new PageContent();
            StackPanel stackPanel = new StackPanel();
            FixedPage page = new FixedPage();

            page.Children.Add(stackPanel);

            DataGrid dg1 = new DataGrid();
            dg1.IsReadOnly = true;
            dg1.HeadersVisibility = DataGridHeadersVisibility.None;
            dg1.ItemsSource = SortPlants;

            stackPanel.Margin = new Thickness(20);
            stackPanel.Children.Add(dg1);
            stackPanel.Children.Add(new TextBlock() { Text = "От общего количества " +  (SortPlants.Count/allPlantsCount)*100 + '%'});

            pageContent.Child = page;
            fixDoc.Pages.Add(pageContent);
        }
    }
}
