﻿using System;
using System.Collections.Generic;
using EatApi.Models;

namespace EatApi.Repositories
{
    /// <summary>
    /// The repository
    /// </summary>
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        TEntity Get(string id);

        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns>The all.</returns>
        IList<TEntity> GetAll();

        /// <summary>
        /// Save a data
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="data">Data.</param>
        bool Save(TEntity data);

        /// <summary>
        /// Delete a data
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="data">Data.</param>
        bool Delete(TEntity data);

        /// <summary>
        /// delete with the id
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        bool Delete(string id);
    }
}
