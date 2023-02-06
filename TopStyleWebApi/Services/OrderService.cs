using TopStyleWebApi.Controllers;
using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;
using TopStyleWebApi.Models.RecievingClasses;
using TopStyleWebApi.Repository;

namespace TopStyleWebApi.Services;

public class OrderService:IService<Order>
{
    private readonly OrderRepo _dbConn;
    private readonly ApiDbContext _context;

    public OrderService(ApiDbContext context)
    {
        _dbConn = new OrderRepo(context);
        _context = context;
    }
    
    public IEnumerable<Order> GetAll()
    {
        return _dbConn.GetAll();
    }

    public Order GetById(int id)
    {
        return _dbConn.GetById(id);
    }

    public void Add(Order entity)
    {
        throw new NotImplementedException();
    }

    public void Add(TemplateOrder entity)
    {
        var order = new Order
        {
            TotalPrice = entity.TotalPrice,
            UserId = entity.UserId,
            User = _context.Users.Find(entity.UserId)!,
        };
        
        foreach (var product in entity.Products)
        {
            var existingProduct = _context.Products.Find(product);
            if (existingProduct == null)
            {
                throw new Exception("The specified product does not exist and cannot be created.");
            }
            order.Products.Add(existingProduct);
        }
        
        _dbConn.Add(order);
    }


    public void Update(int id, Order entity)
    {
        _dbConn.Update(entity);
    }

    public void DeleteById(int id)
    {
        _dbConn.DeleteById(id);
    }
}