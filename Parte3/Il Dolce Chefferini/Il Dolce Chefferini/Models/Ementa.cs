using System.ComponentModel.DataAnnotations;

namespace Il_Dolce_Chefferini.Models
{
    public class Ementa
    {
        [Key]
        public int userId { get; set; }

        public Ementa()
        {
            userId = 1;
        }
    }
}