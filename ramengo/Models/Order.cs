namespace ramengo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BrothId { get; set; }
        public int ProteinId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Navigation Properties
        public Broth Broth { get; set; }
        public Protein Protein { get; set; }
    }
}
