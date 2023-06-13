namespace AtividadeAvaliativa.Models;

class Vendedores {
    public int CodVendedor { get; set; }
    public string Nome { get; set; }
    public decimal SalarioFixo { get; set; }
    public string FaixaComissao { get; set; }

    public Vendedores(int codvendedor, string nome, decimal salariofixo, string faixacomissao) {
        CodVendedor = codvendedor;
        Nome = nome;
        SalarioFixo = salariofixo;
        FaixaComissao = faixacomissao;
    }
}