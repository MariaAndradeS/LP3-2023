namespace Classes;
public class ContaCartaodeDebito : ContaBancaria
{
    private readonly decimal _depositosMensais = 0m;

    public ContaCartaodeDebito(string nome, decimal saldoInicial, decimal depositosMensais = 0) : base(nome, saldoInicial)
    => _depositosMensais = depositosMensais;

    public override void ExecutarTransacoesdeFimdeMes()
{
    if (_depositosMensais != 0)
    {
        EfetuarDeposito(_depositosMensais, DateTime.Now, "Adicionar depositos mensais");
    }
}
}