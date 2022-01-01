namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Parts
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public int Quantity { get; set; }
        public Suppliers Supplier { get; set; }
        public int SupplierId { get; set; }

        public List<PartCars> Cars = new List<PartCars>();

    }
}
