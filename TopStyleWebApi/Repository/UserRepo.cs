using Microsoft.EntityFrameworkCore;
using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;

namespace TopStyleWebApi.Repository;

public class UserRepo:IRepo<User>
{
    private readonly ApiDbContext _context;

    public UserRepo(ApiDbContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id)!;
    }

    public void Add(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Update(User entity)
    {
        _context.Users.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        _context.Users.Remove(_context.Users.FirstOrDefault(u => u.Id == id)!);
        _context.SaveChanges();
    }
}