using System.Net;
using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;
using TopStyleWebApi.Repository;

namespace TopStyleWebApi.Services;

public class CategoryService: IService<Category>
{
    private readonly CategoryRepo _dbConn;

    public CategoryService(ApiDbContext context)
    {
        _dbConn = new CategoryRepo(context);
    }
    
    public IEnumerable<Category> GetAll()
    {
        return _dbConn.GetAll();
    }

    public Category GetById(int id)
    {
        return _dbConn.GetById(id);
    }

    public void Add(Category entity)
    {
        _dbConn.Add(entity);
    }

    public void Update(int id, Category entity)
    {
        var category = _dbConn.GetById(id);
        
        if (category==null) 
            throw new Exception(HttpStatusCode.NotFound.ToString());
        
        category.Name = entity.Name;
        _dbConn.Update(category);
    }

    public void DeleteById(int id)
    {
        _dbConn.DeleteById(id);
    }
}