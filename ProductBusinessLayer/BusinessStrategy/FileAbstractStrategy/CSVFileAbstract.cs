using Microsoft.AspNetCore.Http;
using ProductBusinessLayer.BusinessDefinition;
using ProductDataLayer.ViewModel;
using System.Collections.Generic;
using System.IO;

namespace ProductBusinessLayer.BusinessStrategy
{
    /// <summary>
    /// Implementation of CSV process 
    /// </summary>
    public class CSVFileAbstract : IFileAbstract
    {
        /// <summary>
        /// Logic: Process Imported Files
        /// </summary>
        /// <param name="postedFile">File object</param>
        /// <returns>Product Inventory List</returns>
        public List<ProductInventory> ProcessImportedFiles (IFormFile postedFile)
        {
            var productInventories = new List<ProductInventory>();
            using (var sreader = new StreamReader(postedFile.OpenReadStream()))
            {                
                //First line is header. If header is not passed in csv then we can neglect the below line.
                sreader.ReadLine().Split(',');

                //Loop through the records
                while (!sreader.EndOfStream)
                {
                    string[] rows = sreader.ReadLine().Split(',');
                    productInventories.Add(new ProductInventory
                    {
                        ProductCode = rows[0].ToString(),
                        StoreId = rows[1].ToString(),
                        Quantity = int.Parse(rows[2].ToString()),
                        Amount = decimal.Parse(rows[3].ToString()),
                        PDate = rows[4].ToString()
                    });
                }

            }
            return productInventories;
        }
    }
}
