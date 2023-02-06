using System.Net;
using System.Web.Http;
using Azure.Core;
using TopStyleWebApi.Data;
using TopStyleWebApi.Interfaces;
using TopStyleWebApi.Models;
using TopStyleWebApi.Repository;

namespace TopStyleWebApi.Services;

public class UserService : IService<User>
{
    private readonly UserRepo _dbConn;

    public UserService(ApiDbContext context)
    {
        _dbConn = new UserRepo(context);
    }

    public IEnumerable<User> GetAll()
    {
        return _dbConn.GetAll();
    }

    public User GetById(int id)
    {
        var user = _dbConn.GetById(id);
        
        return user;
    }

    public void Add(User entity)
    {
        _dbConn.Add(entity);
    }

    public void Update(int id,User entity)
    {
        var user = _dbConn.GetById(id);

        if (user==null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);
        
        _dbConn.Update(entity);
    }

    public void DeleteById(int id)
    {
        _dbConn.DeleteById(id);
    }
    
    public User? Login(string email, string password)
    {
        var user = _dbConn.GetAll().FirstOrDefault(x => x.UserName == email && x.Password == password);
        if (user ==null)
            throw new HttpRequestException("Invalid username or password");
        
        return user;
    }
}