using Interview.Core.Interfaces;
using Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Services
{
    public class DataService 
    {
        private readonly IDataRepository _dataRepository;
        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<string> GetAll()
        {
            return _dataRepository.GetAll().Select(d => d.Id.ToString()); ;
        }

        public string Get(int id)
        {
            return _dataRepository.Get(id.ToString())?.Id;
        }

        public void Add(DataModel model)
        {
            _dataRepository.Add(model);
        }

        public void Delete(DataModel model)
        {
            _dataRepository.Delete(model);
        }

        public void Update(DataModel model)
        {
            _dataRepository.Update(model);
        }
    }
}
