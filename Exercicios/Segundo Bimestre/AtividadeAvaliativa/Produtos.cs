namespace AtividadeAvaliativa.Models;

class Produtos {
    public int CodProduto { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }

    public Produtos(int codproduto, string descricao, decimal valorunitario) {
        CodProduto = codproduto;
        Descricao = descricao;
        ValorUnitario = valorunitario;
    }
}