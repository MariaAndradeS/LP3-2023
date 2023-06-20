using Microsoft.Data.Sqlite;
using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Repositories;
using AtividadeAvaliativa.Models;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);

var clientesRepository = new ClientesRepository(databaseConfig);
var pedidosRepository = new PedidosRepository(databaseConfig);
var itenspedidosRepository = new ItensPedidosRepository(databaseConfig);
var vendedoresRepository = new VendedoresRepository(databaseConfig);
var produtosRepository = new ProdutosRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];


if (modelName == "Cliente")
{
    if (modelAction == "Listar")
    {
        Console.WriteLine("Listar Cliente");
        Console.WriteLine("Código Cliente   Nome Cliente         Endereço                   Cidade      CEP        UF   IE");
        foreach (var cliente in clientesRepository.Listar())
        {
            Console.WriteLine($"{cliente.CodCliente,-16} {cliente.Nome,-20} {cliente.Endereco,-26} {cliente.Cidade,-11} {cliente.Cep,-10} {cliente.Uf,-4} {cliente.Ie}");
        }
    }

    if (modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Cliente");
        Console.Write("Digite o código do cliente    : ");
        int codcliente = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o Nome do cliente      : ");
        string? nome = Console.ReadLine();
        Console.Write("Digite o Endereço do cliente  : ");
        string? endereco = Console.ReadLine();
        Console.Write("Digite o Cidade do cliente    : ");
        string? cidade = Console.ReadLine();
        Console.Write("Digite o CEP do cliente       : ");
        string? cep = Console.ReadLine();
        Console.Write("Digite o UF do cliente        : ");
        string? uf = Console.ReadLine();
        Console.Write("Digite o Inscrição Estatual   : ");
        string? ie = Console.ReadLine();

        var cliente = new Clientes(codcliente, nome, endereco, cidade, cep, uf, ie);
        clientesRepository.Inserir(cliente);
    }


    if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Cliente");
        Console.Write("Digite o código do cliente : ");
        var clienteid = Convert.ToInt32(Console.ReadLine());

        if (clientesRepository.Apresentar(clienteid))
        {
            var cliente = clientesRepository.GetById(clienteid);
            Console.WriteLine($"{cliente.CodCliente}, {cliente.Nome}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Cep}, {cliente.Uf}, {cliente.Ie}");
        }
        else
        {
            Console.WriteLine($"O cliente com o código {clienteid} não existe.");
        }
    }
}



