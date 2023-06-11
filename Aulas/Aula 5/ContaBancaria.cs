namespace Classes;

public class ContaBancaria
{
    public string Numero { get; }
    public string Cliente { get; set; }
    public decimal Saldo { get; }

public ContaBancaria(string nome, decimal saldoInicial)
{
    this.Cliente = nome;
    this.Saldo = saldoInicial;
}
    public void EfetuarDeposito(decimal quantia, DateTime data, string nota)
    {
    }

    public void EfetuarSaque(decimal quantia, DateTime data, string nota)
    {
    }
}


