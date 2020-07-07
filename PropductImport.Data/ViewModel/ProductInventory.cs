using System;

namespace ProductDataLayer.ViewModel
{
    /// <summary>
    /// view model of product inventory properties
    /// </summary>
    public class ProductInventory : IEquatable<ProductInventory>
    {
        /// <summary>
        /// Product Code
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Store Id
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public string PDate { get; set; }

        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode()
        {
            return (string.Format("{0}{1}{2}{3}{4}", ProductCode, StoreId, Quantity, Amount, PDate)).GetHashCode();
        }

        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="other">object parameter passing</param>
        /// <returns>True or false</returns>
        public override bool Equals(object other)
        {
            return Equals(other as ProductInventory);
        }

        /// <summary>
        /// Equal method to new cobject
        /// </summary>
        /// <param name="other">model object</param>
        /// <returns>eqivalancy status</returns>
        public bool Equals(ProductInventory other)
        {
            return other != null &&
                   this.ProductCode == other.ProductCode &&
                   this.StoreId == other.StoreId &&
                   this.Quantity == other.Quantity &&
                   this.Amount == other.Amount &&
                   this.PDate == other.PDate;
        }
    }
}
