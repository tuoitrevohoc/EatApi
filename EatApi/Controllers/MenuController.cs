using System;
using EatApi.Models;
using EatApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EatApi.Controllers
{

    /// <summary>
    /// Restaurant controllers
    /// </summary>
    [Route("api/menus")]
    public class MenuController: CrudController<MenuItem>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EatApi.Controllers.RestaurantController"/> class.
        /// </summary>
        public MenuController(IRepository<MenuItem> repository): base(repository)
        {
        }
    }
}
