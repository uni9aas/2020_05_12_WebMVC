using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _2020_05_12_WebMVC.Models
{
    public class PessoaModel
    {
        // Campos / Atributos da classe:
        [DisplayName("ID")]
        public int PessoaID { get; set; }
        [DisplayName("Nome:")]
        public string PessoaNome { get; set; }
        [DisplayName("E-Mail:")]
        public string PessoaEmail { get; set; }
        [DisplayName("Telefone:")]
        public string PessoaTelefone { get; set; }

        // Atributo de conexão com BD:
        readonly string connectionString = @"Data Source=DESKTOP-U84PPK5\SQLEXPRESS;Initial Catalog=Cadastro_MVC;Integrated Security=True";

        // Método INSERT:
        public void Salvar()
        {
            // Conexão com banco de dados:
            using (SqlConnection Conexao = new SqlConnection(connectionString))
            {
                // Comando CRUD - INSERT:
                using (SqlCommand Comando = new SqlCommand("INSERT INTO tb_Pessoa VALUES(@PessoaNome, @PessoaEmail, @PessoaTelefone )", Conexao))
                {
                    // Substituindo os atributos do comando INSERT pelos valores dos atributos da classe:
                    Comando.Parameters.AddWithValue("@PessoaNome", PessoaNome);
                    Comando.Parameters.AddWithValue("@PessoaEmail", PessoaEmail);
                    Comando.Parameters.AddWithValue("@PessoaTelefone", PessoaTelefone);

                    Conexao.Open();             // Abrindo conexão com BD.
                    Comando.ExecuteNonQuery();  // Executando o comando INSERT.
                    Conexao.Close();            // Fechando conexção com BD:
                }
            }
        }
        // Método SELECT:
        // Retorna uma tabela virtual - Criada através do SELECT.
        public DataTable Listar()
        {
            // Criando um objeto para tabela virtual.
            DataTable dt = new DataTable();

            // Conexão com banco de dados:
            using (SqlConnection Conexao = new SqlConnection(connectionString))
            {

                // Preparando comando SELECT para execução:
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_Pessoa", Conexao);

                Conexao.Open();         // Abrindo conexão com BD.
                da.Fill(dt);            // Preenchendo a tabela virtual com dados do SELECT.
                Conexao.Close();        // Fechando conexão com BD.
            }
            return dt;      // Retor tabela virtual.
        }
    }
}
