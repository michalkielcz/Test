using Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Interfaces
{
    public interface IDataRepository
    {
        IEnumerable<DataModel> GetAll();
        DataModel Get(string id);
        void Add(DataModel application);
        void Delete(DataModel application);
        void Update(DataModel application);
    }
}
