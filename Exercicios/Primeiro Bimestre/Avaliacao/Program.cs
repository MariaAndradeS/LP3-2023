class Media
{
    public static double Calculo(double nota1, double nota2)
    {
        double result = double.NaN;
        result = (nota1 + nota2) / 2;
        return result;
    }
}

class Programa
{
    static void Main(String[] args)
    {
        bool exit = false;
        string nt1 = "";
        string nt2 = "";
        double nota1 = 0;
        double nota2 = 0;
        double media = 0;
        double mediaTurma = 0;
        int cont = 0;

        while (!exit)
        {

            Console.Write("Digite a nota 1: ");
            nt1 = Console.ReadLine();

            while (!double.TryParse(nt1, out nota1))
            {
                Console.Write("Nota Inválida. Digite uma nota válida: ");
                nt1 = Console.ReadLine();
            }

            Console.Write("Digite a nota 2: ");
            nt2 = Console.ReadLine();

            while (!double.TryParse(nt2, out nota2))
            {
                Console.Write("Nota Inválida. Digite uma nota válida: ");
                nt2 = Console.ReadLine();
            }

            try
            {

                media = Media.Calculo(nota1, nota2);

                if (double.IsNaN(media))
                {
                    Console.WriteLine("Esta operação resultará em um erro matemático.\n");
                }
                else
                    Console.WriteLine("A média do aluno foi: {0:0.##}\n", media);
            }

            catch (Exception e)
            {
                Console.WriteLine("Ocorreu uma exceção.\n -Detalhes: " + e.Message);
            }

            Console.Write("Digite 'n' para encerrar a execução ou digite qualquer tecla para continuar: ");

            ++cont;
            mediaTurma = mediaTurma + media;

            if (Console.ReadLine() == "n")
            {
                exit = true;
                mediaTurma = mediaTurma / cont;
                Console.Write("A média da turma foi: {0:0.##} \n", mediaTurma);
            }
        }
        return;
    }
}