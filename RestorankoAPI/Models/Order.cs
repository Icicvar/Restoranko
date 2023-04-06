namespace RestorankoAPI.Models
{
    public class Order
    {
        public int IDOrder { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public int WaiterID { get; set; }
    }
}
