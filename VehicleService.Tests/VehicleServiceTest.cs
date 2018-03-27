using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleService.Controllers;
using VehicleService.Models;
using System.Web.Http.Results;
using System.Collections.Generic;
using Moq;
using System.Web;
using System.Web.Caching;
using Microsoft.AspNetCore.Http;
using System.Web.Http.Controllers;

namespace VehicleService.Tests
{
    [TestClass]
    public class VehicleServiceTest
    {
        [TestClass]
        public class TestVehiclesController
        {
            private VehiclesController _currentController = new VehiclesController();;
          

            [TestMethod]
            public void GetAllProducts_ShouldReturnAllProducts()
            {
                var testProducts = GetTestProducts();
             
                var result = _currentController.Get() as List<Vehicle>;
                Assert.AreEqual(testProducts.Count, result.Count);
            }


            [TestMethod]
            public void GetAllProducts_ShouldReturnFilteredProducts()
            {
                var testProducts = GetFilteredTestProducts();
               

                var result = _currentController.Get(new FilterCriteria() { Make = "Toyota" }) as List<Vehicle>;
                Assert.AreEqual(testProducts.Count, result.Count);
            }

            [TestMethod]
            public void GetProduct_ShouldReturnCorrectProduct()
            {
                var testProducts = GetTestProducts();
               
                var result = _currentController.Get(1) as OkNegotiatedContentResult<Vehicle>;
                Assert.IsNotNull(result);
                Assert.AreEqual(testProducts[0].Id, result.Content.Id);
                Assert.AreEqual(testProducts[0].Make, result.Content.Make);
                Assert.AreEqual(testProducts[0].Model, result.Content.Model);
                Assert.AreEqual(testProducts[0].Year, result.Content.Year);
            }



            [TestMethod]
            public void GetProduct_ShouldNotFindProduct()
            {            

                var result = _currentController.Get(999);
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }

            private List<Vehicle> GetTestProducts()
            {
                var testProducts = new List<Vehicle>();
                testProducts.Add(new Vehicle { Id = 1, Model = "Accord", Year = 1957, Make = "Honda" });
                testProducts.Add(new Vehicle { Id = 2, Model = "Camry", Year = 1999, Make = "Toyota" });


                return testProducts;
            }

            private List<Vehicle> GetFilteredTestProducts()
            {
                var testProducts = new List<Vehicle>();

                testProducts.Add(new Vehicle { Id = 2, Model = "Camry", Year = 1999, Make = "Toyota" });


                return testProducts;
            }
        }
    }
}
