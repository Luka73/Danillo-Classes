using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_Game.Classes.Entities
{
    //Classe para gerar um numero randomico que seja uso em pontos
    //do prograa como no momento de selecionar uma fruta aleatoria
    //para o cenário
    public class RNG: Random
    {
        private static RNG instance = null;
        private RNG(): base() { }

        public static Random Get_Instance()
        {
            if(instance == null)
            {
                instance = new RNG();
            }
            return instance;
        }
       
    }
}
