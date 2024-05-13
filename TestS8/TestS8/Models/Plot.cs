using System.ComponentModel.DataAnnotations;

namespace TestS8.Models
{
    public class Plot
    {
        [Key]
        public int IdPlot { get; set; }
        public string Chemin { get; set; }

    }
}
