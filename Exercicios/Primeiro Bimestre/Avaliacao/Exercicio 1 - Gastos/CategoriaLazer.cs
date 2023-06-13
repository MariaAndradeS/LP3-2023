namespace AtividadeGastos;

public class CategoriaLazer : Gastos {
    public CategoriaLazer(string nome, decimal valorInicial) : base(nome, valorInicial) {}

    public override void ExecutarMargemdeSeguranca() {
        decimal acrescimo = ValorAcumulado * 0.03m;
        EfetuarDeposito(acrescimo, DateTime.Now, "Margem de Segurança para Lazer");
    }
}