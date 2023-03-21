using BaseLibrary;
using EasyEat.DataTypes;
using EasyEat.HelperClasses;
using EasyEat.Pages.HelperPages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EasyEat.Windows
{
    /// <summary>
    /// Логика взаимодействия для EatDishWindow.xaml
    /// </summary>
    public partial class EatDishWindow : Window
    {
        public static UpdateDelegate UpdateSourceProductLV;

        public delegate void UpdateDelegate();
        public EatDishWindow()
        {
            InitializeComponent();

            try
            {
                UpdateSourceProductLV = UpdateSource;

                ListManager.SetDefaultInfo();

                DishLV.ItemsSource = ListManager.AddedProductsToDishList;

                FrameManager.DishInfoFrame = EatDishWindowFrame;

                UpdateSource();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                Close();
            }
           
        }

        private void UpdateSource()
        {
            ProductsLV.ItemsSource = null;

            var source = ListManager.ProductsList;

            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                ProductsLV.ItemsSource = source.Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower()));
            }
            else
            {
                ProductsLV.ItemsSource = source;
            }

        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSource();
        }

        private void ProductsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DishLV.SelectedIndex = -1;

            if (ProductsLV.SelectedIndex != -1)
            {
                AnimationManager.UniversalAnimation(EatDishWindowFrame, new DishInfoPage(ProductsLV.SelectedItem as Product /* ref ProductsLV*/));
            }
            else
            {
                AnimationManager.UniversalAnimation(EatDishWindowFrame);
            }

            SetEatDishButtonVisibility();
        }

        private void GetAllCalories()
        {
            AllCalories.Text = "0";

            if (ListManager.AddedProductsToDishList.Count > 0)
            {
                foreach (var product in ListManager.AddedProductsToDishList)
                {
                    AllCalories.Text = (Math.Round(double.Parse(AllCalories.Text) + product.ProductCalories, 2)).ToString();
                }
            }
       
        }

        private void DishLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductsLV.SelectedIndex = -1;

            if (DishLV.SelectedIndex != -1)
            {
                AnimationManager.UniversalAnimation(EatDishWindowFrame, new DishEditDeletePage(DishLV.SelectedItem as AddedProductInfo /*ref ProductsLV*/));

                //ProductsLV.SelectedIndex = -1;
            }
            else
            {
                AnimationManager.UniversalAnimation(EatDishWindowFrame);
            }

            SetEatDishButtonVisibility();
        }

        private void SetEatDishButtonVisibility()
        {
            if (ListManager.AddedProductsToDishList.Count > 0 && !string.IsNullOrWhiteSpace(DishNameBox.Text))
            {
                EatDishButton.Visibility = Visibility.Visible;
            }
            else
            {
                EatDishButton.Visibility = Visibility.Hidden;
            }

            GetAllCalories();
        }

        private void DishNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEatDishButtonVisibility();
        }

        private void EatDishButton_Click(object sender, RoutedEventArgs e)
        {
            User.AllDayCalories = Math.Round(User.AllDayCalories + double.Parse(AllCalories.Text), 2);

            ListManager.Dishes.Add(new DishInfo()
            {
                Name = DishNameBox.Text,
                Calories = Math.Round(double.Parse(AllCalories.Text), 2)
            });

            this.Close();
        }
    }
}