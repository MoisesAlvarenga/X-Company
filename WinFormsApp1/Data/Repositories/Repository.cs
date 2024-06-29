using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XCompany.Data.Entities;
using XCompany.DataContext;

namespace XCompany.Data.Repositories
{
    /// <summary>
    /// Implementação concreta da interface IRepository<TEntity> que utiliza Entity Framework Core para operações de CRUD e consultas.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade que será manipulada pelo repositório.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly XCompanyContext _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Construtor que inicializa o repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados do Entity Framework Core.</param>
        public Repository(XCompanyContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Busca uma entidade pelo seu ID de forma assíncrona.
        /// </summary>
        /// <param name="id">ID da entidade a ser buscada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é a entidade encontrada.</returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Retorna todas as entidades de forma assíncrona.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Retorna todas as entidades de forma síncrona.
        /// </summary>
        /// <returns>Uma coleção de todas as entidades.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Busca entidades que correspondem a um predicado especificado de forma assíncrona.
        /// </summary>
        /// <param name="predicate">Expressão lambda que define o predicado de busca.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades que correspondem ao predicado.</returns>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log a exceção ou fazer outras ações apropriadas antes de relançar
                Console.WriteLine($"Erro ao executar a consulta: {ex.Message}");
                throw new Exception("Erro ao executar a consulta", ex);
            }
        }

        /// <summary>
        /// Executa uma consulta SQL e retorna entidades de forma assíncrona.
        /// </summary>
        /// <param name="sqlQuery">Consulta SQL a ser executada.</param>
        /// <param name="parameters">Parâmetros da consulta SQL.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades retornadas pela consulta SQL.</returns>
        public async Task<IEnumerable<TEntity>> FindBySqlAsync(string sqlQuery, params object[] parameters)
        {
            return await _dbSet.FromSqlRaw(sqlQuery, parameters).ToListAsync();
        }

        /// <summary>
        /// Adiciona uma entidade de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task AddAsync(TEntity entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow; // Define CreatedAt automaticamente
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync(); // Persiste as mudanças no banco de dados
            }
            catch (DbUpdateException ex)
            {
                // Log ou analise a exceção aqui
                Console.WriteLine(ex.InnerException?.Message);
                throw; // Re-throw para propagar a exceção
            }
        }

        /// <summary>
        /// Adiciona uma coleção de entidades de forma assíncrona.
        /// </summary>
        /// <param name="entities">Coleção de entidades a serem adicionadas.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedAt = DateTime.UtcNow; // Define CreatedAt automaticamente
            }
            await _dbSet.AddRangeAsync(entities);
        }

        /// <summary>
        /// Atualiza uma entidade de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma entidade de forma síncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser removida.</param>
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges(); // Persiste as mudanças no banco de dados
        }

        /// <summary>
        /// Remove uma entidade de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser removida.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma coleção de entidades.
        /// </summary>
        /// <param name="entities">Coleção de entidades a serem removidas.</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Retorna todas as entidades com inclusão de entidades relacionadas de forma assíncrona, especificadas por includes.
        /// </summary>
        /// <param name="includes">Expressões de inclusão para carregamento antecipado de entidades relacionadas.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado é uma coleção de entidades com inclusão de entidades relacionadas.</returns>
        public async Task<IEnumerable<TEntity>> GetAllWithIncludeAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        // Métodos adicionais podem ser adicionados conforme necessário para funcionalidades específicas
    }
}
