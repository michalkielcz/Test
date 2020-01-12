using Interview.Core.Interfaces;
using Interview.Core.Models;
using Interview.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Tests.Services
{
    [TestClass]
    public class DataServcieTests
    {
        [TestMethod]
        public void CanGet()
        {
            var dataRepositoryMock = new Mock<IDataRepository>();
            dataRepositoryMock.Setup(m => m.GetAll()).Returns(new List<DataModel> { new DataModel() });
            var dataService = new DataService(dataRepositoryMock.Object);
            var objects = dataService.GetAll();
            Assert.IsTrue(objects.Count() == 1);
        }

        [TestMethod]
        public void CanAdd()
        {
            Assert.IsTrue(false); // todo
        }
        [TestMethod]
        public void CanUpdate()
        {
            Assert.IsTrue(false); // todo
        }
        [TestMethod]
        public void CandDelete()
        {
            Assert.IsTrue(false); // todo
        }
    }
}
