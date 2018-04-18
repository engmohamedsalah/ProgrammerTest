using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.DataRepository
{
    public interface IRepository
    {
        void Delete(string data);
        void Save(object data);
        T Find<T>(string id);
        
    }
}
