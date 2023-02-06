using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;
using TopStyleWebApi.Repository;

namespace TopStyleWebApi.Services;

public class ProductService : IService<Product>
{
    private readonly ProductRepo _dbConn;
    private readonly ApiDbContext _context;
    

    public ProductService(ApiDbContext context)
    {
        _dbConn = new ProductRepo(context);
        _context = context;
    }
    
    public IEnumerable<Product> GetAll()
    {
        return _dbConn.GetAll();
    }

    public Product GetById(int id)
    {
        return _dbConn.GetById(id);
    }
    
    public IEnumerable<Product> GetByQuery(string query)
    {
        return _dbConn.GetByQuery(query);
    }

    public void Add(Product entity)
    {
        var category = new CategoryRepo(_context);

        var existingCategory = category.GetAll().FirstOrDefault(x => x.Id==entity.Category.Id);

        if (existingCategory == null)
        {
            throw new Exception("The specified category does not exist and cannot be created.");
        }

        entity.Category = existingCategory;
        _dbConn.Add(entity);
    }

    public void Update(int id, Product entity)
    {
        _dbConn.Update(entity);
    }

    public void DeleteById(int id)
    {
        _dbConn.DeleteById(id);
    }
}