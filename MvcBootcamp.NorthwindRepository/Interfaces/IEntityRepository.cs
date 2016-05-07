using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.NorthwindRepository.Interfaces
{
    /**
     * T: refers to Entity. T harus berupa Class
     * P: refers to primary key data type. P harus berupa tipe data primitif
     **/
    public interface IEntityRepository<T, P> where T: class where P:IConvertible
    {
        IQueryable<T> GetAllData();

        T Search(P id);

        void Insert(T entity);

        void Delete(P id);

        void Update(T entity);
    }
}
