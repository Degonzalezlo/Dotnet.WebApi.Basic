using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using System.Linq.Expressions;

namespace MyVaccine.WebApi.Repositories.Implementations;

public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
{
    private readonly MyVaccineAppDbContext _context;
    public BaseRepository(MyVaccineAppDbContext context) 
    {
        _context = context;
    }
    public async Task Add(T entity)
    {
        var UpdatedAt = entity.GetType().GetProperty("UpdatedAt");
        if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt").SetValue(entity, DateTime.UtcNow);

        var CreatedAt = entity.GetType().GetProperty("CreatedAt");
        if (CreatedAt != null) entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);

        await _context.AddAsync(entity);
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
      
    }

    public async Task AddRange(List<T> entity)
    {
       entity = entity.Select( x =>
       {
           if (x.GetType().GetProperty("UpdatedAt") != null) x.GetType().GetProperty("UpdatedAt").SetValue(x, DateTime.UtcNow);
           if (x.GetType().GetProperty("CreatedAt") != null) x.GetType().GetProperty("CreatedAt").SetValue(x, DateTime.UtcNow);
           return x;

       }).ToList();
        _context.AddRange(entity);
        await _context.SaveChangesAsync();


    }

    public async Task Delet(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRange(List<T> entity)
    {
        _context.RemoveRange(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return GetAll().Where(predicate);
    }

    public IQueryable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate)
    {
        return GetAll().AsNoTracking().Where(predicate);
    }

    public IQueryable<T> GetAll()
    {
      var entitySet = _context.Set<T>();
        return entitySet.AsQueryable();
    }

    public async Task Pacth(T entity)
    {
        var entry = _context.Entry(entity);

        if (entry.State == EntityState.Detached)
        {
            // Asumming that entity has an Id property
            var key = entity.GetType().GetProperty("Id").GetValue(entity, null);
            var originalEntity = await _context.Set<T>().FindAsync(key);

            //Atach the original entity and ser values from the incomig entity
            entry = _context.Entry(originalEntity);
            entry.CurrentValues.SetValues(entity);

        }

        
    }

    public Task PatchRange(List<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task Update(T entity)
    {
        var UpdatedAt = entity.GetType().GetProperty("UpdatedAt");
        if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt").SetValue(entity, DateTime.UtcNow);

        _context.Update(entity);
        await _context.SaveChangesAsync();

    }

    public  async Task UpdateRange(List<T> entity)
    {
        entity = entity.Select(x =>
        {
            if (x.GetType().GetProperty("UpdatedAt") != null) x.GetType().GetProperty("UpdatedAt").SetValue(x, DateTime.UtcNow);
            return x;

        }).ToList();
        _context.UpdateRange(entity);
        await _context.SaveChangesAsync();

    }
}
