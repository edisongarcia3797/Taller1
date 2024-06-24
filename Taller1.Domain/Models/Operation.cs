namespace Taller1.Domain.Models
{
    public class Operation : Commons
    {
        public required string IdOperation { get; set; }
        public required string Description { get; set; }
        public required DateTime CreationDate { get; set; }
    }
}
