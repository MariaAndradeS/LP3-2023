namespace Classes;

public class Abastecimentos
{
    public string Cliente { get; }
    public decimal ValorAcumulado
    {
        get
        {
            decimal valorAcumulado = 0m;
            foreach (var item in todasTransacoes)
            {
                valorAcumulado += item.Valor;
            }
            return valorAcumulado;
        }
    }
    public Abastecimentos(string nome, decimal valorAtual)
    {
        this.Cliente = nome;
        //this.ValorAcumulado = valorAtual;
        AtualizarValor(valorAtual, DateTime.Now, "Valor Inicial ");
    }
    private List<Transacao> todasTransacoes = new List<Transacao>();
    public void AtualizarValor(decimal valor, DateTime data, string descricao)
    {
        var atualizacao = new Transacao(valor, data, descricao);
        todasTransacoes.Add(atualizacao);
    }
    public string EmitirRelatorio()
    {
        var relatorio = new System.Text.StringBuilder();
        decimal valorAcumulado = 0m;
        relatorio.AppendLine("Data\t\tValor\tValor Acumulado   Descrição");
        foreach (var item in todasTransacoes)
        {
            valorAcumulado += item.Valor;
            relatorio.AppendLine($"{item.Data.ToShortDateString(),-10} {item.Valor, 10} {valorAcumulado, 17} {" "} { item.Descricao}"); 
        }
        return relatorio.ToString();
    }
public virtual void ExecutarAjustes() { }
}