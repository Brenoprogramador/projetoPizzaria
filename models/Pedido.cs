class Pedido
{
    public string NomeCliente { get; }
    public string Telefone { get; }
    public List<Pizza> PizzasSelecionadas { get; }
    public decimal ValorTotal { get; }
    public bool FoiPago { get; set; }
    public string FormaPagamento { get; set; }
    public decimal ValorPago { get; set; }

    public Pedido(string nomeCliente, string telefone, List<Pizza> pizzasSelecionadas, decimal valorTotal)
    {
        NomeCliente = nomeCliente;
        Telefone = telefone;
        PizzasSelecionadas = pizzasSelecionadas;
        ValorTotal = valorTotal;
        FoiPago = false;
        FormaPagamento = string.Empty;
        ValorPago = 0;
    }
}