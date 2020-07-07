using Microsoft.AspNetCore.Http;
using ProductDataLayer.ViewModel;
using System.Collections.Generic;

namespace ProductBusinessLayer.BusinessDefinition
{
    /// <summary>
    /// Declaration of process 
    /// </summary>
    public interface IFileAbstract
    {
        /// <summary>
        /// Declaration to Process Imported Files
        /// </summary>
        /// <param name="postedFile">File object</param>
        /// <returns>List of process records</returns>
        List<ProductInventory> ProcessImportedFiles(IFormFile postedFile);
    }
}
