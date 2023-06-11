namespace Classes;
public class ContadeGanhodeJuros : ContaBancaria
{

    public ContadeGanhodeJuros(string nome, decimal saldoInicial) : base(nome, saldoInicial)
    {
    }
    public override void ExecutarTransacoesdeFimdeMes()
    {
    if (Saldo > 500m)
    {
        decimal juros = Saldo * 0.05m;
        EfetuarDeposito(juros, DateTime.Now, "Aplicar juros mensais");
    }
    }
}