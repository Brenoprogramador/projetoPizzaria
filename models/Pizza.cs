public class Pizza {
    public string Nome {get; set;}
    public int Preco {get; set;}
    public string[] Ingredientes {get; set;} 

    public void pizza(string Nome, int Preco, string[] Ingredientes) {
        this.Nome = Nome;
        this.Preco = Preco;
        this.Ingredientes = Ingredientes;
    }
}


