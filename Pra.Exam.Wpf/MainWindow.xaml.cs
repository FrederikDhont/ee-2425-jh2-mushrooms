using Pra.Exam.Core.Services;
using System.Windows;
using System.Windows.Controls;

namespace Pra.Exam.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double compostSupply = 10;
        ForestService forest;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            forest = new ForestService(true); // Create new forest with sample data
            UpdateForestListInGui(); // Show mushrooms in GUI
        }

        // Logic methods

        // GUI methods
        void UpdateForestListInGui()
        {
            lstForest.ItemsSource = forest.Mushrooms;
        }

        // Event handlers
        private void LstForest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BtnCycleDays_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPickMushroom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SlrGlobalGrowthRate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void btnGiveCompost_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReproduce_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}