if (modelName == "Pedido")
{
    if (modelAction == "Listar")
    {

        Console.WriteLine("Listar Pedido");
        Console.WriteLine("Código Pedido   Prazo Entrega         Data Pedido           Código Cliente   Código Vendedor");
        foreach (var pedido in pedidosRepository.Listar())
        {
            Console.WriteLine($"{pedido.CodPedido, -15} {pedido.PrazoEntrega, -21} {pedido.DataPedido,-21} {pedido.PedidoCodCliente,-16} {pedido.PedidoCodVendedor}");
        }
    }

    if (modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Pedido");
        Console.Write("Digite o código do pedido             : ");
        int codPedido = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o prazo de entrega do pedido   : ");
        DateTime prazoEntrega = Convert.ToDateTime(Console.ReadLine());       
        Console.Write("Digite o código do cliente do pedido  : ");
        int pedidoCodCliente = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o código do vendedor do pedido : ");
        int pedidoCodVendedor = Convert.ToInt32(Console.ReadLine());
        var pedido = new Pedidos(codPedido, prazoEntrega, DateTime.Now, pedidoCodCliente, pedidoCodVendedor);
        pedidosRepository.Inserir(pedido);
    }

    if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Pedido");
        Console.Write("Digite o Código do Pedido : ");
        var codPedido = Convert.ToInt32(Console.ReadLine());

        if (pedidosRepository.Apresentar(codPedido))
        {
            var pedido = pedidosRepository.GetById(codPedido);
            Console.WriteLine($"{pedido.CodPedido}, {pedido.PrazoEntrega}, {pedido.DataPedido}, {pedido.PedidoCodCliente}, {pedido.PedidoCodVendedor}");
        }
        else
        {
            Console.WriteLine($"O cliente com o código {codPedido} não existe.");
        }
    }

    if (modelAction == "MostrarPedidosCliente")
    {
        Console.WriteLine("Mostrar Pedidos do Cliente");
        Console.Write("Digite o Código do Cliente: ");
        var pedidocodcliente = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Código Pedido   Prazo Entrega         Data Pedido           Código Vendedor   Nome Vendedor");

        if (clientesRepository.Apresentar(pedidocodcliente))
        {
            foreach (var pedido in pedidosRepository.Listar())
            {
                if (pedidocodcliente == pedido.PedidoCodCliente)
                {
                    var vendedor = vendedoresRepository.GetById(pedido.PedidoCodVendedor);

                    Console.WriteLine($"{pedido.CodPedido, -15} {pedido.PrazoEntrega, -21} {DateTime.Now,-21} {vendedor.CodVendedor,-17} {vendedor.Nome}");
                }
            }
        }
        else
        {
            Console.WriteLine($"O cliente com código {pedidocodcliente} não existe.");
        }
    }


    if (modelAction == "MostrarPedidosVendedor")
    {
        Console.WriteLine("Mostrar Pedidos do Vendedor");
        Console.Write("Digite o Código do Vendedor: ");
        var pedidocodvendedor = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Código Pedido   Data Pedido");

        if (vendedoresRepository.Apresentar(pedidocodvendedor))
        {
            foreach (var pedido in pedidosRepository.Listar())
            {
                if (pedidocodvendedor == pedido.PedidoCodVendedor)
                {
                    var vendedor = vendedoresRepository.GetById(pedido.PedidoCodVendedor);

                    Console.WriteLine($"{pedido.CodPedido, -15} {DateTime.Now, -21}");
                }
            }
        }
        else
        {
            Console.WriteLine($"O cliente com Id {pedidocodvendedor} não existe.");
        }
    }

    if (modelAction == "MostrarQuantidadesProdutosPedidos")
    {
        Console.WriteLine("Mostrar Quantidades de Produtos Vendidos");
        Console.Write("Digite o Código do produto: ");
        var itempedidocodproduto = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Código Pedido   Código Produto   Descrição   Valor Unitário   Quantidade   Valor Total");

        var produtos = produtosRepository.Listar();
        var itensPedidos = itenspedidosRepository.Listar();

        foreach (var item in itensPedidos)
        {
            if (item.ItemPedidoCodProduto == itempedidocodproduto)
            {
                var pedido = pedidosRepository.GetById(item.ItemPedidoCodPedido);
                var produto = produtosRepository.GetById(item.ItemPedidoCodProduto);

                var valorTotal = produto.ValorUnitario * item.Quantidade;

                Console.WriteLine($"{pedido.CodPedido, -15} {produto.CodProduto, -16} {produto.Descricao, -12} {produto.ValorUnitario, -15} {item.Quantidade, -12} {valorTotal}");
            }
        }
    }
}

if (modelName == "Produto")
{
    if (modelAction == "Listar")
    {

        Console.WriteLine("Listar Produto");
        Console.WriteLine("Código Produto   Descrição   Valor Unitário");
        foreach (var produto in produtosRepository.Listar())
        {
            Console.WriteLine($"{produto.CodProduto,-16} {produto.Descricao,-11} {produto.ValorUnitario}");
        }
    }

    if (modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Produto");
        Console.Write("Digite o código do produto         : ");
        var codProduto = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a descrição do produto      : ");
        string? descricao = Console.ReadLine();
        Console.Write("Digite o valor unitário do produto : ");
        var valorUnitario = Convert.ToDecimal(Console.ReadLine());
        var produto = new Produtos(codProduto, descricao, valorUnitario);
        produtosRepository.Inserir(produto);
    }

    if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Produto");
        Console.Write("Digite o código do produto : ");
        var codProduto = Convert.ToInt32(Console.ReadLine());

        if (produtosRepository.Apresentar(codProduto))
        {
            var produto = produtosRepository.GetById(codProduto);

            Console.WriteLine($"{produto.CodProduto}, {produto.Descricao}, {produto.ValorUnitario}");
        }
        else
        {
            Console.WriteLine($"O produto com código {codProduto} não existe.");
        }
    }
}

