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
    /// Interaction logic for PlantDetailWindow.xaml
    /// </summary>
    public partial class PlantDetailWindow : Window
    {
        public PlantDetailWindow(Plant plant)
        {
            InitializeComponent();

            txtPlantName.Text = plant.PlantName;
            //txtPlantCare.Text = instructions.Description;
            txtPlantDescription.Text = plant.PlantDescription;
            txtPlantOrigin.Text = plant.PlantOrigin;

        }

        private void BtnAddReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
