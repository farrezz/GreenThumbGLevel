using System.Text;
using Microsoft.VisualBasic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GreenThumbGLevel.Models;
using GreenThumbGLevel.Database;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GreenThumbGLevel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateUi();
        }

        private void btnAddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new();
            addPlantWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstPlantView.SelectedItem;

            if (selectedItem == null)
            {
                MessageBox.Show("Choose a plant from the list.", "Warning");
            }
            else
            {
                Plant plant = (Plant)selectedItem.Tag;

                PlantDetailWindow plantDetailsWindow = new(plant);
                plantDetailsWindow.Show();
                Close();

            }
        }

        private void TxtSearchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //När användaren skriver i textrutan
            string searchBox = TxtSearchbar.Text.ToUpper();

            using (GreenThumbDbContext context = new())
            {
                //Generic Repository
                //GreenThumbRepository<Plant> plants = new(context);

                Repository plants = new(context);

                var GetAllPlants = plants.GetAll();

                lstPlantView.Items.Clear();
                var filterPlants = GetAllPlants.Where(p => p.PlantName.ToUpper().Contains(searchBox));
                foreach (var plant in filterPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.PlantName;

                    lstPlantView.Items.Add(item);
                }

            }
        }


        private void UpdateUi()
        {
            using (GreenThumbDbContext context = new())
            {
                //Distinct som tillåter att visa plants utan att upprepa alla i databasen.
                var plants = context.Plants.Distinct().ToList();

                foreach (var plant in plants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    //Visar Plantans namn och ursprung
                    lstPlantView.Items.Add($"{plant.PlantName}");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstPlantView.SelectedItem;

            if (selectedItem == null)
            {
                MessageBox.Show("Choose a plant from the list to delete.", "Warning");
            }
            else
            {
                using (GreenThumbDbContext context = new())
                {
                    Repository plants = new(context);

                    plants.Delete(selectedItem.Name);
                    
                    lstPlantView.Items.Remove(selectedItem);

                }
            }
        }
    }
}