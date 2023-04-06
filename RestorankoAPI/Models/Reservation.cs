namespace RestorankoAPI.Models
{
    public class Reservation
    {
        public int IDReservation { get; set; }
        public DateTime DateReservation { get; set; }
        public int TableID { get; set; }
        public int OrderID { get; set; }
        public int GuestID { get; set; }
    }
}
