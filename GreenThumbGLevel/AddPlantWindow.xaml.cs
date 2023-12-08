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
                //Skapa en ny Plant
                //En planta kan ha flera instruktioner. 
                //Instruction = new List<Instruction>() möjliggör att man kan lägga till i listan utan att behöva
                //skapa en ny kodblock av instruction.
                Plant plant = new()
                {
                    PlantName = plantName,
                    PlantDescription = plantDescription,
                    PlantOrigin = plantOrigin,
                    Instruction = new List<Instruction>()
                    {
                        new Instruction()
                        {
                            Description = plantCare
                        }
                    }
                };

                ////skapa en ny skötselråd
                //Instruction instruction = new()
                //{
                //    Description = plantCare,
                //    Pnat
                //};

                // Lägger till den nya plantan till databasen
                using (GreenThumbDbContext context = new())

                { //Kollar om plantan finns i databasen. om inte, en ny planta skapas// messagebox
                    Plant? existingPlant = context.Plants.FirstOrDefault(p => p.PlantName == plant.PlantName);
                    if (existingPlant == null)
                    {
                        context.Plants.Add(plant);
                        //Lägger till skötselråd.
                        //context.Instructions.Add(instruction);
                        MessageBox.Show("A plant has been successfully added to list!", "Successful");
                        context.SaveChanges();
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
