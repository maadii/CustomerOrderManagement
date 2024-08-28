public class UpdateOrderCommand
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ItemDto> Items { get; set; }
}
