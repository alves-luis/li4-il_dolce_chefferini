using System;
using Il_Dolce_Chefferini.Models;

namespace Il_Dolce_Chefferini.Dto
{
    public class AvaliacaoDto
    {

        public bool pre { get; set; }
        public Confecao confecao { get; set; }
       

        public AvaliacaoDto(Confecao c)
        {
            confecao = c;
            pre = false;

        }
    }
}
