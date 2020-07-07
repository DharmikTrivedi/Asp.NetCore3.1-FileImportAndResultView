using System.Collections.Generic;

namespace ProductBusinessLayer.BusinessDefinition
{
    /// <summary>
    /// Busness context to implement factory and strategy
    /// </summary>
    public interface IBusinessDataContext
    {
        /// <summary>
        /// Collection of files and abstract by key value pair
        /// </summary>
        Dictionary<string, string> ConextStrategy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Generic implementation of Interface</typeparam>
        /// <param name="abstractClass">Class to be invoked</param>
        /// <returns>Resolves and return to respected call</returns>
        T InstantiateStrategy<T>(string abstractClass);
    }
}