if (modelName == "ItensPedido")
{
    if (modelAction == "Listar")
    {

        Console.WriteLine("Listar Itens do Pedido");
        Console.WriteLine("Código Item Pedido   Quantidade   Código Pedido   Codigo Produto");
        foreach (var ip in itenspedidosRepository.Listar())
        {
            Console.WriteLine($"{ip.CodItemPedido,-20} {ip.Quantidade,-12} {ip.ItemPedidoCodPedido,-15} {ip.ItemPedidoCodProduto}");
        }
    }

    if (modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Itens do Pedido");
        Console.Write("Digite o código do item do pedido            : ");
        int codItemPedido = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o código do pedido do item do pedido  : ");
        int itempedidocodpedido = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o código do produto do item do pedido : ");
        int itempedidocodproduto = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a quantidade do item do pedido        : ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        var itemPedido = new ItensPedidos(codItemPedido, itempedidocodpedido, itempedidocodproduto, quantidade);
        itenspedidosRepository.Inserir(itemPedido);
    }

    if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Pedido");
        Console.Write("Digite o código do pedido : ");
        var codItemPedido = Convert.ToInt32(Console.ReadLine());

        if (itenspedidosRepository.Apresentar(codItemPedido))
        {
            var itensPedido = itenspedidosRepository.GetById(codItemPedido);
            Console.WriteLine($"{itensPedido.CodItemPedido}, {itensPedido.Quantidade}, {itensPedido.ItemPedidoCodPedido}, {itensPedido.ItemPedidoCodProduto}");
        }
        else
        {
            Console.WriteLine($"O pedido com o código {codItemPedido} não existe.");
        }
    }
}

if (modelName == "Vendedor")
{
    if (modelAction == "Listar")
    {

        Console.WriteLine("Listar Vendedor");
        Console.WriteLine("Código Vendedor   Nome Vendedor      Salário Fixo   Faixa Comissão");
        foreach (var vendedor in vendedoresRepository.Listar())
        {
            Console.WriteLine($"{vendedor.CodVendedor,-17} {vendedor.Nome,-18} {vendedor.SalarioFixo,-14} {vendedor.FaixaComissao}");
        }
    }

    if (modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Vendedor");
        Console.Write("Digite o código do vendedor            : ");
        int codVendedor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o nome do vendedor              : ");
        string? nome = Console.ReadLine();
        Console.Write("Digite o salário fixo do vendedor      : ");
        decimal salario = decimal.Parse(Console.ReadLine());
        Console.Write("Digite o faixa de comissão do vendedor : ");
        string? faixaComissao = Console.ReadLine();

        var vendedor = new Vendedores(codVendedor, nome, salario, faixaComissao);
        vendedoresRepository.Inserir(vendedor);
    }

    if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Vendedor");
        Console.Write("Digite o código do vendedor : ");
        int codVendedor = Convert.ToInt32(Console.ReadLine());

        if (vendedoresRepository.Apresentar(codVendedor))
        {
            var vendedor = vendedoresRepository.GetById(codVendedor);
            Console.WriteLine($"{vendedor.CodVendedor}, {vendedor.Nome}, {vendedor.SalarioFixo}, {vendedor.FaixaComissao}");
        }
        else
        {
            Console.WriteLine($"O vendedor com o código {codVendedor} não existe.");
        }
    }
}