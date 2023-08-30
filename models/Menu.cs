public class Menu{
    public static createPizza(){
        Console.WriteLine("Adicionar uma pizza! ");
            Console.WriteLine("Digite o nome da pizza: ");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite os ingredientes da pizza separado por virgula: ");
            var ingredientes = Console.ReadLine().ToArray();

            Console.WriteLine("Digite o preço da pizza: ");
            var preco = int.Parse(Console.ReadLine());
            return nome, ingredientes, preco     
    }
}