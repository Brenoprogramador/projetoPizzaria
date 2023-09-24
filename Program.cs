public class Program {
    public static void Main() {

        // VARIAVEIS
        int option = 0;



        while (option == 0 || option < 1 || option > 3) {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao Projeto de Pizzaria");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ESCOLHA UMA OPÇÃO");
            Console.WriteLine("1 - Adicionar uma pizza");
            Console.WriteLine("2 - Listas Pizzas");
            Console.WriteLine(" ");
            Console.WriteLine("Digite sua opção: ");
            option = int.Parse(Console.ReadLine());
        }

        switch (option)
        {
            case 1:
                var (nome, ingredientes, preco) = Menu.CreatePizza();
                var pizza = new Pizza(nome, ingredientes, preco);
                Console.WriteLine(pizza);
            break; 
         } 
        

        

    }


}
 

