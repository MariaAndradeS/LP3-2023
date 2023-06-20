namespace AtividadeAvaliativa.Models;

class ItensPedidos {
    private int v1;
    private DateTime dateTime1;
    private DateTime dateTime2;
    private int v2;

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

    public ItensPedidos(int v1, DateTime dateTime1, DateTime dateTime2, int v2)
    {
        this.v1 = v1;
        this.dateTime1 = dateTime1;
        this.dateTime2 = dateTime2;
        this.v2 = v2;
    }
}