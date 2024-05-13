using System.ComponentModel.DataAnnotations;

namespace TestS8.Models
{
    public class Modele
    {
        [Key]
        public int IdModele { get; set; }
        public int Accuracy { get; set; }
        public string Hyperparametre { get; set; }
        public string Nom { get; set; }
        public List<Plot> Plots { get; set; }

        public Modele()
        {
            Plots = new List<Plot>();
        }
    }
}
