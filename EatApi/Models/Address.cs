using System;
namespace EatApi.Models
{
    /// <summary>
    /// Address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the line1.
        /// </summary>
        /// <value>The line1.</value>
        public string Street { get; set; }

        /// <summary>
        /// City
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// the postal code
        /// </summary>
        /// <value>The postal code.</value>
        public string PostalCode { get; set; }
    }
}
