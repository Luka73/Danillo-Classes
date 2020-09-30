using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_Game.Classes.Entities
{
    //Classe para gerar um numero randômico que seja uso em pontos
    //do programa como no momento de selecionar uma fruta aleatoria
    //para o cenário
    public class RNG : Random
    {
        private static RNG instance = null;
        private RNG() : base() { }

        public static Random Get_Instance() //Singleton
        {
            if(instance == null)
            {
                instance = new RNG();
            }
            return instance;
        }
       
    }
}
