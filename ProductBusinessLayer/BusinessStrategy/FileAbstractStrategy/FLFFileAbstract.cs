using Microsoft.AspNetCore.Http;
using ProductBusinessLayer.BusinessDefinition;
using ProductDataLayer.ViewModel;
using System.Collections.Generic;
using System.IO;

namespace ProductBusinessLayer.BusinessStrategy
{
    /// <summary>
    /// Implementation of FLF process 
    /// </summary>
    public class FLFFileAbstract : IFileAbstract
    {
        /// <summary>
        /// Logic: Process Imported Files
        /// </summary>
        /// <param name="postedFile">File object</param>
        /// <returns>Product Inventory List</returns>
        public List<ProductInventory> ProcessImportedFiles(IFormFile postedFile)
        {
            var productInventories = new List<ProductInventory>();

            using (var sreader = new StreamReader(postedFile.OpenReadStream()))
            {
                //First line is header. If header is not passed in FLF then we can neglect the below line.
                sreader.ReadLine().Split(',');

                //Loop through the records
                while (!sreader.EndOfStream)
                {
                    string rows = sreader.ReadLine();
                    productInventories.Add(new ProductInventory
                    {
                        ProductCode = rows.ToString().Substring(0, 13),
                        StoreId = rows.ToString().Substring(13, 7),
                        Quantity = int.Parse(rows.ToString().Substring(20, 5)),
                        Amount = decimal.Parse(rows.ToString().Substring(25, 6) + '.' + rows.ToString().Substring(31, 2)),
                        PDate = rows.ToString().Substring(39, 2) + '/' + rows.ToString().Substring(37, 2) + '/' + rows.ToString().Substring(33, 4)
                    });
                }
            }
            return productInventories;
        }
    }
}
