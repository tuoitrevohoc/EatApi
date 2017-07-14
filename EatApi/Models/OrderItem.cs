namespace EatApi.Models
{

    /// <summary>
    /// data for an order item in the bill
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Price of the item
        /// </summary>
        /// <value>The price.</value>
        public float Price { get; set; }

        /// <summary>
        /// Price 
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; set; }
    }
}
