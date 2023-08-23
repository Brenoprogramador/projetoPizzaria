

Console.WriteLine("Bem-vindo ao Projeto de Pizzaria");
Console.WriteLine("--------------------------------");

Console.WriteLine("ESCOLHA UMA OPÇÃO");
Console.WriteLine("1 - Adicionar uma pizza");
Console.WriteLine("2 - Listas Pizzas");
Console.WriteLine(" ");
Console.WriteLine("Digite sua opção: ");

var option = Console.ReadLine();
var pizza = new Pizza();


if (option == "1"){
    Console.WriteLine("Adicionar uma pizza! ");
    Console.WriteLine("Digite o nome da pizza: ");
    var nome = Console.ReadLine();

    Console.WriteLine("Digite os ingredientes da pizza separado por virgula: ");
    var ingredientes = Console.ReadLine().ToArray();

    Console.WriteLine("Digite o preço da pizza: ");
    var preco = int.Parse(Console.ReadLine());

    pizza.Nome = nome;
    pizza.Ingredientes = ingredientes;
    pizza.Preco = preco;

    Console.WriteLine(pizza);
};





