﻿using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using ProductBusinessLayer.BusinessDefinition;
using ProductBusinessLayer.BusinessStrategy;
using ProductDataLayer.ViewModel;
using System.Collections.Generic;
using System.IO;

namespace ProductDataImportLab.ImportFilesTests
{
    [TestFixture]
    public class FLFImportTests
    {
        private IBusinessDataContext _businessDataContext = new BusinessDataContext();

        [Test]
        public void InstantiateStrategy_FlfProcessWithHeaderAndLineItem_ComparesResultset()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();

            //Setup mock file using a memory stream
            var content = "FLF-Import\n50558767085170002389000100000499920190927";
            var fileName = "test.flf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            //Setting expected result
            var expectedResult = new List<ProductInventory> { new ProductInventory()
            {
              ProductCode =   "5055876708517",
              StoreId =  "0002389",
              Quantity =  10,
              Amount =  decimal.Parse("49.99"),
              PDate =  "27/09/2019"
            }};


            //Act
            var result = _businessDataContext.InstantiateStrategy<IFileAbstract>
                             (_businessDataContext.ConextStrategy[".flf"]).ProcessImportedFiles(file);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}
