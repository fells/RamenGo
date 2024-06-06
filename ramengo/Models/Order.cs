namespace ramengo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BrothId { get; set; }

        public Broth Broth { get; set; }

        public int ProteinId { get; set; }

        public Protein Protein { get; set; }
        
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
