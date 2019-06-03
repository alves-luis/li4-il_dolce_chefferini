using System;
namespace Il_Dolce_Chefferini.Dto
{
    public class AvaliacaoDto
    {

        public bool usouAjuda { get; set; }
        public int idConfecao { get; set; }
        public int? dificuldade { get; set; }
        public int? ajuda {get; set; }
        public int? satisfacao {get; set; }
                       
                               
        public AvaliacaoDto(int iDConfecao)
        {
            idConfecao = iDConfecao;
            dificuldade = null;
            ajuda = null;
            satisfacao = null;
            usouAjuda = false;

        }
        
        public bool AllSelected()
        {
            if (null != dificuldade && null != satisfacao)
            {
                if(usouAjuda && null!= ajuda || !usouAjuda && null==ajuda)
                    return true;

            }
            return false;
        }
    }
}
