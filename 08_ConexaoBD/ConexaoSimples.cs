using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class ConexaoSimples
    {
        string host = "localhost";
        string banco = "08_lista_tarefas";
        string usuario = "root";
        string senha = "senac";
        

        public ConexaoSimples()
        {

            //Usa os dados do banco para se conectar
            string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";

            //Cria a conexão com o banco usando os dados acima
            //O banco não se conecta sozinho, ele apenas cria conexão
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            //Abre a conexão com o banco 
            conexao.Open();


            //Linha do codigo SQL
            string query = "SELECT * FROM tarefas;";
            // Envia um comando para o banco
            MySqlCommand comando = new MySqlCommand(query, conexao);
            //Guarda os dados que vieram do banco dentro do dados
            //MySqlDataReader recebe os dados em formato de tabela
            MySqlDataReader dados = comando.ExecuteReader();

            while(dados.Read() == true)
            {
                Console.WriteLine("Descrição da tarefa: " + dados["descricao"]);
            }

            conexao.Close();
        }
    }
}
