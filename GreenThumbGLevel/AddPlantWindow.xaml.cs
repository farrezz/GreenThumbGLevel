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
            List <string> plantInstruction= new();

            if (plantName == "" && plantCare == "")
            {
                MessageBox.Show("Please fill in the required information for the plant", "Warning!");
            }
            else if (plantName == "")
            {
                MessageBox.Show("Please add a name to your plant", "Warning!");
            }
            //else if (plantCare == "")
            //{
            //    MessageBox.Show("Please add information about care instruction", "Warning!");
            //}
            else
            {

                //Alternativt sätt att skriva  utan att behöva ha en lista i Plant plant = new();
                //skapa en ny skötselråd
                foreach (var instructions in lstInstructionView.Items)
                {
                    Instruction instruction = new()
                    {
                        Description = plantCare,
                    };

                    instruction.Plant = plant;
                    plant.Instruction.Add(instruction);

                }

                //Skapa en ny Plant
                //En planta kan ha flera instruktioner. 
                //Instruction = new List<Instruction>() möjliggör att man kan lägga till i listan utan att behöva
                //skapa en ny kodblock av instruction.
                Plant plant = new()
                {
                    PlantName = plantName,
                    PlantDescription = plantDescription,
                    PlantOrigin = plantOrigin,
                    //Instruction = new List<Instruction>()
                    //{
                    //    new Instruction()
                    //    {
                    //        Description = plantCare
                    //    }
                    //}
                };

                foreach (var instructions in lstInstructionView.Items)
                {
                    Instruction instruction = new()
                    {
                        Description = plantCare,
                    };

                    instruction.Plant = plant;
                    plant.Instruction.Add(instruction);

                }


                // Lägger till den nya plantan till databasen
                using (GreenThumbDbContext context = new())

                { //Kollar om plantan finns i databasen. om inte, en ny planta skapas// messagebox
                    //FirstOrDefault metoden kollar första namte
                    Plant? existingPlant = context.Plants.FirstOrDefault(p => p.PlantName == plant.PlantName);
                    if (existingPlant == null)
                    {
                        context.Plants.Add(plant);
                        //Lägger till skötselråd.
                        //context.Instructions.Add(plantCare);
                        MessageBox.Show("A plant has been successfully added to list!", "Successful");
                        context.SaveChanges();

                        MainWindow mainWindow = new();
                        mainWindow.Show();
                        Close();
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

        private void BtnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            string instructions  = txtPlantCare.Text;
            lstInstructionView.Items.Add(instructions);
            txtPlantCare.Text = "";
        }
    }
}
