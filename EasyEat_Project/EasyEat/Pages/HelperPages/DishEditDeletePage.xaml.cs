using EasyEat.DataTypes;
using EasyEat.HelperClasses;
using EasyEat.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyEat.Pages.HelperPages
{
    /// <summary>
    /// Логика взаимодействия для DishEditDeletePage.xaml
    /// </summary>
    public partial class DishEditDeletePage : Page
    {
        //private ListView _ProductsLV;
        private AddedProductInfo _currentProduct;

        public DishEditDeletePage(AddedProductInfo productData /*ref ListView ProductsLV*/)
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
                if (e.Key != Key.OemPeriod && e.Key != Key.Oem2)
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

            }
            catch
            {
                if (e.Key != Key.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = ListManager.AddedProductsToDishList.Where(x => x.ProductName == _currentProduct.ProductName).First();
            ListManager.AddedProductsToDishList.Remove(productForRemoving);


            //_ProductsLV.SelectedIndex = -1;
            //_ProductsLV.ItemsSource = null;


            ListManager.ProductsList.Where(x => x.Name == productForRemoving.ProductName).FirstOrDefault().IsEnabledProduct = true;

            EatDishWindow.UpdateSourceProductLV();

            //_ProductsLV.ItemsSource = ListManager.ProductsList;


            AnimationManager.UniversalAnimation(FrameManager.DishInfoFrame);
        }
    }
}
