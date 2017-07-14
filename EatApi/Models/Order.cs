using System.Collections.Generic;
using EatApi.Models;

namespace EatApi.Models
{

    /// <summary>
    /// Data for an order
    /// </summary>
    public class Order: Entity
    {

        /// <summary>
        /// List of items in this order
        /// </summary>
        /// <value>The items.</value>
        public List<OrderItem> Items { get; set; }

        /// <summary>
        /// is the order ready or not
        /// </summary>
        /// <value><c>true</c> if is ready; otherwise, <c>false</c>.</value>
        public bool IsReady { get; set; }
    }
}
