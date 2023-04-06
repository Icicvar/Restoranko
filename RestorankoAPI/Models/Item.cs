namespace RestorankoAPI.Models
{
    public class Item
    {
        public int IDItem { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public int BarmanID { get; set; }
    }
}
