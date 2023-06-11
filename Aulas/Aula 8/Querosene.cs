namespace Classes;
public class Querosene : Abastecimentos
{
    public Querosene(string nome, decimal valorAtual) : base(nome, valorAtual)
    {
    }
    public override void ExecutarAjustes()
    {
        decimal acrescimo = ValorAcumulado * 0.04m;
        AtualizarValor(acrescimo, DateTime.Now, "Ajustes para Querosene");
    }
}