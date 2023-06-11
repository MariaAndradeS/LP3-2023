using Classes;

var conta = new ContaBancaria("Maria Eduarda", 1000.50m);

Console.Write($"A conta {conta.Numero} foi criada por {conta.Cliente} com saldo inicial de {conta.Saldo}\n\n");

conta.EfetuarDeposito(1000, DateTime.Now, "Pagamento de um amigo");
Console.WriteLine($"Saldo Atual de {conta.Saldo}\n");

conta.EfetuarSaque(500, DateTime.Now, "Pagamento de aluguel");
Console.WriteLine($"Saldo Atual de {conta.Saldo}\n");

conta.EfetuarDeposito(100, DateTime.Now, "Presente de aniversário");
Console.WriteLine($"Saldo Atual de {conta.Saldo}\n");