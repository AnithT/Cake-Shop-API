using CakeShop.Controllers;
using CakeShop.Models;
using CakeShop.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace CakeShopTests
{
    [TestClass]
    public class CakeControllerTests
    {
        
        //[TestMethod]
        //public void CanAddCake()
        //{
        //    var repo = Substitute.For<ICakeRepository>();
        //    repo.Add(new Cake()).ReturnsForAnyArgs(true);
        //    repo.Update(new Cake()).ReturnsForAnyArgs(false);

        //    var controller = new CakeController(repo);
        //    var id = Guid.NewGuid();
        //    Assert.IsTrue(controller.Put(id, new Cake { Id = id, Name = "Test cake", Added = DateTime.UtcNow }));
        //    repo.Received().Add(Arg.Any<Cake>());
        //}

        //[TestMethod]
        //public void CanUpdateCake()
        //{
        //    var repo = Substitute.For<ICakeRepository>();
        //    repo.Update(new Cake()).ReturnsForAnyArgs(true);

        //    var controller = new CakeController(repo);
        //    var id = Guid.NewGuid();
        //    repo.GetById(id).Returns(new Cake { Id = id, Name = "Test cake", Added = DateTime.UtcNow });
        //    controller.Put(id, new Cake { Id = id, Name = "Test cake update", Added = DateTime.UtcNow });
        //    repo.Received().Update(Arg.Any<Cake>());

        //}

        //[TestMethod]
        //public void CanDeleteCake()
        //{
        //    var repo = Substitute.For<ICakeRepository>();
        //    var id = Guid.NewGuid();
        //    repo.Delete(id).Returns(true);

        //    var controller = new CakeController(repo);
        //    repo.GetById(id).Returns(new Cake { Id = id, Name = "Test cake", Added = DateTime.UtcNow });
        //    controller.Delete(id);
        //    repo.Received().Delete(id);
        //}
    }
}
