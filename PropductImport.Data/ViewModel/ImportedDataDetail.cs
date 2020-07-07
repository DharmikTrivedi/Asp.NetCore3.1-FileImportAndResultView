using System.Collections.Generic;

namespace ProductDataLayer.ViewModel
{
    /// <summary>
    /// View model of Imported data related properties
    /// </summary>
    public class ImportedDataDetail
    {
        /// <summary>
        /// Product inventory list
        /// </summary>
        public List<ProductInventory> ProductInventories { get; set; }

        /// <summary>
        /// Extension of imported file
        /// </summary>
        public string Extension { get; set; }
    }
}
