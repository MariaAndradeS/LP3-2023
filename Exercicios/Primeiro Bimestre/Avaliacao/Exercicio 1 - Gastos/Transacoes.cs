namespace AtividadeGastos;

public class Transacoes {
    public decimal Valor {get;}
    public DateTime Data {get;}
    public string Descricao {get;}

    public Transacoes(decimal valor, DateTime data, string descricao) {
        Valor = valor;
        Data = data;
        Descricao = descricao;
    }
}