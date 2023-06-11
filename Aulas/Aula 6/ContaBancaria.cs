namespace Classes;

public class ContaBancaria
{
    private static int numeroConta = 1234567890;
    public string Numero { get; }
    public string Cliente { get; set; }
    public decimal Saldo
    {
    get
    {
        decimal saldo = 0m;
        foreach (var item in todasTransacoes)
        {
            saldo += item.Quantia;
        }

        return saldo;
    }
    }

public ContaBancaria(string nome, decimal saldoInicial)
{
    this.Cliente = nome;
    this.Numero = numeroConta.ToString();
    numeroConta++;
}
private List<Transacao> todasTransacoes = new List<Transacao>();
    public void EfetuarDeposito(decimal quantia, DateTime data, string nota)
    {
    if (quantia <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(quantia), "A quantia de depósito deve ser positiva");
    }
    var deposito = new Transacao(quantia, data, nota);
    todasTransacoes.Add(deposito);
}

    public void EfetuarSaque(decimal quantia, DateTime data, string nota)
    {
    if (quantia <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(quantia), " A quantia de saque deve ser positiva");
    }
    if (Saldo - quantia < 0)
    {
        throw new InvalidOperationException("Fundo não suficiente para este saque");
    }
    var saque = new Transacao(-quantia, data, nota);
    todasTransacoes.Add(saque);
}
}