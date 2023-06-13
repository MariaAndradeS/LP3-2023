namespace AtividadeGastos;

public class CategoriaVestuario : Gastos {
    public CategoriaVestuario(string nome, decimal valorInicial) : base(nome, valorInicial) {}

    public override void ExecutarMargemdeSeguranca() {
        decimal acrescimo = ValorAcumulado * 0.02m;
        EfetuarDeposito(acrescimo, DateTime.Now, "Margem de Segurança para Vestuário");
    }
}