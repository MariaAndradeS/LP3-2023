namespace AtividadeAvaliativa.Models;

class Pedidos {
    public int CodPedido { get; set; }
    public DateTime PrazoEntrega { get; set; }
    public DateTime DataPedido = DateTime.Now;
    public int PedidoCodCliente { get; set; }
    public int PedidoCodVendedor { get; set; }

    public Pedidos(int codpedido, DateTime prazoentrega, DateTime datapedido, int pedidocodcliente, int pedidocodvendedor) {
        CodPedido = codpedido;
        PrazoEntrega = prazoentrega;
        DataPedido = datapedido;
        PedidoCodCliente = pedidocodcliente;
        PedidoCodVendedor = pedidocodvendedor;
    }
}