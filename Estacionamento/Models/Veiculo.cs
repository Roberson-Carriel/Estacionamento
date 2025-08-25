namespace Estacionamento.Models
{
    public class Veiculo
    {
        public string Placa { get; private set; }
        public DateTime HoraEntrada { get; private set; }

        public Veiculo(string placa)
        {
            Placa = placa.ToUpper().Trim();
            HoraEntrada = DateTime.Now;
        }
    }
}
