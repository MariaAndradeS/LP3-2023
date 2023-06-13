namespace AtividadeGastos;

public class CategoriaEducacao : Gastos {

    public CategoriaEducacao(string nome, decimal valorInicial) : base(nome, valorInicial) {}

    public override void ExecutarMargemdeSeguranca() {
        decimal acrescimo = ValorAcumulado * 0.03m;
        EfetuarDeposito(acrescimo, DateTime.Now, "Margem de Segurança para Educação");
    }
    // private readonly decimal _acrescimo = 0m;

    // public CategoriaEducacao (string nome, decimal valorInicial, decimal acrescimo = 0) : base(nome, valorInicial) => _acrescimo = acrescimo;

    // public override void ExecutarMargemdeSeguranca() {
    //     if (_acrescimo != 0) {
    //         EfetuarDeposito(_acrescimo, DateTime.Now, "Bonus de Segurança");
    //     }
    // }
}