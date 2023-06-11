string[] sentencas =
{
    "Eu gosto muito do meu gato",
    "Meu namorado é lindo",
    "Meu aniversário é 28/06"
};

string sPattern = "ele(s)?";   

foreach (string s in sentencas) {
    Console.Write($"{s,-40}");
    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase)) {
        Console.WriteLine($"  (comparação com '{sPattern}' encontrada)");
    } else {
        Console.WriteLine();
    }
}


string str = "Instituto Federal de São Paulo";
int index1 = str.IndexOf('F');
Console.WriteLine("O valor do índice do caracter 'F' é " + index1);

int index2 = str.IndexOf('C'); 
Console.WriteLine("O valor do índice do caracter 'C' é " + index2);



