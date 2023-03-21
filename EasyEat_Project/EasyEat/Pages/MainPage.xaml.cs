using EasyEat.HelperClasses;
using EasyEat.Windows;
using MathModule;
using System;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasyEat.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DishLV.ItemsSource = ListManager.Dishes;

            User.NeededCalories = GetCalories();

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            MainCaloriesCount.Text = $"{Math.Round(User.AllDayCalories)}\\{Math.Round(User.NeededCalories)}";

            if (User.AllDayCalories > (User.NeededCalories + 600))
            {
                MishaPng.Opacity = 0;
                MishaTxt.Opacity = 0;
                MishaPng.Visibility = Visibility.Visible;
                MishaTxt.Visibility = Visibility.Visible;

                MishaStart();
                MishaStart2();
            }
        }

        private async void MishaStart()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(200);
                for (double i = 0.0; i <= 1.0; i += 0.02)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MishaPng.Opacity = i;
                        MishaTxt.Opacity = i;
                    });

                    Thread.Sleep(10);
                }

                Thread.Sleep(2000);
                for (double i = 1.0; i >= 0.0; i -= 0.02)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MishaPng.Opacity = i;
                        MishaTxt.Opacity = i;
                    });

                    Thread.Sleep(10);
                }

                Dispatcher.Invoke(() =>
                {
                    MishaPng.Opacity = 0;
                    MishaTxt.Opacity = 0;
                });

            });


        }

        private async void MishaStart2()
        {
            Thread.Sleep(200);

            await Task.Run(() =>
            {
                SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.Bad_To_The_Bone);
                soundPlayer.Play();
            });
        }




        private double GetCalories()
        {
            double neededCalories = 0;

            if (User.Gender == "Мужчина")
            {
                switch (User.WeightMode)
                {
                    case "Набрать":
                        neededCalories = CaloriesCalculator.MenGain(User.Weight, User.Height, User.Age, User.Activity);
                        break;
                    case "Сбросить":
                        neededCalories = CaloriesCalculator.MenLoss(User.Weight, User.Height, User.Age, User.Activity);
                        break;
                }
            }
            else if (User.Gender == "Женщина")
            {
                switch (User.WeightMode)
                {
                    case "Набрать":
                        neededCalories = CaloriesCalculator.WomenGain(User.Weight, User.Height, User.Age, User.Activity);
                        break;
                    case "Сбросить":
                        neededCalories = CaloriesCalculator.WomenLoss(User.Weight, User.Height, User.Age, User.Activity);
                        break;
                }
            }

            return neededCalories;
        }

        private void AddDish_Click(object sender, RoutedEventArgs e)
        {
            EatDishWindow eatDishWindow = new EatDishWindow();
            eatDishWindow.ShowDialog();

            UpdateTitle();
        }

        private void ParametrsButton_Click(object sender, RoutedEventArgs e)
        {
            AnimationManager.GoToPageAnimation();
        }
    }
}
