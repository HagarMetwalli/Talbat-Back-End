using System.Collections.Generic;
using System.Threading.Tasks;

namespace Talbat.IServices
{
    public interface IGenericComposite<T>
    {
        List<T> RetriveAll();
        List<T> RetriveWithFstKey(int id);
        List<T> RetriveWithSndKey(int id);

        T Retrive(int id1, int id2);

        T Create(T item);

        bool Delete(int id1, int id2);

        T Put(T item);
    }
}
