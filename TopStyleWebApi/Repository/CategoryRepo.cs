using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;

namespace TopStyleWebApi.Repository;

public class CategoryRepo : IRepo<Category>
{
    private readonly ApiDbContext _context;

    public CategoryRepo(ApiDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories;
    }

    public Category GetById(int id)
    {
        return _context.Categories.FirstOrDefault(p => p.Id == id)!;
    }

    public void Add(Category entity)
    {
        _context.Categories.Add(entity);
        _context.SaveChanges();
    }
    
    public void Update(Category entity)
    {
        _context.Categories.Update(entity);
        _context.SaveChanges();
    }
    public void DeleteById(int id)
    {
        _context.Categories.Remove(_context.Categories.FirstOrDefault(p => p.Id == id)!);
        _context.SaveChanges();
    }
}