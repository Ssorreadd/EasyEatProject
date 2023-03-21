using Microsoft.Data.Sqlite;
using System.Collections.ObjectModel;

namespace BaseLibrary
{
    public static class BaseManager
    {
        private static string _connection = "Data Source=ex1.db";

        public static ObservableCollection<Product> GetProducts()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            using (var connectoin = new SqliteConnection(_connection))
            {

                connectoin.Open();
                SqliteCommand command = new SqliteCommand("Select * from Products", connectoin);

                var data = command.ExecuteReader();

                while (data.Read())
                {
                    products.Add(new Product
                    {
                        Id = int.Parse(data[0].ToString()),
                        Name = data[1].ToString(),
                        CaloriesPerGram = double.Parse(data[2].ToString())
                    });
                }

            }
            return products;
        }
    }


}