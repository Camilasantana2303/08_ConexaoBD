using _08_ConexaoBD;
using System.Data;

//ConexaoSimples conexaoSimples= new ConexaoSimples();
//ConexaoFlexivel conexaoFlexivel= new ConexaoFlexivel();
//conexaoFlexivel.executaQuery("SELECT * FROM tarefas");
//conexaoFlexivel.executaQuery("SELECT * FROM tarefas WHERE id=4;");
//conexaoFlexivel.executaQuery("SELECT * FROM tarefas WHERE descricao LIKE '%tud%';");
//conexaoFlexivel.executaQuery("SELECT * FROM tarefas WHERE id=9999;");
//ConexaoSegura conexaoSegura= new ConexaoSegura();
//conexaoSegura.executaQuery("SELECT * FROM tarefas WHERE descricao LIKE '%w%';");





Tarefa tarefa = new Tarefa();

Console.WriteLine("Seja bem-vindo ao sistema do Conradito Consultinhas");
List<Tarefa>tarefas=tarefa.buscaTodos();
foreach(Tarefa t in tarefas)
{
    Console.WriteLine($"Tarefa {t.id} - {t.descricao} | criado em {t.criado_em}");
}



Console.WriteLine("Digite 1 para consultar ID ou 2 para Consultar a DESCRIÇÃO ou 3 para cadastrar: ");
string opcao =Console.ReadLine();





if(opcao == "3")
{
    Console.WriteLine("Bem-vindo ao cadastro de tarefas!\n");
    Console.WriteLine("Digite a descrição da tarefa:");
    string descricao=Console.ReadLine();

    Console.WriteLine("Tarefa concluida? Digite 1 para sim ou 2 para não");
    bool concluido = Console.ReadLine() == "1";

    Tarefa t = new Tarefa();
    t.descricao = descricao;
    t.concluido= concluido;

    tarefa.Insere(t);

    Console.WriteLine("Cadastro concluido com sucesso");
}

/*

if (opcao == "1")
{
    Console.WriteLine("Digite o ID da tarefa que deseja consultar: ");
    int id = int.Parse(Console.ReadLine());
    tarefa =tarefa.BuscaPorId(id);
}
else
{
    Console.WriteLine("Digite a DESCRIÇÃO que deseja encontrar:");
    string descricao = Console.ReadLine();
    tarefa.BuscarPorDescricao("descricao");
}

Console.WriteLine("\nRsultados encontrados:");
Console.WriteLine($"Tarefa {tarefa.id}- {tarefa.descricao}");
Console.WriteLine($"| criado em {tarefa.criado_em}");


*/





Console.ReadKey();