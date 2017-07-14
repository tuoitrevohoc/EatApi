using System;
namespace EatApi.Models
{

    /// <summary>
    /// Menu item.
    /// </summary>
    public class MenuItem: Entity
    {

        /// <summary>
        /// Restaurant id
        /// </summary>
        /// <value>The restaurant identifier.</value>
        public string RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>The photo.</value>
        public string Photo { get; set; }
    }
}
