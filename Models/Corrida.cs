namespace CorridaAPI.Models 
{
    public class Corrida {
        public int Id { get; set; }
        public int IdMotorista { get; set; }
        public int IdPassageiro { get; set; }
        public double Distancia { get; set; }
        public decimal Valor { get; set; }
        public EnumStatus Status { get; set; }

        
        public Corrida() { }

        
        public void AtualizarValor() 
        {
            Valor = (decimal)this.Distancia * 1.5m; 
        }
    }

    public enum EnumStatus {
        Pendente,
        Iniciada,
        Finalizada
    }
}