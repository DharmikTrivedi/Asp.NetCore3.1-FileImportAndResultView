using ProductBusinessLayer.BusinessDefinition;
using PropductImport.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductBusinessLayer.Repository
{
    public class FileImportRepository : IFileImportRepository
    {
        public List<ProductInventory> ImportCSV(StreamReader sreader)
        {
            var productInventories = new List<ProductInventory>();
            //First line is header. If header is not passed in csv then we can neglect the below line.
            string[] headers = sreader.ReadLine().Split(',');

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

            return productInventories;
        }

        public List<ProductInventory> ImportFLF(StreamReader sreader)
        {
            var productInventories = new List<ProductInventory>();

            //First line is header. If header is not passed in csv then we can neglect the below line.
            string[] headers = sreader.ReadLine().Split(',');

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
                    PDate = rows.ToString().Substring(33, 7)
                });
            }

            return productInventories;
        }
    }
}
