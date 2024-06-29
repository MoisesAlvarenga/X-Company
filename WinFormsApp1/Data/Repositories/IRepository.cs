using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCompany.Data.Entities;

namespace XCompany.Data.Repositories
{
    /// <summary>
    /// Interface genérica para repositório que define operações básicas de CRUD e consultas para entidades TEntity.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade que será manipulada pelo repositório.</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Busca uma entidade pelo seu ID de forma assíncrona.
        /// </summary>
        /// <param name="id">ID da entidade a ser buscada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é a entidade encontrada.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Retorna todas as entidades de forma assíncrona.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retorna todas as entidades de forma síncrona.
        /// </summary>
        /// <returns>Uma coleção de todas as entidades.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Busca entidades que correspondem a um predicado especificado de forma assíncrona.
        /// </summary>
        /// <param name="predicate">Expressão lambda que define o predicado de busca.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades que correspondem ao predicado.</returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adiciona uma entidade de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Adiciona uma coleção de entidades de forma assíncrona.
        /// </summary>
        /// <param name="entities">Coleção de entidades a serem adicionadas.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Atualiza uma entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task Update(TEntity entity);

        /// <summary>
        /// Remove uma entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser removida.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove uma entidade de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser removida.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task RemoveAsync(TEntity entity);

        /// <summary>
        /// Remove uma coleção de entidades.
        /// </summary>
        /// <param name="entities">Coleção de entidades a serem removidas.</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Retorna todas as entidades com inclusão de entidades relacionadas de forma assíncrona, especificadas por includes.
        /// </summary>
        /// <param name="includes">Expressões de inclusão para carregamento antecipado de entidades relacionadas.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades com inclusão de entidades relacionadas.</returns>
        Task<IEnumerable<TEntity>> GetAllWithIncludeAsync(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Executa uma consulta SQL e retorna entidades de forma assíncrona.
        /// </summary>
        /// <param name="sqlQuery">Consulta SQL a ser executada.</param>
        /// <param name="parameters">Parâmetros da consulta SQL.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades retornadas pela consulta SQL.</returns>
        Task<IEnumerable<TEntity>> FindBySqlAsync(string sqlQuery, params object[] parameters);
    }
}
