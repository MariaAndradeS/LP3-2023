namespace AtividadeGastos;

public class Gastos {
    public string Cliente {get; set;}
    public decimal ValorAcumulado {
        get {
            decimal valor = 0m;
            foreach (var item in todasTransacoes) {
                valor += item.Valor;
            } return valor;
        }
    }

    public Gastos(string nome, decimal valorInicial) {
        this.Cliente = nome;
        EfetuarDeposito(valorInicial, DateTime.Now, "Valor Inicial ");
    }

    private List<Transacoes> todasTransacoes = new List<Transacoes>();

    public void EfetuarDeposito (decimal valor, DateTime data, string descricao) {
        var deposito = new Transacoes(valor, data, descricao);
        todasTransacoes.Add(deposito);
    }

    public string ObterHistoricodeConta() {
        var relatorio = new System.Text.StringBuilder();
        decimal valor = 0m;

        relatorio.AppendLine("Data           Valor  Valor Acumulado     Descrição");
        foreach (var item in todasTransacoes) {
            valor += item.Valor;
            relatorio.AppendLine($"{item.Data.ToShortDateString(), -10}{item.Valor, 10}{valor, 17} {"   "} {item.Descricao}");
        }
        return relatorio.ToString();
    }
    public virtual void ExecutarMargemdeSeguranca(){ }
}