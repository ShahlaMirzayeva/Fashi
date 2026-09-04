namespace Fashi.ViewModels.CartVm
{
    public class CartVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<CartVM> CartProducts { get; set; }
        public int Quantity { get; set; }
    }
}
