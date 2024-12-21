using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TreasureHuntRequestEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int N { get; set; }
        public int M { get; set; }
        public int P { get; set; }
        public string Matrix { get; set; }
        public double Result { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}