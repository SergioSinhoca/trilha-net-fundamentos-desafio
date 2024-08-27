using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

// -- Define o preço inicial do estacionamento --
decimal precoInicial = 0;
// -- Define o preço por hora do estacionamento --
decimal precoPorHora = 0;

// -- Função para ler e validar decimal --
decimal LerDecimal(string mensagem)
{   
    // -- Declara uma variável para armazenar o valor decimal --
    decimal valor;
    // -- Declara uma variável para armazenar a entrada do usuário --
    string entrada;

    // -- Loop para continuar pedindo entrada até que seja válida
    while (true)
    {
        Console.WriteLine(mensagem);
        entrada = Console.ReadLine();

        // -- Tenta converter a entrada para um valor decimal
        if (decimal.TryParse(entrada, out valor))
        {
            return valor;
        }

        Console.WriteLine("Entrada inválida. Por favor, digite um número decimal válido.");
    }
}

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");
// - explique..
precoInicial = LerDecimal("Digite o preço inicial:");
// - explique..
precoPorHora = LerDecimal("Agora digite o preço por hora:");

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");