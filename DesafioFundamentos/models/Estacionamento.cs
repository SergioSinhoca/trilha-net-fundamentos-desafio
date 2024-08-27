using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// -- Importa a biblioteca Regex para validação de expressões regulares. --
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*

            // -- número de tentativas permitidas para o usuário inserir uma placa válida --
            int tentativas = 0;
            // -- Variável para verificar se a placa inserida é válida --
            bool placaValida = false;
            // -- variável para armazenar a placa inserida --
            string placa;

            // -- Laço de repetição que continua até a placa ser válida --
            do{
                
                Console.WriteLine("Digite a placa do veículo para estacionar (ex: ABC-1234):");
                placa = Console.ReadLine();

                // -- verifica se o usuário deseja sair do processo --    
                if(placa == "4"){
                    Console.WriteLine("Saindo da adição de veículo e retornando ao menu...");
                }

                // -- Verifica se a placa já está cadastrada, evitando duplicatas --
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())){
                    Console.WriteLine($"A placa {placa} já está cadastrada.");
                    continue;
                }
                // -- Chama o método para validar o formato da placa --
                placaValida = ValidarPlaca(placa);

                // -- Se a placa não for válida, permite tentativas adicionais --
                if(!placaValida){
                    tentativas++;
                    Console.WriteLine("\nPlaca inválida. Por favor, tente novamente.\n");

                    // -- Verifica se o número máximo de tentativas foi atingido --
                    if (tentativas >= 2){
                        Console.WriteLine("Você excedeu o número de tentativas. Deseja sair? Pressione '4' para sair ou qualquer outra tecla para continuar.");
                        string opcao = Console.ReadLine();

                        // -- Se o usuário pressionar 4, retorna ao menu --
                        if (opcao == "4"){
                            Console.WriteLine("Saindo da adição de veículo e retornando ao menu...");
                            return;
                        } else{
                            tentativas = 0;
                        }
                    }
                }
            } while (!placaValida);

            // -- Adiciona a placa à lista de veículos se não houver erros --
            veiculos.Add(placa);
            Console.WriteLine("Veículo adicionado com sucesso!");
        }

        // -- Método que verifica o formato da placa -- 
        private bool ValidarPlaca(string placa){
            // -- Expressão regular para validar placas no formato Mercosul: três letras, um hífen e quatro números --
            string padraoPlaca = @"^[A-Z]{3}-[0-9]{4}$";

            if (!Regex.IsMatch(placa, padraoPlaca)){
        
                 Console.WriteLine("A placa não está no formato correto (ex: ABC-1234).");
                 return false;
            }   

            return true;
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                Console.WriteLine("Digite a quantidade de horas que o veiculo permaneceu estacionado (ex 1h): ");
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;

                // -- Faz a verificação da hora digitada pelo usuário
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0){
                    
                    Console.WriteLine("Por favor, digite um número válido de horas.");
                }
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                for(int contador = 0; contador < veiculos.Count; contador++){
                    Console.WriteLine($"{contador + 1}° -  {veiculos[contador]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

    }   
}