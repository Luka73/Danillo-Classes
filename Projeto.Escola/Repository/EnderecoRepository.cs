using Projeto.Escola.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Escola.Repository
{
    public class EnderecoRepository
    {
        private readonly string connectionString;

        public EnderecoRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["aula"].ConnectionString;
        }

        public void Insert(Endereco endereco)
        {
            string query = "insert into Endereco values(@Rua, @Numero, "
                + "@Cep, @Complemento)";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Rua", endereco.Rua);
                command.Parameters.AddWithValue("@Numero", endereco.Numero);
                command.Parameters.AddWithValue("@Cep", endereco.Cep);
                command.Parameters.AddWithValue("@Complemento", endereco.Complemento);
                command.ExecuteNonQuery();
            }
        }

       public List<Endereco> SelectAll()
        {
            string query = "select * from endereco";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                List<Endereco> lista = new List<Endereco>();

                while(reader.Read())
                {
                    Endereco endereco = new Endereco();
                    endereco.Rua = Convert.ToString(reader["Rua"]);
                    endereco.Numero = Convert.ToInt32(reader["Numero"]);
                    endereco.Cep = Convert.ToString(reader["Cep"]);
                    endereco.Complemento = Convert.ToString(reader["Complemento"]);
                    lista.Add(endereco);
                }

                return lista;
            }
        }
    }
}
