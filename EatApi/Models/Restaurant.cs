using System;
namespace EatApi.Models
{
    /// <summary>
    /// The restaurant
    /// </summary>
    public class Restaurant: Entity
    {

        /// <summary>
        /// Name of restaurant
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>The photo.</value>
        public string Photo { get; set; }

        /// <summary>
        /// Information
        /// </summary>
        /// <value>The information.</value>
        public string Information { get; set; }

        /// <summary>
        /// Address data
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; set; }
    }
}
