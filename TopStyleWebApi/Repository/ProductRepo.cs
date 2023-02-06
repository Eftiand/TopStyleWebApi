using Microsoft.EntityFrameworkCore;
using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;

namespace TopStyleWebApi.Repository;

public class ProductRepo : IRepo<Product>
{
    private readonly ApiDbContext _context;

    public ProductRepo(ApiDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.Include("Category");
    }

    public Product GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id)!;
    }

    public IEnumerable<Product> GetByQuery(string query)
    {
        return _context.Products.Where(p => p.Name.Contains(query));
    }
    
    public void Add(Product entity)
    {
        _context.Products.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        _context.Products.Remove(GetAll().FirstOrDefault(p => p.Id == id));
        _context.SaveChanges();
    }
}