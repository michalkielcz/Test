
using Interview.Core.Interfaces;
using Interview.Core.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DataAccess.Repositories
{
    public class DataRepository : IDataRepository
    {
        private const string _dataPath = "data.json";
        private readonly JObject _dataSource;
        private JArray _array;

        public DataRepository()
        {
            _dataSource = JObject.Parse(File.ReadAllText(_dataPath)); // could be very time consuming. Only for interview purposes
            _array = _dataSource["array"] as JArray;
           
        }
        public IEnumerable<DataModel> GetAll()
        {
            return _array.Select(d => d.ToObject<DataModel>());
        }

        public DataModel Get(string id)
        {
            return _array.Select(d => d.ToObject<DataModel>()).FirstOrDefault(d => d.Id == id);
        }

    
        public void Add(DataModel data)
        {
                var jsonData = JObject.FromObject(new
                {
                    ApplicationId = Guid.NewGuid(),
                    data.Type,
                    data.Summary,
                    data.Amount,
                    data.PostingDate,
                    data.IsCleared,
                    data.ClearedDate
                    
                });
            _array.Add(jsonData);
            File.WriteAllText(_dataPath, _dataSource.ToString()); //could be very time consuming. Also for update it will be hit twice.  Only for interview purposes
        }

        public void Delete(DataModel application)
        {
            if (string.IsNullOrEmpty(application.Id) || _array.All(d => d["Id"].ToString() != application.Id))
                return;
            var token = _array.FirstOrDefault(d => d["Id"].ToString() == application.Id);
            _array.Remove(token);
            File.WriteAllText(_dataPath, _dataSource.ToString()); // could be very time consuming. Also for update it will be hit twice.  Only for interview purposes
        }

        public void Update(DataModel application)
        {
            if (string.IsNullOrEmpty(application.Id) || _array.All(d => d["Id"].ToString() != application.Id))
                return;
            Delete(application);
            Add(application);
        }
    }
}
