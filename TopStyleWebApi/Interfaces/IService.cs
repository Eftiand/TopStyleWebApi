namespace TopStyleWebApi.Interfaces;

public interface IService <T> 
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(int id, T entity);
    void DeleteById(int id);
}