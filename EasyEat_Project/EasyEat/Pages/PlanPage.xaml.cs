using EasyEat.HelperClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EasyEat.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlanPage.xaml
    /// </summary>
    public partial class PlanPage : Page
    {
        private static bool[] _access = new bool[4] { false, false, false, false };

        public PlanPage()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AnimationManager.GoToPageAnimation();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            User.Weight = double.Parse(WeightBox.Text);
            User.Height = double.Parse(HeightBox.Text);
            User.Age = int.Parse(AgeBox.Text);

            AnimationManager.GoToPageAnimation(new MainPage());
        }


        private async void DisableButton(object sender)
        {
            ((Button)sender).Background = (Brush)(new BrushConverter().ConvertFrom("#F46412"));
            ((Button)sender).BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#983E0B"));

            ((Button)sender).IsEnabled = false;
        }

        private void EnableButton(object sender)
        {
            ((Button)sender).Background = (Brush)(new BrushConverter().ConvertFrom("#E79465"));
            ((Button)sender).BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#983E0B"));

            ((Button)sender).IsEnabled = true;
        }


        private void WeinghtLoss_Click(object sender, RoutedEventArgs e)
        {
            _access[0] = true;
            User.WeightMode = "Сбросить";

            DisableButton(sender);

            EnableButton(WeinghtGain);

            CheckAccess();
        }

        private void WeinghtGain_Click(object sender, RoutedEventArgs e)
        {
            _access[0] = true;

            User.WeightMode = "Набрать";

            DisableButton(sender);

            EnableButton(WeinghtLoss);

            CheckAccess();
        }

        private void WeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(WeightBox.Text))
            {
                _access[1] = true;
            }
            else
            {
                _access[1] = false;
            }
            CheckAccess();
        }

        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(HeightBox.Text))
            {
                _access[2] = true;
            }
            else
            {
                _access[2] = false;
            }
            CheckAccess();
        }

        private void AgeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AgeBox.Text))
            {
                _access[3] = true;
            }
            else
            {
                _access[3] = false;
            }

            CheckAccess();
        }

        private new void CheckAccess()
        {
            if (_access[0] == true && _access[1] == true && _access[2] == true && _access[3] == true)
            {
                NextButton.Visibility = Visibility.Visible;
            }
            else
            {
                NextButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
