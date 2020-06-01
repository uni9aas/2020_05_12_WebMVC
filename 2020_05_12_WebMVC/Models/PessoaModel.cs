using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _2020_05_12_WebMVC.Models
{
    public class PessoaModel
    {
        public int PessoaID { get; set; }
        public string PessoaNome { get; set; }
        public string PessoaEmail { get; set; }
        public string PessoaTelefone { get; set; }

        readonly string connectionString = @"Data Source=DESKTOP-U84PPK5\SQLEXPRESS;Initial Catalog=Cadastro_MVC;Integrated Security=True";

        public void Salvar()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO tb_Pessoa VALUES(@PessoaNome, @PessoaEmail, @PessoaTelefone )", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PessoaNome", PessoaNome);
                sqlCmd.Parameters.AddWithValue("@PessoaEmail", PessoaEmail);
                sqlCmd.Parameters.AddWithValue("@PessoaTelefone", PessoaTelefone);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

    }
}
