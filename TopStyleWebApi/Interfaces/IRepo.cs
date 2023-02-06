namespace TopStyleWebApi.Interfaces;

public interface IRepo <T> 
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void DeleteById(int id);
}