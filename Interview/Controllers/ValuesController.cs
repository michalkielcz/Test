using Interview.Core.Interfaces;
using Interview.Core.Models;
using Interview.DataAccess.Repositories;
using Interview.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Interview.Controllers.Filters;

namespace Interview.Controllers
{
    public class ValuesController : ApiController
    {

        private readonly IDataRepository _dataRepository;
        private readonly DataService _dataService;

        public ValuesController()
        {
            _dataRepository = new DataRepository();// todo - definitely introduce IOC
            _dataService = new DataService(_dataRepository); // todo - definitely introduce IOC
        }
        //private readonly IDataRepositor        // GET api/values
        [Auth("Get")]
        public IEnumerable<string> Get()
        {
            return _dataService.GetAll();
        }

        // GET api/values/5
        //I don't get it, ids are strings
        [Auth("Get")]
        public string Get(int id)
        {
            return _dataService.Get(id);
        }

        // POST api/values
        [Auth("Post")]
        public void Post([FromBody]string value)
        {
            _dataService.Add(new DataModel()); // todo convert value to DataModel
        }

        // PUT api/values/5
        [Auth("Put")]
        public void Put(int id, [FromBody]string value) 
        {
            //todo create DataModel from parameteres
            //won't work, cause ids are strings
            var dm = new DataModel();
            _dataService.Update(dm);
        }

        // DELETE api/values/5
        [Auth("Delete")]
        public void Delete(int id)
        {
            //won't work because ids are strings
            var dm = new DataModel { Id = id.ToString() };
            _dataService.Delete(dm);
        }
    }
}
