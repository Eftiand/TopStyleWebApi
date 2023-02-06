using Microsoft.EntityFrameworkCore;
using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;

namespace TopStyleWebApi.Repository;

public class OrderRepo:IRepo<Order>
{
    private readonly ApiDbContext _context;

    public OrderRepo(ApiDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders
            .Include("User")
            .Include("Products")
            .Include("Products.Category")
            .Include("Products.Orders");
    }

    public Order GetById(int id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id)!;
    }

    public void Add(Order entity)
    {
        _context.Orders.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Order entity)
    {
        _context.Orders.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        _context.Orders.Remove(_context.Orders.FirstOrDefault(o => o.Id == id)!);
        _context.SaveChanges();
    }
}
