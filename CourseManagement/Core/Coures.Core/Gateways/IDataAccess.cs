using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Coures.Core.Gateways
{
    public interface IDataAccess<T>
    {
        List<T> List();

        T Add(T t);

        T Update(T t);

        void Delete(T t);

        List<T> Query(Expression<Func<T, bool>> predicate);
    }
}
