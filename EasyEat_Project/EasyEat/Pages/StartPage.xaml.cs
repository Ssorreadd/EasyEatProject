using EasyEat.DataTypes;
using EasyEat.HelperClasses;
using System.Windows.Controls;
using System.Collections.Generic;

namespace EasyEat.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();

            SetData();
        }

        public void SetData()
        {
            //List<GenderType> gendersForLV = new List<GenderType>
            //{
            //    new GenderType
            //    {
            //        SourceImage = Properties.Resources.man,
            //        TextContent = "Мужчина"
            //    },

            //    new GenderType { SourceImage = Properties.Resources.woman, TextContent = "Женщина" }
            //};


            //ChooseGenderLV.ItemsSource = gendersForLV;



            ChooseGenderLV.ItemsSource = new List<GenderType>
            {
                new GenderType
                {
                    SourceImage = Properties.Resources.man,
                    TextContent = "Мужчина"
                },

                new GenderType
                {
                    SourceImage = Properties.Resources.woman,
                    TextContent = "Женщина"
                }
            };
        }

        private void ChooseGenderLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChooseGenderLV.SelectedIndex != -1)
            {
                User.Gender = ((GenderType)ChooseGenderLV.SelectedItem).TextContent;
                AnimationManager.GoToPageAnimation(new PlanPage());
            }
        }

        private void Page_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == System.Windows.Visibility.Visible)
            {
                ChooseGenderLV.SelectedIndex = -1;
            }
        }
    }
}
