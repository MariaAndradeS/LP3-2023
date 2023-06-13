namespace AtividadeAvaliativa.Models;

class ItensPedidos {
    public int CodItemPedido { get; set; }
    public int ItemPedidoCodPedido { get; set; }
    public int ItemPedidoCodProduto { get; set; }
    public int Quantidade { get; set; }

    public ItensPedidos(int coditempedido, int itempedidocodpedido, int itempedidocodproduto, int quantidade) {
        CodItemPedido = coditempedido;
        ItemPedidoCodPedido = itempedidocodpedido;
        ItemPedidoCodProduto = itempedidocodproduto;
        Quantidade = quantidade;
    }
}