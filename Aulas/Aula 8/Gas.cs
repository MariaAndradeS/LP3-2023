namespace Classes;
public class Gas : Abastecimentos
{
    public Gas(string nome, decimal valorAtual) : base(nome, valorAtual)
    {
    }
    public override void ExecutarAjustes()
    {
        decimal acrescimo = ValorAcumulado * 0.01m;
        AtualizarValor(acrescimo, DateTime.Now, "Ajustes para Gás");
    }
}