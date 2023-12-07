using GreenThumbGLevel.Database;
using GreenThumbGLevel.Models;
using System;
using System.Collections.Generic;
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

namespace GreenThumbGLevel
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public AddPlantWindow()
        {
            InitializeComponent();
        }

        private void BtnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            string plantName = txtPlantName.Text;
            string plantOrigin = txtPlantOrigin.Text;
            string plantCare = txtPlantCare.Text;
            string? plantDescription = txtPlantDescription.Text;

            if (plantName == "" && plantCare == "")
            {
                MessageBox.Show("Please fill in the required information for the plant", "Warning!");
            }
            else if (plantName == "")
            {
                MessageBox.Show("Please add a name to your plant", "Warning!");
            }
            else if (plantCare == "")
            {
                MessageBox.Show("Please add information about care instruction", "Warning!");
            }
            else
            {

                //skapa en ny skötselråd
                Instruction instruction = new()
                {  
                    Description = plantCare,
                };
                //Skapa en ny Plant
                Plant plant = new()
                {
                    PlantName = plantName,
                    PlantDescription = plantDescription,
                    PlantOrigin = plantOrigin,
                };

                // Lägger till den nya plantan till databasen
                using (GreenThumbDbContext context = new())

                { //Kolla om det redan finns eller // messagebox
                    Plant? existingPlant = context.Plants.FirstOrDefault(p => p.PlantName == plant.PlantName);
                    if (existingPlant == null)
                    {
                        context.Plants.Add(plant);

                        //context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show($"A plant with the name '{plant.PlantName}' already exists.");
                    }

                }

            }
        }

        private void BtnAddReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
