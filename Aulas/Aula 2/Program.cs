double num1=0, num2=0;
string operacao;

Console.WriteLine("Digite o primeiro número e pressione Enter");
num1= Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Digite o segundo número e pressione Enter");
num2= Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Escolha uma operação matemática:");
Console.WriteLine("+  Soma");
Console.WriteLine("- Subração");
Console.WriteLine("* Multiplicação");
Console.WriteLine("/ Divisão");
Console.WriteLine("Qual a sua opção?");
operacao = Console.ReadLine();

switch(operacao){
    case "+":
    Console.WriteLine($"Seu resultado: {num1}+{num2} =" + (num1 + num2)); break;
    case "-":
    Console.WriteLine($"Seu resultado: {num1}-{num2} =" + (num1 - num2)); break;
    case "*":
    Console.WriteLine($"Seu resultado: {num1}*{num2} =" + (num1 * num2)); break;
    case "/":
    while(num2==0){
        Console.WriteLine("Erro = Divisão por zero\n Digite um número diferente de zero");
        num2 = Convert.ToDouble(Console.ReadLine());
    }
    Console.WriteLine($"Seu resultado: {num1}/{num2} =" + (num1 / num2)); break;
    default:
    Console.WriteLine("Operação inválida"); break;
}

Console.Write("Pressione qualquer tecla para fechar a Calculadora console app...\n");
Console.ReadKey();