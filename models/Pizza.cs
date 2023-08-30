public class Pizza {
    public string Nome {get; set;}
    public int Preco {get; set;}
    public char[] Ingredientes {get; set;} 

    public void pizza(string Nome, int Preco, char[] Ingredientes) {
        this.Nome = Nome;
        this.Preco = Preco;
        this.Ingredientes = Ingredientes;
    }
}


