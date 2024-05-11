namespace Cart.Lib.Dtos
{
    /// <summary>
    /// Caret Item Quantity Update
    /// </summary>
    public class CartItemQtyUpdateDto
    {
        public int CartItemId { get; set; }
        public int Qty { get; set; }
    }
}