using System.Collections.ObjectModel;

namespace EasyEat.DataTypes
{
    public class AddedProductInfo
    {
        public string? ProductName { get; set; }
        public double ProductCalories { get; set; }

        //public static ObservableCollection<AddedProductInfo> AddedProducts = new ObservableCollection<AddedProductInfo>();
    }
}
