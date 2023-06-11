class Calculadora
{
    public static double Operacao(double num1, double num2, string opcao)
    {
        double resultado = double.NaN;
        switch (opcao)
        {
            case "a":
                resultado = num1 + num2;
                break;
            case "s":
                resultado = num1 - num2;
                break;
            case "m":
                resultado = num1 * num2;
                break;
            case "d":
                if (num2 != 0)
                    resultado = num1 / num2;
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
        return resultado;
    }
}

class Programa
{
    static void Main(string[] args)
    {
        bool fimPrograma = false;
        string n1 = "";
        string n2 = "";
        double num1 = 0;
        double num2 = 0;
        double resultado = 0;
        string opcao;

        Console.WriteLine("Calculadora Console em C#\r");
        Console.WriteLine("-------------------------\n");
        while (!fimPrograma)
        {
            Console.WriteLine("Digite um número, e pressione Enter");
            n1 = Console.ReadLine();

            while (!double.TryParse(n1, out num1))
            {
                Console.Write("Número Inválido. Digite um número válido: ");
                n1 = Console.ReadLine();
            }
            Console.WriteLine("Digite outro número, e pressione Enter");
            n2 = Console.ReadLine();

            while (!double.TryParse(n2, out num2))
            {
                Console.Write("Número Inválido. Digite um número válido: ");
                n2 = Console.ReadLine();
            }
            Console.WriteLine("Escolha uma opção da lista seguinte:");
            Console.WriteLine("\ta - Soma");
            Console.WriteLine("\ts - Subtração");
            Console.WriteLine("\tm - Multiplicação");
            Console.WriteLine("\td - Divisão");
            Console.Write("Qual sua opção? ");
            opcao = Console.ReadLine();
            try
            {
                resultado = Calculadora.Operacao(num1, num2, opcao);
                if (double.IsNaN(resultado))
                {
                    Console.WriteLine("Esta operação resultará em um erro matemático.\n");
                }
                else
                    Console.WriteLine("Seu resultado é : {0:0.####}\n", resultado);
            }
            catch (Exception e)
            { Console.WriteLine("Ocorreu uma exceção.\n - Detalhes: " + e.Message); }
            Console.Write("Pressione 'n' para fechar a aplicação, ou pressione qualquer tecla para continuar: ");
            if (Console.ReadLine() == "n")
                fimPrograma = true;
            Console.WriteLine("\n");
        }
        return;
    } 
} 