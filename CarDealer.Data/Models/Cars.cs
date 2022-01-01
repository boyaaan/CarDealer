namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Cars
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        
        [Range(0,long.MaxValue)]
        public long TravelledDistance { get; set; }
        public List<Sales> Sales { get; set; } = new List<Sales>();
        public List<PartCars> Parts { get; set; } = new List<PartCars>();

    }
}
