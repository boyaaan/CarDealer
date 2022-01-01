namespace CarDealer.Data.Models
{
    public class PartCars
    {
        public int CarId { get; set; }
        public Cars Car { get; set; }
        public int PartId { get; set; }
        public Parts Part { get; set; }
    }
}
