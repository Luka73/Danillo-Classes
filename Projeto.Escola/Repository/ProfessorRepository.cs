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
    public class ProfessorRepository
    {
        private readonly string connectionString;

        public ProfessorRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["aula"].ConnectionString;
        }

        public void Insert(Professor professor)
        {
            string query = "insert into professor values(@Disciplina, @IdFuncionario)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Disciplina", professor.Disciplina);
                cmd.Parameters.AddWithValue("@IdFuncionario", professor.IdFuncionario);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Professor> SelectAll()
        {
            string query = "select * from professor";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Professor> lista = new List<Professor>();

                while(reader.Read())
                {
                    Professor professor = new Professor();
                    professor.Disciplina = Convert.ToString(reader["Disciplina"]);
                    professor.IdFuncionario = Convert.ToInt32(reader["IdFuncionario"]);
                    lista.Add(professor);
                }
                return lista;
            }
        }
    }
}
