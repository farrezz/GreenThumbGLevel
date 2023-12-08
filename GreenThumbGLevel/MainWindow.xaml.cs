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
using System.Numerics;

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
            Plant plant = (Plant)selectedItem.Tag;
           

            if (plant == null)
            {
                MessageBox.Show("Choose a plant from the list.", "Warning");
            }
            else
            {

                PlantDetailWindow plantDetailWindow = new(plant);
                plantDetailWindow.Show();
                Close();
           

            }
        }

        private void TxtSearchbar_TextChanged(object sender, TextChangedEventArgs e)
        {

            //FILTERAR i listviewn och inte i textbox
            //När användaren skriver i textrutan
            string searchBox = TxtSearchbar.Text.ToUpper();

            using (GreenThumbDbContext context = new())
            {
                //Generic Repository
                //GreenThumbRepository<Plant> plants = new(context);

                //plant repository
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
                lstPlantView.Items.Clear();
                //Distinct som tillåter att visa plants utan att upprepa alla i databasen.
                var plants = context.Plants.Distinct().ToList();
                var instruction = context.Instructions.Distinct().ToList();
;
                foreach (var plant in plants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.PlantName;
                    lstPlantView.Items.Add(item);
                   
                }

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            ListViewItem selectedItem = (ListViewItem)lstPlantView.SelectedItem;

            Plant plant = (Plant)selectedItem.Tag;
            //ERROR 

            if ( plant == null)
            {
                MessageBox.Show("Choose a plant from the list to delete.", "Warning");
            }
            else
            {
                GreenThumbDbContext context = new();
                GreenThumbRepository<Plant> removePlant = new(context);
                removePlant.Delete(plant.PlantName);
                context.SaveChanges();
                UpdateUi();
           
                    //lstPlantView.Items.Remove(deletePlant);
            }
        }
    }
}