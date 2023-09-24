using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int maxSize = 10; 
        Pizza[] pizzas = new Pizza[maxSize];
        int pizzaCount = 0; 

        List<Pedido> pedidos = new List<Pedido>();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Adicionar pizza");
            Console.WriteLine("2. Listar pizzas");
            Console.WriteLine("3. Criar novo pedido");
            Console.WriteLine("4. Listar pedidos");
            Console.WriteLine("5. Pagar pedido");
            Console.WriteLine("6. Sair");
            Console.WriteLine("Escolha uma opção: ");

            int escolha;
            if (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.Write("---------------------------------------------");
                Console.WriteLine("Opção inválida. Tente novamente.");
                Console.Write("---------------------------------------------");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    if (pizzaCount < maxSize)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Adicionar pizza");
                        Console.WriteLine("---------------------------------------------");
                        Console.Write("Digite o nome da pizza: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite os ingredientes da pizza (separados por vírgula): ");
                        string[] ingredientes = Console.ReadLine().Split(',');

                        Console.Write("Digite o valor da pizza: ");
                        decimal valor;
                        if (!decimal.TryParse(Console.ReadLine(), out valor))
                        {
                            Console.WriteLine("Valor inválido. Tente novamente.");
                            break;
                        }

                        Pizza novaPizza = new Pizza(nome, ingredientes, valor);
                        pizzas[pizzaCount] = novaPizza;
                        pizzaCount++;

                        Console.WriteLine("Pizza criada com sucesso!");
                        Console.WriteLine("---------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Limite máximo de pizzas atingido.");
                        Console.WriteLine("---------------------------------------------");
                    }
                    break;

                case 2:
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Lista de pizzas");
                    Console.WriteLine("---------------------------------------------");
                    for (int i = 0; i < pizzaCount; i++)
                    {
                        Console.WriteLine($"{i + 1}. {pizzas[i].Nome} - Valor: {pizzas[i].Valor:C}");
                    }
                    Console.WriteLine("---------------------------------------------");
                    break;

                case 3:
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Novo pedido");
                    Console.WriteLine("---------------------------------------------");
                    Console.Write("Quem é o cliente? ");
                    string nomeCliente = Console.ReadLine();
                    Console.Write("Qual o telefone do cliente? ");
                    string telefone = Console.ReadLine();

                    List<Pizza> pizzasPedido = new List<Pizza>();
                    decimal totalPedido = 0;

                    do
                    {
                        Console.WriteLine("Escolha uma pizza para adicionar (digite o número):");
                        for (int i = 0; i < pizzaCount; i++)
                        {
                            Console.WriteLine($"{i + 1}. {pizzas[i].Nome} - Valor: {pizzas[i].Valor:C}");
                        }

                        if (int.TryParse(Console.ReadLine(), out int pizzaIndex) && pizzaIndex >= 1 && pizzaIndex <= pizzaCount)
                        {
                            Pizza pizzaSelecionada = pizzas[pizzaIndex - 1];
                            pizzasPedido.Add(pizzaSelecionada);
                            totalPedido += pizzaSelecionada.Valor;

                            Console.Write("Deseja acrescentar mais uma pizza? (1 - SIM | 2 - NÃO): ");
                        }
                        else
                        {
                            Console.WriteLine("Pizza inválida. Tente novamente.");
                        }
                    } while (Console.ReadLine() == "1");

                    Pedido novoPedido = new Pedido(nomeCliente, telefone, pizzasPedido, totalPedido);
                    pedidos.Add(novoPedido);

                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"PEDIDO CRIADO - Total: {novoPedido.ValorTotal:C}");
                    Console.WriteLine("---------------------------------------------");
                    break;

                case 4:
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Lista de pedidos");
                    Console.WriteLine("---------------------------------------------");

                    for (int i = 0; i < pedidos.Count; i++)
                    {
                        var pedido = pedidos[i];
                        Console.WriteLine($"Cliente: {pedido.NomeCliente} - Telefone: {pedido.Telefone}");
                        Console.WriteLine("Pizzas do Pedido:");
                        foreach (var pizzaPedido in pedido.PizzasSelecionadas)
                        {
                            Console.WriteLine($"{pizzaPedido.Nome} - Valor: {pizzaPedido.Valor:C}");
                        }
                        Console.WriteLine($"Total: {pedido.ValorTotal:C}");

                        if (pedido.FoiPago)
                        {
                            Console.WriteLine("Quanto falta para pagar: R$ 00,00");
                            Console.WriteLine("Pago: SIM");
                        }
                        else
                        {
                            Console.WriteLine($"Quanto falta para pagar: {pedido.ValorTotal - pedido.ValorPago:C}");
                            Console.WriteLine("Pago: NÃO");
                        }
                    }
                    Console.WriteLine("---------------------------------------------");
                    break;

                case 5:
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Pagamento do pedido");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Lista de Pedidos:");
                    for (int i = 0; i < pedidos.Count; i++)
                    {
                        var pedido = pedidos[i];
                        Console.WriteLine($"{i + 1}. Cliente: {pedido.NomeCliente} - Falta: {pedido.ValorTotal - pedido.ValorPago:C}");
                    }

                    Console.Write("Qual o número do pedido: ");
                    if (int.TryParse(Console.ReadLine(), out int pedidoIndex) && pedidoIndex >= 1 && pedidoIndex <= pedidos.Count)
                    {
                        var pedidoEscolhido = pedidos[pedidoIndex - 1];

                        Console.WriteLine(" ");
                        Console.WriteLine("ESCOLHA UMA FORMA DE PAGAMENTO");
                        Console.WriteLine("1 - Dinheiro");
                        Console.WriteLine("2 - Cartão de Débito");
                        Console.WriteLine("3 - Vale-Refeição");
                        Console.Write("Digite o número da forma de pagamento: ");
                        Console.WriteLine(" ");

                        if (int.TryParse(Console.ReadLine(), out int formaPagamento) && formaPagamento >= 1 && formaPagamento <= 3)
                        {
                            pedidoEscolhido.FormaPagamento = GetFormaPagamentoString(formaPagamento);

                            Console.Write("Valor de pagamento: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal valorRecebido))
                            {
                                pedidoEscolhido.ValorPago = valorRecebido;
                                pedidoEscolhido.FoiPago = true;
                                Console.WriteLine(" ");
                                Console.WriteLine($"TOTAL PAGO: {pedidoEscolhido.ValorPago:C} - {pedidoEscolhido.FormaPagamento}");
                                Console.WriteLine($"FALTA: {pedidoEscolhido.ValorTotal - pedidoEscolhido.ValorPago:C}");
                                Console.WriteLine($"TROCO: {pedidoEscolhido.ValorPago - pedidoEscolhido.ValorTotal:C}");
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------");
                                Console.WriteLine("Valor inválido.");
                                Console.WriteLine("---------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("Opção de forma de pagamento inválida.");
                            Console.WriteLine("---------------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Número de pedido inválido.");
                        Console.WriteLine("---------------------------------------------");
                    }
                    break;

                case 6:
                    Console.Write("---------------------------------------------");
                    Console.WriteLine("Saindo do programa.");
                    Console.Write("---------------------------------------------");
                    return;

                default:
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.WriteLine("---------------------------------------------");
                    break;
            }
        }
    }

    private static string GetFormaPagamentoString(int formaPagamento)
    {
        switch (formaPagamento)
        {
            case 1:
                return "Dinheiro";
            case 2:
                return "Cartão de Débito";
            case 3:
                return "Vale-Refeição";
            default:
                return "Desconhecido";
        }
    }
}





   
