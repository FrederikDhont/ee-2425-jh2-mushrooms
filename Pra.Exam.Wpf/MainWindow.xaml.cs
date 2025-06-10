﻿using Pra.Exam.Core.Entities;
using Pra.Exam.Core.Interfaces;
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
        BasketService basket;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            forest = new ForestService(true); // Create new forest with sample data
            basket = new BasketService(); // Create new basket
            UpdateForestListInGui(); // Show mushrooms in GUI
        }

        // Logic methods

        // GUI methods
        void UpdateForestListInGui()
        {
            lstForest.ItemsSource = forest.Mushrooms;
        }

        void UpdateBasketListInGui()
        {
            lstBasket.ItemsSource = basket.Mushrooms;
        }

        // Event handlers
        private void LstForest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstForest.SelectedItem is IHallucinogenic hallucinogenic)
            {
                lblHallucinogenicEffects.Content = hallucinogenic.GetEffectDescription();
            }
            else
            {
                lblHallucinogenicEffects.Content = "";
            }
        }
        private void BtnCycleDays_Click(object sender, RoutedEventArgs e)
        {
            int numOfDays;
            Int32.TryParse(txtNumberOfCycles.Text, out numOfDays);

            foreach (Mushroom mushroom in forest.Mushrooms)
            {
                mushroom.Grow(numOfDays);
            }

            UpdateForestListInGui();
        }

        private void BtnPickMushroom_Click(object sender, RoutedEventArgs e)
        {
            Mushroom selectedMush = (Mushroom)lstForest.SelectedItem;
            if (selectedMush.IsReadyToPick())
            {
                forest.Pick(selectedMush);
                UpdateForestListInGui();
                try
                {
                    basket.AddMushroom(selectedMush);
                    UpdateBasketListInGui();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kan niet geplukt worden");
            }

        }

        private void SlrGlobalGrowthRate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mushroom.GlobalGrowthRate = (double)slrGlobalGrowthRate.Value;
        }

        private void btnGiveCompost_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReproduce_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}