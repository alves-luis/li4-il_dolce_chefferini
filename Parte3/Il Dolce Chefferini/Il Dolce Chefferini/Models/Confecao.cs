namespace Il_Dolce_Chefferini.Models
{
    public class Confecao
    {
        public int userId { get; set; }
        public Receita receita { get; set; }
        public Avaliacao avaliacao { get; set; }
        public bool usouAjuda { get; set; }
        public bool bemSucedida { get; set; }
    }
}