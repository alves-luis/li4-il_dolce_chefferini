using System;
using Il_Dolce_Chefferini.Models;

namespace Il_Dolce_Chefferini.Dto
{
    public class AjudaDto
    {

        public bool pre { get; set; }
        public Confecao confecao { get; set; }
       

        public AjudaDto(Confecao c)
        {
            confecao = c;
            pre = false;

        }
    }
}
