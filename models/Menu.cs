public class Menu
{
    public static (string, string[], double) CreatePizza()
    {
        Console.WriteLine("Adicionar uma pizza!");
        Console.WriteLine("Digite o nome da pizza: ");
        var nome = Console.ReadLine();

        Console.WriteLine("Digite os ingredientes da pizza separados por vírgula: ");
        var ingredientesInput = Console.ReadLine();
        var ingredientes = ingredientesInput.Split(',');

        Console.WriteLine("Digite o preço da pizza: ");
        var precoInput = Console.ReadLine();
        var preco = double.Parse(precoInput);

        Console.WriteLine("Pizza criada!");
        

        return (nome, ingredientes, preco);
    }

    
}
