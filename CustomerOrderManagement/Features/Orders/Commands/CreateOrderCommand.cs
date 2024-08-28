public class CreateOrderCommand
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ItemDto> Items { get; set; }
}

public class ItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
