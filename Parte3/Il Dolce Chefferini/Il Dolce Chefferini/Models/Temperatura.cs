using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    [Table("Temperatura")]
    public class Temperatura
    {
        public Temperatura()
        {
            id = 1;
            nome = "Quente";
        }

        public int id { get; set; }
        public string nome { get; set; }
    }
}