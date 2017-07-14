using System;
using System.Collections.Generic;
using EatApi.Models;
using EatApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EatApi.Controllers
{

    /// <summary>
    /// Crud controller
    /// </summary>
    public abstract class CrudController<TEntity>: Controller
        where TEntity: Entity
    {
        /// <summary>
        /// repository
        /// </summary>
        protected IRepository<TEntity> repository;

        /// <summary>
        /// create a crud controller
        /// </summary>
        public CrudController(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

		/// <summary>
		/// Get status of the order
		/// </summary>
		/// <returns>The get.</returns>
		/// <param name="id">Identifier.</param>
		// GET api/values/5
		[HttpGet("{id}")]
        public TEntity Get(string id)
		{
			return repository.Get(id);
		}

		/// <summary>
		/// Get list of pending orders
		/// </summary>
		/// <returns>The get.</returns>
		[HttpGet]
        public IList<TEntity> GetAll()
		{
			return repository.GetAll();
		}


		/// <summary>
		/// Place an order
		/// </summary>
		/// <returns>The post.</returns>
		/// <param name="data">Items.</param>
		[HttpPost]
        public string Post([FromBody] TEntity data)
		{
			repository.Save(data);

			return data.Id;
		}

		/// <summary>
		/// Delete the id
		/// </summary>
		/// <returns>The delete.</returns>
		/// <param name="id">Identifier.</param>
		[HttpDelete("{id}")]
		public bool Delete(string id)
		{
			return repository.Delete(id);
		}
    }
}
