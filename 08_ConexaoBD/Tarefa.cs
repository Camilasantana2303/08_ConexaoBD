using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class Tarefa
    {
        // id, descricao, concluido,criado_em
        public int id;
        public string descricao;
        public bool concluido;
        public string criado_em;

        public Tarefa()
        {

        }

        public Tarefa(int id, string descricao, bool concluido, string criado_em)
        {
            this.id = id;
            this.descricao = descricao;
            this.concluido = concluido;
            this.criado_em = criado_em;
        }


        public List<Tarefa> buscaTodos()
        {
            string query = "SELECT * FROM tarefas";
            Conexao.executaQuery(query);
            DataTable tabela = Conexao.executaQuery(query);

            List<Tarefa> tarefas= new List<Tarefa>();
            //Para cada linha dentro da tabela.rows
            //Ele guarda na variável linha o valor do loop atual dentro da tabela
            foreach(DataRow linha in tabela.Rows)
            {
                Tarefa tarefa = carregaDados(linha);
                tarefas.Add(tarefa);
            }
            return tarefas;
        }


        //DataRow retorna apenas uma linha
        public Tarefa BuscaPorId(int id)
        {
            string query = $"SELECT * FROM tarefas WHERE id= {id};";
            DataTable tabela = Conexao.executaQuery(query);
            Tarefa tarefa = carregaDados(tabela.Rows[0]);
            return tarefa;
        }

        public Tarefa BuscarPorDescricao(string descricao)
        {
            string query = $"SELECT * FROM tarefas WHERE descricao= {descricao};";
            DataTable tabela = Conexao.executaQuery(query);
            Tarefa tarefa = carregaDados(tabela.Rows[0]);
            return tarefa;

        }

        public void Insere(Tarefa tarefa)
        {
            int concluido = tarefa.concluido==true ? 1:0;
            string query = $"INSERT INTO tarefas (descricao,concluido) VALUES('{tarefa.descricao}',{concluido});";
            Conexao.executaQuery(query);
        }



        // Recebe a linha de uma tabela e retorna ela no formato de classe
        public Tarefa carregaDados(DataRow linha)
        {
            int id =int.Parse(linha["id"].ToString());
            string descricao = (linha["descricao"].ToString());
            bool concluido = linha["concluido"].ToString()=="1"? true : false;
            string criado_em = linha["criado_em"].ToString() ;

            Tarefa tarefa= new Tarefa(id, descricao,concluido,criado_em);
            return tarefa;

        }

       




    }

    }

