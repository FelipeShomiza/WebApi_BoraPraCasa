namespace CorridaAPI.Models
{
public class Corrida
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Distancia { get; set; }
    
    public decimal Valor {get; set; }

    public void CalcularValor()
        {
            Valor = (decimal)Distancia * 5;
        }

}
}