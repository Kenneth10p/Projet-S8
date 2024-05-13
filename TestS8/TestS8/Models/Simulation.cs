using System.ComponentModel.DataAnnotations;

namespace TestS8.Models
{
    public class Simulation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Modele> Modeles { get; set; }

        public Simulation()
        {
            Modeles = new List<Modele>();
        }

    }
}