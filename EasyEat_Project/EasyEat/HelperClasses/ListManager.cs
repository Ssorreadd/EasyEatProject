using BaseLibrary;
using EasyEat.DataTypes;
using System.Collections.ObjectModel;

namespace EasyEat.HelperClasses
{
    public static class ListManager
    {
        public static ObservableCollection<DishInfo> Dishes {get; set;} = new ObservableCollection<DishInfo>();
        public static ObservableCollection<Product> ProductsList { get; set; }
        public static ObservableCollection<AddedProductInfo> AddedProductsToDishList { get; set; }

        public static void SetDefaultInfo()
        {
            ProductsList = BaseManager.GetProducts();
            AddedProductsToDishList = new ObservableCollection<AddedProductInfo>();
        }

        public static void ClearAll()
        {
            ProductsList.Clear();
            AddedProductsToDishList.Clear();
            Dishes.Clear();
        }
    }
}
