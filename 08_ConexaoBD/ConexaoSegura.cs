using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class ConexaoSegura
    {
        string host = "localhost";
        string banco = "08_lista_tarefas";
        string usuario = "root";
        string senha = "senac";

        // estatico faz com que a variavel não seja apagada
        //mesmo que se crie novas instancias (new)
        static MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dados;

        public ConexaoSegura()// Metodo contrutor: iniciar a classe e criar a conexão
        {
            
            if(conexao == null)
            {
             string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
             conexao = new MySqlConnection(dadosConexao);
            }
        }


        public void executaQuery(string query)//vai rodar comandos dentro do banco
        {
            try
            {
                conexao.Open();


                comando = new MySqlCommand(query, conexao);

                dados = comando.ExecuteReader();


                Console.WriteLine("--------------------------------------------");

                if (!dados.HasRows) // !-nega a comparação
                    Console.WriteLine("Nenhum resultado encontrado D: ");

                //Se tirar a comparação, automaticamente ele compara com true
                while (dados.Read())
                {
                    Console.WriteLine("Descrição da tarefa: " + dados["descricao"]);
                }

            }



            catch (Exception erro)
            {
                Console.WriteLine("Erro ao realizar consulta: ");
                Console.WriteLine(erro.Message);
                
            }
            finally 
            {
                conexao.Close(); 
            }
         
        }
    }
}
