namespace Classes;

public class Transacao
{
    public decimal Quantia { get; }
    public DateTime Data { get; }
    public string Notas { get; }

    public Transacao(decimal quantia, DateTime data, string nota)
    {
        Quantia = quantia;
        Data = data;
        Notas = nota;
    }
}