using AtividadeGastos;

var categoriaVestuario = new CategoriaVestuario("Maria", 0m);
categoriaVestuario.EfetuarDeposito(100m, DateTime.Now, "Shein");
categoriaVestuario.EfetuarDeposito(250m, DateTime.Now, "Zara");
categoriaVestuario.EfetuarDeposito(300m, DateTime.Now, "Converse");
categoriaVestuario.ExecutarMargemdeSeguranca();
Console.WriteLine(categoriaVestuario.ObterHistoricodeConta());

var categoriaLazer = new CategoriaLazer("Maria", 0m);
categoriaLazer.EfetuarDeposito(500m, DateTime.Now, "Jantares");
categoriaLazer.EfetuarDeposito(50m, DateTime.Now, "Cinema");
categoriaLazer.EfetuarDeposito(100m, DateTime.Now, "Festas");
categoriaLazer.ExecutarMargemdeSeguranca();
Console.WriteLine(categoriaLazer.ObterHistoricodeConta());

var categoriaEducacao = new CategoriaEducacao("Maria", 0m);
categoriaEducacao.EfetuarDeposito(150m, DateTime.Now, "Uniforme");
categoriaEducacao.EfetuarDeposito(30m, DateTime.Now, "Cantina");
categoriaEducacao.EfetuarDeposito(800m, DateTime.Now, "Material");
categoriaEducacao.ExecutarMargemdeSeguranca();
categoriaEducacao.EfetuarDeposito(-50m, DateTime.Now, "Bonus");
Console.WriteLine(categoriaEducacao.ObterHistoricodeConta());

var categoriaNatacao = new CategoriaNatacao("Maria", 0m);
categoriaNatacao.EfetuarDeposito(400m, DateTime.Now, "Uniforme");
categoriaNatacao.EfetuarDeposito(110m, DateTime.Now, "Mensalidade");
categoriaNatacao.EfetuarDeposito(70m, DateTime.Now, "Competição");
categoriaNatacao.ExecutarMargemdeSeguranca();
Console.WriteLine(categoriaNatacao.ObterHistoricodeConta());