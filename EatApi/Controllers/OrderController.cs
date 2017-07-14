using System.Collections.Generic;
using EatApi.Models;
using EatApi.Repositories;
using EatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EatApi.Controllers
{

    /// <summary>
    /// The order controller
    /// </summary>
    [Route("api/orders")]
    public class OrderController: CrudController<Order>
    {

        /// <summary>
        /// The notification.
        /// </summary>
        private INotification notification;

        /// <summary>
        /// Create a order controller
        /// </summary>
        /// <param name="repository">Repository.</param>
        public OrderController(IRepository<Order> repository,
                               INotification notification): base(repository)
        {
            this.notification = notification;
        }

        /// <summary>
        /// Get status of the order
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        // GET api/values/5
        [HttpGet("{id}/isReady")]
        public bool CheckStatus(string id)
        {
            notification.SendMessage("Your order is ready");
            return repository.Get(id)?.IsReady ?? false;
        }


        /// <summary>
        /// Place an order
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="items">Items.</param>
        [HttpPut]
        public string PlaceOrder([FromBody] List<OrderItem> items)
        {
            var order = new Order()
            {
                Items = items,
                IsReady = false
            };

            repository.Save(order);

            return order.Id;
        }

		/// <summary>
		/// Set the order status to ready
		/// </summary>
		/// <returns>The put.</returns>
		/// <param name="isReady">Boolean.</param>
		// PATCH api/values/5
		[HttpPatch("{id}")]
        public bool Patch([FromRoute] string id, [FromBody] bool isReady)
        {
            var order = repository.Get(id);
            order.IsReady = isReady;
            return repository.Save(order);
        }

    }
}
