using ProductBusinessLayer.BusinessDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProductBusinessLayer.BusinessStrategy
{
    /// <summary>
    /// Strategy Logic: Finds which abstract is to implement from key and Instantiates appropriate abstract method
    /// </summary>
    public class BusinessDataContext : IBusinessDataContext
    {
        // assign key value pair for supporting formats and related abstracts
        Dictionary<string, string> IBusinessDataContext.ConextStrategy { get; set; }
            = new Dictionary<string, string>()
            {
                { ".csv", "CSVFileAbstract" },
                { ".flf", "FLFFileAbstract" },
                { ".tsv", "TSVFileAbstract" }
            };


        /// <summary>
        /// Instantiating abstract class as per key and resolving dependancy 
        /// </summary>
        /// <typeparam name="T">Generic parameter Interface</typeparam>
        /// <param name="fileExtension">imported file extension</param>
        /// <returns>Abstract method call</returns>
        public T InstantiateStrategy<T>(string abstractClass)
        {
            Type typeImplemented = typeof(T);
            Type selectedType = Assembly.GetExecutingAssembly() 
                    .GetTypes()
                    .First(t => typeImplemented.IsAssignableFrom(t) && t.Name == abstractClass);

            return (T)Activator.CreateInstance(selectedType);
        }

    }
}
