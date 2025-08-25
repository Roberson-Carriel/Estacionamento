using System.Text.RegularExpressions;
using Estacionamento.Models;

namespace Estacionamento.Services
{
    public class EstacionamentoService
    {
        private readonly decimal valorInicial = 5m;
        private readonly decimal valorPorHora = 2m;
        private readonly List<Veiculo> veiculos = new();

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo: ");
            string? placa = Console.ReadLine();

            // Validação de placa (Mercosul ou padrão antigo)
            var regex = new Regex(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$|^[A-Z]{3}[0-9]{4}$", RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(placa) || !regex.IsMatch(placa))
            {
                Console.WriteLine("Placa inválida! Digite no formato correto (ABC1D23 ou ABC1234).");
                return;
            }

            veiculos.Add(new Veiculo(placa));
            Console.WriteLine("Veículo adicionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo a remover: ");
            var placa = (Console.ReadLine() ?? "").Trim().ToUpper();

            var veiculo = veiculos.FirstOrDefault(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if (veiculo == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }

            var tempo = DateTime.Now - veiculo.HoraEntrada;
            var horas = Math.Max(1, (int)Math.Ceiling(tempo.TotalHours));
            var valorTotal = valorInicial + (horas * valorPorHora);

            veiculos.Remove(veiculo);

            Console.WriteLine($"Veículo {placa} removido.");
            Console.WriteLine($"Tempo: {horas}h | Total: R$ {valorTotal:F2}");
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Veículos estacionados:");
            foreach (var v in veiculos)
                Console.WriteLine($"- {v.Placa} | Entrada: {v.HoraEntrada:dd/MM/yyyy HH:mm}");
        }
    }
}
