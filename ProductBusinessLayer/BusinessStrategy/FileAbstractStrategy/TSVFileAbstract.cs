using Microsoft.AspNetCore.Http;
using ProductBusinessLayer.BusinessDefinition;
using ProductDataLayer.ViewModel;
using System;
using System.Collections.Generic;

namespace ProductBusinessLayer.BusinessStrategy
{
    /// <summary>
    /// Implementation of TSV process - we can extend process logic here in future
    /// </summary>
    public class TSVFileAbstract : IFileAbstract
    {
        /// <summary>
        /// Logic: Process Imported Files
        /// </summary>
        /// <param name="postedFile">File object</param>
        /// <returns>Product Inventory List</returns>
        public List<ProductInventory> ProcessImportedFiles(IFormFile postedFile)
        {
            throw new NotImplementedException();
        }
    }
}
