using System.Runtime.ConstrainedExecution;

namespace DLL.Models
{
    public class Crypto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Capitalization { get; set; }
        public decimal TotalQuantity { get; set; }
        public char UnitsOfMeasurementQuantity { get; set; }
        public float PercentPer1Hour { get; set; }
        public float PercentPer24Hour { get; set; }
        public float PercentPer7Day { get; set; }
        public bool IsFavorite { get; set; }

    }
}
