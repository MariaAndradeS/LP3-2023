var peixes = new List<string> {"Bagre Ensaboado2", "Tilápia2", "Camarão2", "Sardinha2"};
peixes.Remove("Tilápia2");

foreach (var peixe in peixes) {
    Console.WriteLine(peixe + "");
} 
Console.WriteLine("------------------------");

var numeros = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
for (var index = 0; index <= numeros.Count - 1; index++) {
    if (numeros[index] % 2 == 1)
        numeros.RemoveAt(index);
}
numeros.ForEach(numero => Console.WriteLine(numero + "")); 

Console.WriteLine("------------------------");

var nomes = new List<string> {"Maria", "Cain", "Gustavo", "Bea"};
foreach (var nome in nomes) {
    Console.WriteLine($"Olá {nome.ToUpper()}");
}
Console.WriteLine();
nomes.Add("Guto");
nomes.Add("Apolo");
nomes.Remove("Doda");
foreach (var nome in nomes) {
    Console.WriteLine($"Olá {nome.ToUpper()}");
}
Console.WriteLine($"Meu nome é {nomes[0]}");
Console.WriteLine($"Adicionei {nomes[3]} e {nomes[4]} na lista");
Console.WriteLine($"A lista tem {nomes.Count} pessoas");

var index = nomes.IndexOf("Felipe");
if (index == -1) {
    Console.WriteLine($"Item não encontrado {index}");
} else {
    Console.WriteLine($"O nome {nomes[index]} está no índice {index}");
}
index = nomes.IndexOf("Não Encontrado");
if (index == -1) {
    Console.WriteLine($"Item não encontrado {index}");
} else {
    Console.WriteLine($"O nome {nomes[index]} está no índice {index}");
}
nomes.Sort();
foreach (var nome in nomes){
    Console.WriteLine($"Olá{nome.ToUpper()}");
} 

Console.WriteLine("------------------------");

var fibonacciNumeros = new List<int> {1,1};
    var previo = fibonacciNumeros[fibonacciNumeros.Count -1];
    var previo2= fibonacciNumeros[fibonacciNumeros.Count -2];

    fibonacciNumeros.Add( previo + previo2 );

    foreach (var item in fibonacciNumeros) {
    Console.WriteLine(item);
} 

var fibonacciNumeros = new List<int> { 1, 1 };

for (int i = 0; i <= 19; i++) {
    var previo = fibonacciNumeros[fibonacciNumeros.Count - 1];
    var previo2 = fibonacciNumeros[fibonacciNumeros.Count - 2];
    fibonacciNumeros.Add(previo + previo2);

    Console.WriteLine($"O item " + (i + 1) + ": " + fibonacciNumeros[i]);
} 