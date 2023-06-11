namespace Classes;
public class Diesel : Abastecimentos
{
    private readonly decimal _bonus = 0m;
    public Diesel(string nome, decimal valorAtual, decimal bonus = 0) : base(nome, valorAtual)
    => _bonus = bonus; // Se não mover não executa o bônus
    public override void ExecutarAjustes()
    {
        decimal acrescimo = ValorAcumulado * 0.03m;
        AtualizarValor(acrescimo, DateTime.Now, "Ajustes para Diesel");
        if (_bonus != 0)
        {
            AtualizarValor(_bonus, DateTime.Now, "Bonus para Diesel");
        }
    }
}