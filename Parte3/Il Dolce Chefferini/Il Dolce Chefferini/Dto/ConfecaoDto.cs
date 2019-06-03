using System;
using Il_Dolce_Chefferini.Models;

namespace Il_Dolce_Chefferini.Dto
{
    public class ConfecaoDto
    {

        public bool pre { get; set; }
        public Confecao confecao { get; set; }
       

        public ConfecaoDto(Confecao c)
        {
            confecao = c;
            pre = true;
        }
    }
}
