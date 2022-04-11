using System.Collections.Generic;

namespace wayFinder.Interfaces
{
  public interface RepositoryInterface<T, Tid>
  {
    List<T> GetAll();

    T GetById(Tid id);

    T Create(T data);

    T Edit(T data);

    string Delete(Tid id);
  }
}