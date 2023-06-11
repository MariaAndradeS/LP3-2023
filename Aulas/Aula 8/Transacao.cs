public class Transacao
{
    public decimal Valor { get; }
    public DateTime Data { get; }
    public string Descricao { get; }
    public Transacao(decimal valor, DateTime data, string descricao)
    {
        Valor = valor;
        Data = data;
        Descricao = descricao;
    }
}