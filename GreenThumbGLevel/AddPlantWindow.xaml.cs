﻿using GreenThumbGLevel.Database;
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
            List <Instruction> plantInstruction= new();

            if (plantName == "" && plantCare == "")
            {
                MessageBox.Show("Please fill in the required information for the plant", "Warning!");
            }
            else if (plantName == "")
            {
                MessageBox.Show("Please add a name to your plant", "Warning!");
            }
            else
            {
                //skapar för en ny skötselråd 
                //Loppar igenom alla instruktioner som finns i ListView och lägger till
                //i plantans insruktioenr.
                foreach (var instructions in lstInstructionView.Items)
                {
                    ListViewItem item = (ListViewItem) instructions;
                    
                    Instruction instruction = (Instruction) item.Tag;
                    plantInstruction.Add(instruction);

                };

                //Skapa en ny Plant
                Plant plant = new()
                {
                    PlantName = plantName,
                    PlantDescription = plantDescription,
                    PlantOrigin = plantOrigin,
                    Instruction = plantInstruction
                };

                // Lägger till den nya plantan till databasen
                using (GreenThumbDbContext context = new())

                {   //Kollar om plantan finns i databasen. om inte, en ny planta skapas// messagebox
                    
                    Plant? existingPlant = context.Plants.FirstOrDefault(p => p.PlantName == plant.PlantName);
                    if (existingPlant == null)
                    {
                        context.Plants.Add(plant);
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
            //användaren skriver in instruktioner och läggs i instrction listan
            //som visas i ListViewn. 
            //rutan nollställs när man lägger till.
            string instructions  = txtPlantCare.Text;
            Instruction instruction = new()
            {
                Description = instructions,
            };
            //Objekt
            ListViewItem item = new();
            item.Tag = instruction;
            item.Content = instruction.Description;
            lstInstructionView.Items.Add(item);

            txtPlantCare.Text = "";
        }
    }
}
