namespace AtividadeGastos;

public class CategoriaNatacao : Gastos {
    public CategoriaNatacao(string nome, decimal valorInicial) : base(nome, valorInicial) {}

    public override void ExecutarMargemdeSeguranca() {
        decimal acrescimo = ValorAcumulado * 0.02m;
        EfetuarDeposito(acrescimo, DateTime.Now, "Margem de Segurança para Natação");
    }
}