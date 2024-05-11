namespace Cart.Lib.Dtos
{
    /// <summary>
    /// Cart Item Dto that include Product Info and Cart Info
    /// </summary>
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Qty { get; set; }
    }
}