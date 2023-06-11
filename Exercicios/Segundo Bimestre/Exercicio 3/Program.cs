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
if (modelName == "Cliente")
{
    if (modelAction == "Listar")
    {
        int indicador = 1;
        Console.WriteLine("\nListar Cliente");
        foreach (var cliente in clienteRepository.Listar())
        {
            Console.WriteLine($"\n{indicador}º Registro\nCliente Id: {cliente.ClienteId}\nEndereço: {cliente.Endereco}\nCidade: {cliente.Cidade}\nRegião: {cliente.Regiao}\nCódigo Postal: {cliente.CodigoPostal}\nPaís: {cliente.Pais}\nTelefone: {cliente.Telefone}\n");
            ++indicador;
        }
        indicador = 0;
    }

    else if (modelAction == "Inserir")
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
}

else if (modelName == "Pedido")
{
    if (modelAction == "Listar")
    {
        Console.WriteLine("\nListar Pedido");
        int indicador = 1;
        foreach (var pedido in pedidoRepository.Listar())
        {
            Console.WriteLine($"\n{indicador}º Registro\nId do Pedido: {pedido.PedidoId}\nId do Empregado{pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\nId do Cliente: {pedido.PedidoClienteId}\n");
            ++indicador;
        }
        indicador = 1;
    }

    else if (modelAction == "Inserir")
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
}