using Projeto.Escola.Entity;
using Projeto.Escola.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Escola
{
    public class Program
    {
        static void Main(string[] args)
        {
            Endereco obj = new Endereco();
            obj.Rua = "Rue Cadillac";
            obj.Numero = 4020;
            obj.Cep = "H1R1H8";
            obj.Complemento = "Proximo ao metro Cadillac";

            EnderecoRepository rep = new EnderecoRepository();
            rep.Insert(obj);
            Console.WriteLine("Endereço gravado com sucesso!");

            List<Endereco> lista = rep.SelectAll();
            foreach(var item in lista)
            {
                Console.WriteLine("Rua: " + item.Rua);
                Console.WriteLine("Numero: " + item.Numero);
                Console.WriteLine("Cep: " + item.Cep);
                Console.WriteLine("Complemento: " + item.Complemento);
                Console.WriteLine("*********************************");
            }
     
            Console.ReadKey();
        }
    }
}
