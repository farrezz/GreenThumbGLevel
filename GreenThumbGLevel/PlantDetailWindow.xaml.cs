using GreenThumbGLevel.Database;
using GreenThumbGLevel.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for PlantDetailWindow.xaml
    /// </summary>
    public partial class PlantDetailWindow : Window
    {
        public PlantDetailWindow(Plant plant)
        {
            InitializeComponent();


            using (GreenThumbDbContext context = new())
            {
                //Repository plantDetails = new(context);

                //var plantDetail = plantDetails.GetbyName(plant.PlantName);
                //var plants = context.Plants.Distinct().Include(a => a.Instruction);

                if (plant != null)
                {
                    txtPlantName.Text = plant.PlantName;
                    txtPlantDescription.Text = plant.PlantDescription;
                    txtPlantOrigin.Text = plant.PlantOrigin;

                    foreach (var instruction in plant.Instruction)
                    {
                        ListViewItem item = new();
                        item.Tag = instruction;
                        item.Content= instruction.Description;
                        lstPlantCare.Items.Add(item);
                        
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
