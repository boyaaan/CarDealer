namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Sales
    {
        public int Id { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Discount { get; set; }
        public Cars Car { get; set; }
        public int CarId { get; set; }
        public Customers Customer { get; set; }
        public int CustomerId { get; set; }


    }
}
