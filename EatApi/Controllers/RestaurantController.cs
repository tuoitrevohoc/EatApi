using System;
using System.Collections.Generic;
using System.Linq;
using EatApi.Models;
using EatApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EatApi.Controllers
{

    /// <summary>
    /// Restaurant controllers
    /// </summary>
    [Route("api/restaurants")]
    public class RestaurantController: CrudController<Restaurant>
    {
        /// <summary>
        /// Menu repository
        /// </summary>
        private IRepository<MenuItem> menuRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EatApi.Controllers.RestaurantController"/> class.
        /// </summary>
        public RestaurantController(IRepository<Restaurant> repository,
                                    IRepository<MenuItem> menuRepository): base(repository)
        {
            this.menuRepository = menuRepository;
        }

        /// <summary>
        /// Get menu of a restaurant
        /// </summary>
        /// <returns>The menu.</returns>
        /// <param name="id">Identifier.</param>
        [HttpGet("{id}/menu")]
        public IList<MenuItem> GetMenu(string id) 
        {
            return menuRepository.GetAll().Where(item => item.RestaurantId == id)
                                 .ToList();      
        }
    }
}
