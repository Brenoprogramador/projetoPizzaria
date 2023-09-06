public class Pizza {
    public string Nome {get; set;}
    public double Preco {get; set;}
    public string[] Ingredientes {get; set;} 

    public Pizza(string nome, string[] ingredientes, double preco) {
        Nome = nome;
        Preco = preco;
        Ingredientes = ingredientes;
    }
    public override string ToString(){
        return $"nome: {Nome}\ningredientes: {Ingredientes}\npreço: {Preco}";
    }
}