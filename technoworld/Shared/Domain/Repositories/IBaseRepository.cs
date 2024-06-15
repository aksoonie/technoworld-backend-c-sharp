namespace technoworld.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{ 
    // Begin CRUD
    // Register / Add / POST
    Task AddAsync(TEntity entity);
    
    //Update 
    void Update(TEntity entity);
    
    //Delete
    void Remove(TEntity entity);
    
    //Select / Get
    
    //Get one or zero record
    Task<TEntity?> FindByIdAsync(int id);
    
    //Get many records
    Task<IEnumerable<TEntity>> ListAsync();
}