using BaseLibrary;
using EasyEat.DataTypes;
using EasyEat.HelperClasses;
using EasyEat.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyEat.Pages.HelperPages
{
    /// <summary>
    /// Логика взаимодействия для DishInfoPage.xaml
    /// </summary>
    public partial class DishInfoPage : Page
    {
        private Product _currentProduct;

        //private ListView _ProductsLV;

        public DishInfoPage(Product productData /*ref ListView ProductsLV*/)
        {
            InitializeComponent();

            _currentProduct = productData;
            //_ProductsLV = ProductsLV;

            DataContext = _currentProduct;
        }

        private void GrammBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                char numberChar;

                try
                {
                    numberChar = char.Parse(e.Key.ToString());
                }
                catch
                {
                    numberChar = char.Parse(e.Key.ToString().Remove(0, 1));
                }

                if (!char.IsDigit(numberChar))
                {
                    e.Handled = true;
                }
            }
            catch
            {
                if (e.Key != Key.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddedProductInfo productInfo = new AddedProductInfo();

            int gramms = GrammBox.Text == "" ? 1 : int.Parse(GrammBox.Text);

            productInfo.ProductName = _currentProduct.Name;
            productInfo.ProductCalories = Math.Round(_currentProduct.CaloriesPerGram * gramms, 2);



            ListManager.AddedProductsToDishList.Add(productInfo);


            //_ProductsLV.SelectedIndex = -1;

            //_ProductsLV.ItemsSource = null;


            ListManager.ProductsList.Where(x => x.Name == productInfo.ProductName).FirstOrDefault().IsEnabledProduct = false;
            //_ProductsLV.ItemsSource = ListManager.ProductsList;

            EatDishWindow.UpdateSourceProductLV();



            AnimationManager.UniversalAnimation(FrameManager.DishInfoFrame);
        }
    }
}
