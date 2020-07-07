using PropductImport.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductBusinessLayer.BusinessDefinition
{
    public interface IFileImportRepository
    {
        List<ProductInventory> ImportCSV(StreamReader sreader);

        List<ProductInventory> ImportFLF(StreamReader sreader);
    }
}
