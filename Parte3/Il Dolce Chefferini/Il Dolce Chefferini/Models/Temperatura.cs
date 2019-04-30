namespace Il_Dolce_Chefferini.Models
{
    public class Temperatura
    {
        public int id { get; set; }
        public string nome { get; set; }

        public Temperatura()
        {
            id = 1;
            nome = "Quente";
        }
    }
}