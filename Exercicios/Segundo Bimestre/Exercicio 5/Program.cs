using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;
var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var clienteRepository = new ClienteRepository(databaseConfig);
var pedidoRepository = new PedidoRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];
if(modelName == "Cliente")
{
    if(modelAction == "Listar")
    {
        int indicador = 1;
        Console.WriteLine("\nListar Cliente");
        Console.WriteLine("Id Cliente   Endereço do Cliente      Cidade      Região      Código Postal   País      Telefone");
        foreach (var cliente in clienteRepository.Listar())
        {
            Console.WriteLine($"{cliente.ClienteId, -12} {cliente.Endereco, -24} {cliente.Cidade, -11} {cliente.Regiao, -11} {cliente.CodigoPostal, -15} {cliente.Pais, -9} {cliente.Telefone}");
            ++indicador;
        }
        indicador = 0;
    }

    else if(modelAction == "Inserir")
    {
        Console.WriteLine("\nInserir Cliente");
        Console.WriteLine("Digite o Id do cliente: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nDigite o endereço do cliente: ");
        string endereco = Console.ReadLine();
        Console.WriteLine("\nDigite a cidade do cliente: ");
        string cidade = Console.ReadLine();
        Console.WriteLine("\nDigite a região do cliente: ");
        string regiao = Console.ReadLine();
        Console.WriteLine("\nDigite o codigo postal do cliente: ");
        string codigopostal = Console.ReadLine();
        Console.WriteLine("\nDigite o país do cliente: ");
        string pais = Console.ReadLine();
        Console.WriteLine("\nDigite o telefone do cliente: ");
        string telefone = Console.ReadLine();
        var cliente = new Cliente(clienteid, endereco, cidade, regiao, codigopostal, pais, telefone);
        clienteRepository.Inserir(cliente);
    }

    else if(modelAction == "Apresentar")
    {
        Console.WriteLine("\nApresentar Cliente");
        Console.WriteLine("Digite o Id do cliente: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());

        if(clienteRepository.Apresentar(clienteid))
        {
            var cliente = clienteRepository.GetById(clienteid);
            Console.WriteLine($"\nCliente Id: {cliente.ClienteId}\nEndereço: {cliente.Endereco}\nCidade: {cliente.Cidade}\nRegião: {cliente.Regiao}\nCódigo Postal: {cliente.CodigoPostal}\nPaís: {cliente.Pais}\nTelefone: {cliente.Telefone}\n");
        } 
        else 
        {
            Console.WriteLine($"O cliente com Id {clienteid} não existe.");
        }
    }
}

else if(modelName == "Pedido")
{
    if(modelAction == "Listar")
    {
        Console.WriteLine("\nListar Pedido");
        Console.WriteLine("Nro Pedido   Id Empregado   Data do Pedido   Peso      Codigo da Transportadora   Id do Cliente");
        int indicador = 1;
        foreach (var pedido in pedidoRepository.Listar())
        {
            Console.WriteLine($"{pedido.PedidoId, -12} {pedido.EmpregadoId, -14} {pedido.DataPedido, -16} {pedido.Peso, -9} {pedido.CodTransportadora, -26} {pedido.PedidoClienteId}");
            ++indicador;
        }
        indicador = 1;
    }

    else if(modelAction == "Inserir")
    {
        Console.WriteLine("\nInserir Pedido");
        Console.WriteLine("Digite o Id do pedido: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nDigite o Id do empregado: ");
        int empregoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nDigite a Data do pedido: ");
        string dataPedido = Console.ReadLine();
        Console.WriteLine("\nDigite o Peso do pedido: ");
        string peso = Console.ReadLine();
        Console.WriteLine("\nDigite o código da transportadora: ");
        int codTransportadora = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nDigite o Id do cliente que realizou o pedido: ");
        int pedidoClienteId = Convert.ToInt32(Console.ReadLine());
        var pedido = new Pedido(pedidoId, empregoId, dataPedido, peso, codTransportadora, pedidoClienteId);
        pedidoRepository.Inserir(pedido);
    }

    else if(modelAction == "Apresentar")
    {
        Console.WriteLine("\nApresentar Pedido");
        Console.WriteLine("Digite o Id do pedido: ");
        int pedidoid = Convert.ToInt32(Console.ReadLine());

        if(pedidoRepository.Apresentar(pedidoid))
        {
            var pedido = pedidoRepository.GetById(pedidoid);
            Console.WriteLine($"\nId do Pedido: {pedido.PedidoId}\nId do Empregado: {pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\nId do Cliente: {pedido.PedidoClienteId}\n");
        } 
        else 
        {
            Console.WriteLine($"O pedido com Id {pedidoid} não existe.");
        }
    }

    else if(modelAction == "MostrarPedidosCliente"){
        Console.WriteLine("\nMostrar os Pedidos do Cliente");
        Console.WriteLine("Digite o Id do cliente: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());

        if(pedidoRepository.MostrarPedidosCliente(clienteid))
        {
            foreach (var pedido in pedidoRepository.GetByClienteId(clienteid))
            {
                Console.WriteLine($"\nId do Pedido: {pedido.PedidoId}\nId do Empregado: {pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\n");
            }
        } 
        else 
        {
            Console.WriteLine($"O pedido com Id de cliente {clienteid} não existe.");
        }
    }
}