namespace BaseLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double CaloriesPerGram { get; set; }


        public bool IsEnabledProduct { get; set; } = true;
    }
}