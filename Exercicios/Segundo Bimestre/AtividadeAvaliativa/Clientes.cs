namespace AtividadeAvaliativa.Models;

class Clientes {
    public int CodCliente { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
    public string Ie { get; set; }

    public Clientes(int codcliente, string nome, string endereco, string cidade, string cep, string uf, string ie) {
        CodCliente = codcliente;
        Nome = nome;
        Endereco = endereco;
        Cidade = cidade;
        Cep = cep;
        Uf = uf;
        Ie = ie;
    }
}