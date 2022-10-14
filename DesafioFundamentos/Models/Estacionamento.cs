using System;
using System.Collections.Generic;
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
            Console.WriteLine("Digite a placa do veículo para estacionar (Exemplo: ABC-1234):");
            
            string placaVeiculo = Console.ReadLine();

            var padraoPlaca = new Regex(@"^[a-zA-Z]{3}\-\d{4}$");
            
            if(string.IsNullOrWhiteSpace(placaVeiculo) || (placaVeiculo.Length > 8) || !padraoPlaca.IsMatch(placaVeiculo))

                Console.WriteLine("Placa inválida!");
            else
                veiculos.Add(placaVeiculo);

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = "";
            placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = 0;
                valorTotal = (precoInicial + precoPorHora) * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (var v in veiculos)
                {
                    Console.WriteLine("{0}", v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
